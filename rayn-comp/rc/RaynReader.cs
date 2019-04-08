using System;
using System.Text;

namespace rayn_comp.rc
{
    public class RaynReader
    {
        private readonly byte[] _buffer;
        private readonly UTF8Encoding _encoding;


        public RaynReader(byte[] buffer)
        {
            _buffer = buffer;
            _encoding = new UTF8Encoding();
        }

        public int BytesRead { get; private set; }


        public int readInt(int index)
        {
            BytesRead += 4;
            return BitConverter.ToInt32(_buffer, index);
        }

        public char readChar(int index)
        {
            BytesRead += 1;
            return BitConverter.ToChar(_buffer, index);
        }

        public byte readByte(int index)
        {
            BytesRead += 1;
            return _buffer[index];
        }

        public string ReadString(int index, int length)
        {
            BytesRead += length;
            return _encoding.GetString(_buffer, index, length);
        }
    }
}