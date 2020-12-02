using AutoUpdaterDotNET;
using CR2ToJPG.Common;
using CR2ToJPG.Common.Components;
using renderer;
using structure;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

// ReSharper disable LocalizableElement

namespace CR2ToJPG.UI.Forms
{
    public partial class FrmMain : Form
    {
        private bool _isWorking;

        public static AppOptions Settings = new AppOptions();

        public static WatermarkContext WmContext = new WatermarkContext();

        public static AbortableBackgroundWorker BwConverter = new AbortableBackgroundWorker();

        public FrmMain()
        {
            InitializeComponent();
            //
            // bwConverter
            //
            BwConverter.WorkerReportsProgress = true;
            BwConverter.WorkerSupportsCancellation = true;
            BwConverter.DoWork += bwConverter_DoWork;
            BwConverter.ProgressChanged += bwConverter_ProgressChanged;
            BwConverter.RunWorkerCompleted += bwConverter_RunWorkerCompleted;
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                if (_isWorking == false)
                {
                    if (string.IsNullOrEmpty(txtInputDirectory.Text) || string.IsNullOrEmpty(txtOutputDirectory.Text))
                    {
                        MessageBox.Show(@"Input and Output Directories Are Required.", @"CR2 To JPG", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    if (!Directory.Exists(txtInputDirectory.Text) || !Directory.Exists(txtOutputDirectory.Text))
                    {
                        MessageBox.Show(@"One or more directories are invalid or don't exist", @"CR2 To JPG", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    SetFormWorking(true);

                    pbProgress.Value = 0;

                    string[] arrFiles;

                    if (Settings.Subfolders)
                    {
                        arrFiles = Directory.GetFiles(txtInputDirectory.Text, "*.CR2", SearchOption.AllDirectories);
                        if (Settings.ProcessJpeg)
                            arrFiles = arrFiles.Concat(Directory.GetFiles(txtInputDirectory.Text, "*.JPG")).ToArray();
                    }
                    else
                    {
                        arrFiles = Directory.GetFiles(txtInputDirectory.Text, "*.CR2");
                        if (Settings.ProcessJpeg)
                            arrFiles = arrFiles.Concat(Directory.GetFiles(txtInputDirectory.Text, "*.JPG")).ToArray();
                    }

                    var converterOptions = new ConverterOptions
                    {
                        Files = arrFiles,
                        OutputDirectory = txtOutputDirectory.Text,
                        Watermark = WmContext
                    };

                    //MessageBox.Show(converterOptions.Files.Length.ToString());

                    pbProgress.Maximum = converterOptions.Files.Length;

                    BwConverter.RunWorkerAsync(converterOptions);

                    lblStatusValue.Text = @"Converting...0% (0/" + pbProgress.Maximum + @") - " + Settings.ImageProcessor;
                }
                else
                {
                    BwConverter.Abort();
                    _isWorking = false;
                    pbProgress.Value = pbProgress.Maximum;
                    SetFormWorking(false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), @"Error whilst converting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (BwConverter.IsBusy)
                {
                    BwConverter.Abort();
                }
            }
        }

        private void btnSelectInputDirectory_Click(object sender, EventArgs e)
        {
            var fbd = new FolderBrowserDialog();
            fbd.Description = @"Where are your CR2 files located?";

            if (fbd.ShowDialog() == DialogResult.OK)
                txtInputDirectory.Text = fbd.SelectedPath;
        }

        private void btnSelectOutputDirectory_Click(object sender, EventArgs e)
        {
            var fbd = new FolderBrowserDialog();
            fbd.Description = @"Where do you want me to put your converted JPEGs?";

            if (fbd.ShowDialog() == DialogResult.OK)
                txtOutputDirectory.Text = fbd.SelectedPath;
        }

        private void bwConverter_DoWork(object sender, DoWorkEventArgs e)
        {
            var converterOptions = e.Argument as ConverterOptions;
            var parallelOptions = GetParallelOptions();

            Parallel.ForEach(converterOptions.Files, parallelOptions, currentFile =>
            {
                Converter.ConvertImage(currentFile, converterOptions.OutputDirectory, Settings);
                BwConverter.ReportProgress(0);
            });
        }

        private void bwConverter_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbProgress.Value += 1;

            decimal progress = pbProgress.Value;
            decimal maximum = pbProgress.Maximum;
            decimal percent = Math.Round((progress / maximum) * 100);

            lblStatusValue.Text = @"Converting..." + percent + @"% (" + pbProgress.Value + @"/" + pbProgress.Maximum + @") - " + Settings.ImageProcessor;
        }

        private void bwConverter_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            SetFormWorking(false);

            MessageBox.Show("Conversion complete!", "CR2 To JPG", MessageBoxButtons.OK, MessageBoxIcon.Information);

            lblStatusValue.Text = "Idle";
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = _isWorking;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            txtInputDirectory.TabStop =
            txtOutputDirectory.TabStop = false;

            lblVersion.Text = "v" + GetBuildInfo(true);
        }

        private ParallelOptions GetParallelOptions()
        {
            return new ParallelOptions
            { MaxDegreeOfParallelism = 2 };
        }

        private void lnkWebsite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://wmwood.net");
        }

        public void SetFormWorking(bool isWorking)
        {
            btnSelectInputDirectory.Enabled = true;
            btnSelectOutputDirectory.Enabled = !isWorking;

            if (isWorking)
            {
                itmOptions.Enabled = false;
                itmProfile.Enabled = false;
                itmCheckUpdates.Enabled = false;
                btnProcess.Text = "Cancel";
            }
            else
            {
                itmOptions.Enabled = true;
                itmProfile.Enabled = true;
                itmCheckUpdates.Enabled = true;
                btnProcess.Text = "Process";
            }

            _isWorking = isWorking;
            pbProgress.Visible = true;
            UseWaitCursor = isWorking;
        }

        private string GetBuildInfo(bool includeDateTime)
        {
            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            DateTime buildDate = new DateTime(2000, 1, 1)
                                    .AddDays(version.Build).AddSeconds(version.Revision * 2);
            string displayableVersion;

            if (includeDateTime)
            {
                displayableVersion = $"{version} ({buildDate})";
            }
            else
            {
                displayableVersion = $"{version}";
            }

            return displayableVersion;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
        }

        private void lnkOptions_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
        }

        private void pbProgress_Click(object sender, EventArgs e)
        {
        }

        private void lblJPEGFolder_Click(object sender, EventArgs e)
        {
        }

        private void txtOutputDirectory_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtInputDirectory_TextChanged(object sender, EventArgs e)
        {
        }

        private void picMain_Click(object sender, EventArgs e)
        {
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("To batch convert your CR2 files, you first need to specify some values.\n" +
               "Firstly, you'll need to click the three dots beside the '" + lblCR2Folder.Text + "' textbox. From there, you'll need to select the folder that your CR2 files are in.\n" +
               "After that, you'll need to click the three dots beside the '" + lblJPEGFolder.Text + "', and select the folder that you want the converted JPEGs to go in.\n" +
               "Hit '" + btnProcess.Text + "' and wait until it's done!", "CR2 To JPG Help", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void optionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmOptions frm = new FrmOptions();
            frm.ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        //https://docs.microsoft.com/en-us/dotnet/standard/security/how-to-sign-xml-documents-with-digital-signatures
        public XmlDocument SignXml(XmlDocument xmlDoc, RSA rsaKey)
        {
            // Check arguments.
            if (xmlDoc == null)
                throw new ArgumentException(nameof(xmlDoc));
            if (rsaKey == null)
                throw new ArgumentException(nameof(rsaKey));

            // Store localised xmlDoc
            XmlDocument doc = xmlDoc;

            // Create a SignedXml object.
            SignedXml signedXml = new SignedXml(doc);

            // Add the key to the SignedXml document.
            signedXml.SigningKey = rsaKey;

            // Create a reference to be signed.
            Reference reference = new Reference();
            reference.Uri = "";

            // Add an enveloped transformation to the reference.
            XmlDsigEnvelopedSignatureTransform env = new XmlDsigEnvelopedSignatureTransform();
            reference.AddTransform(env);

            // Add the reference to the SignedXml object.
            signedXml.AddReference(reference);

            // Compute the signature.
            signedXml.ComputeSignature();

            // Get the XML representation of the signature and save
            // it to an XmlElement object.
            XmlElement xmlDigitalSignature = signedXml.GetXml();

            // Append the element to the XML document.
            doc.DocumentElement.AppendChild(xmlDoc.ImportNode(xmlDigitalSignature, true));

            return doc;
        }

        public void SaveProfile(bool silent)
        {
            if (!Environment.GetCommandLineArgs().Contains("--disable-save"))
            {
                if ((txtInputDirectory.Text != string.Empty) && (txtOutputDirectory.Text != string.Empty))
                {
                    try
                    {
                        SaveFileDialog sfd = new SaveFileDialog();
                        sfd.Filter = "XML Profile|*.prof";

                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            var subReq = new XmlProfile();
                            subReq.Locations = new AppLocations { Cr2Folder = txtInputDirectory.Text, JpgFolder = txtOutputDirectory.Text };
                            subReq.Options = Settings;
                            subReq.Watermark = WmContext;
                            subReq.AppInfo.AppVersion = GetBuildInfo(false);

                            XmlProfile.SaveFile(subReq, sfd.FileName);

                            if (!silent)
                            {
                                MessageBox.Show("Successfully saved profile!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        if (!silent)
                        {
                            MessageBox.Show(ex.ToString(), "Error in saving XML Profile", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    if (!silent)
                    {
                        MessageBox.Show("You need to specify input and output folders before saving a profile", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        //https://docs.microsoft.com/en-us/dotnet/standard/security/how-to-verify-the-digital-signatures-of-xml-documents
        public static bool VerifyXml(XmlDocument xmlDoc, RSA key)
        {
            // Check arguments.
            if (xmlDoc == null)
                throw new ArgumentException("xmlDoc");
            if (key == null)
                throw new ArgumentException("key");

            // Create a new SignedXml object and pass it
            // the XML document class.
            SignedXml signedXml = new SignedXml(xmlDoc);

            // Find the "Signature" node and create a new
            // XmlNodeList object.
            XmlNodeList nodeList = xmlDoc.GetElementsByTagName("Signature");

            // Throw an exception if no signature was found.
            if (nodeList.Count <= 0)
            {
                throw new CryptographicException("Verification failed: No Signature was found in the document.");
            }

            // This example only supports one signature for
            // the entire XML document.  Throw an exception
            // if more than one signature was found.
            if (nodeList.Count >= 2)
            {
                throw new CryptographicException("Verification failed: More that one signature was found for the document.");
            }

            // Load the first <signature> node.
            signedXml.LoadXml((XmlElement)nodeList[0]);

            // Check the signature and return the result.
            return signedXml.CheckSignature(key);
        }

        public int CompareVersion(string compareVersion)
        {
            //Get the version of this build
            string strCurrent = GetBuildInfo(false);

            //MessageBox.Show("XML Version:" + compareVersion + "\nThis Version:" + strCurrent);

            //Turn the versions into workable objects
            Version verCurrent = new Version(strCurrent);
            Version verCompare = new Version(compareVersion);

            //Checks the version difference. >0 verCurrent is greater than verCompare. <0 verCurrent is lower than verCompare.
            int intResult = verCurrent.CompareTo(verCompare);

            return intResult;
        }

        public void LoadProfile(bool silent)
        {
            try
            {
                if (!Environment.GetCommandLineArgs().Contains("--disable-load"))
                {
                    OpenFileDialog ofd = new OpenFileDialog();
                    ofd.Filter = "XML Profile|*.prof";

                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        XmlProfile subReq = XmlProfile.FromFile(ofd.FileName);

                        if (!Environment.GetCommandLineArgs().Contains("--nvc"))
                        {
                            if ((subReq.AppInfo.AppVersion != string.Empty) && (subReq.AppInfo.AppVersion != null))
                            {
                                //Make sure the XML Profile is compatible
                                int compareResult = CompareVersion(subReq.AppInfo.AppVersion);

                                //MessageBox.Show(compareResult.ToString());

                                if (compareResult > 0)
                                {
                                    MessageBox.Show("This profile was saved with an earlier version (" + subReq.AppInfo.AppVersion + ").\nIt may not be compatible with this version of CR2 To JPG. You can still use it, but we can't guarantee its compatibility.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                                else if (compareResult < 0)
                                {
                                    MessageBox.Show("This profile was saved with a later version (" + subReq.AppInfo.AppVersion + ").\nIt may not be compatible with this version of CR2 To JPG. You can still use it, but we can't guarantee its compatibility.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                            }
                            else
                            {
                                MessageBox.Show("We couldn't be certain what version this profile was saved with. You can still use it, but we can't guarantee its compatibility.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }

                        if ((subReq.Options.Quality <= 100) && (subReq.Options.Quality >= 10))
                        {
                            if ((Directory.Exists(subReq.Locations.Cr2Folder)) && (Directory.Exists(subReq.Locations.JpgFolder)))
                            {
                                Settings.Quality = subReq.Options.Quality;
                                Settings.Subfolders = subReq.Options.Subfolders;
                                txtInputDirectory.Text = subReq.Locations.Cr2Folder;
                                txtOutputDirectory.Text = subReq.Locations.JpgFolder;
                                if (subReq.Watermark != null)
                                {
                                    WmContext = subReq.Watermark;
                                }

                                if (!silent)
                                {
                                    MessageBox.Show("Successfully loaded profile!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                MessageBox.Show("One or more profile-defined directories do not exist", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Quality level in profile exceeds defined range: 10.00 - 100.00 (10% - 100%)", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (!silent)
                {
                    MessageBox.Show(ex.ToString(), "Error in loading XML Profile", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void viewInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("CR2 To JPG Converter\n\nBased on technology developed by William Wood (Copyright (c) 2014)\nhttps://github.com/wmwood/CR2ToJPG\n\nDeveloped by BRH Media (Baeleigh Harris)\n\nBuild: " + GetBuildInfo(false) +
                "\nRenderer Build: " + StructureGeneric.GetBuildInfo(false) +
                "\nStructure Build: " + ImageRenderer.GetBuildInfo(false), "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void itmProfileSave_Click(object sender, EventArgs e)
        {
            SaveProfile(false);
        }

        private void itmProfileLoad_Click(object sender, EventArgs e)
        {
            LoadProfile(false);
        }

        private void itmCheckUpdates_Click(object sender, EventArgs e)
        {
            DoCheckUpdate();
        }

        private void DoCheckUpdate()
        {
            if (!Environment.GetCommandLineArgs().Contains("--disable-update"))
            {
                try
                {
                    //AutoUpdater.NET
                    AutoUpdater.Start("https://brharris.me/hostedzone/cr2tojpg/updates/latest.xml");
                }
                catch (Exception ex)
                {
                }
            }
        }

        private void watermarkingWizardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoWatermarkWizard();
        }

        public void DoWatermarkWizard()
        {
            try
            {
                if (!Environment.GetCommandLineArgs().Contains("--disable-wm"))
                {
                    FrmWatermark frm = new FrmWatermark();
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void itmAboutWebsite_Click(object sender, EventArgs e)
        {
            Process.Start("https://brharris.me");
        }
    }
}