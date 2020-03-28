using System;
using System.IO;
using System.Runtime.Remoting;

namespace CR2ToJPG.Common
{
    internal class PartialStream : Stream
    {
        private FileStream _mF;

        private int _mLength;

        private uint _mStart;

        internal PartialStream(FileStream pF, uint pStart, int pLength)
        {
            _mF = pF;
            _mStart = pStart;
            _mLength = pLength;

            _mF.Seek(pStart, SeekOrigin.Begin);
            GC.Collect();
        }

        public override bool CanRead
        {
            get { return _mF.CanRead; }
        }

        public override bool CanSeek
        {
            get { return _mF.CanSeek; }
        }

        public override bool CanTimeout
        {
            get { return _mF.CanTimeout; }
        }

        public override bool CanWrite
        {
            get { return _mF.CanWrite; }
        }

        public override long Length
        {
            get { return _mLength; }
        }

        public override long Position
        {
            get { return _mF.Position - _mStart; }
            set { _mF.Position = value + _mStart; }
        }

        public override int ReadTimeout
        {
            get { return _mF.ReadTimeout; }
            set { _mF.ReadTimeout = value; }
        }

        public override int WriteTimeout
        {
            get { return _mF.WriteTimeout; }
            set { _mF.WriteTimeout = value; }
        }

        public override IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
        {
            return _mF.BeginRead(buffer, offset, count, callback, state);
        }

        public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
        {
            return _mF.BeginWrite(buffer, offset, count, callback, state);
        }

        public override void Close()
        {
            _mF.Close();
        }

        public override ObjRef CreateObjRef(Type requestedType)
        {
            return _mF.CreateObjRef(requestedType);
        }

        public override int EndRead(IAsyncResult asyncResult)
        {
            return _mF.EndRead(asyncResult);
        }

        public override void EndWrite(IAsyncResult asyncResult)
        {
            _mF.EndWrite(asyncResult);
        }

        public override bool Equals(object obj)
        {
            return _mF.Equals(obj);
        }

        public override void Flush()
        {
            _mF.Flush();
        }

        public override int GetHashCode()
        {
            return _mF.GetHashCode();
        }

        public override object InitializeLifetimeService()
        {
            return _mF.InitializeLifetimeService();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            long maxRead = Length - Position;
            return _mF.Read(buffer, offset, (count <= maxRead) ? count : (int)maxRead);
        }

        public override int ReadByte()
        {
            if (Position < Length)
                return _mF.ReadByte();
            return 0;
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return _mF.Seek(offset + _mStart, origin);
        }

        public override void SetLength(long value)
        {
            _mF.SetLength(value);
        }

        public override string ToString()
        {
            return _mF.ToString();
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            _mF.Write(buffer, offset, count);
        }

        public override void WriteByte(byte value)
        {
            _mF.WriteByte(value);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}