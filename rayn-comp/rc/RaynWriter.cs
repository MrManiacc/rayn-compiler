using System;
using System.Text;

namespace rayn_comp.rc
{
    public class RaynWriter
    {
        private readonly UTF8Encoding _encoding;
        private int _currentPointer;

        public RaynWriter(int bufferSize)
        {
            Data = new byte[bufferSize];
            _encoding = new UTF8Encoding();
        }

        public int BytesWritten { get; private set; }

        public byte[] Data { get; }

        public void WriteInt(int data)
        {
            var intBytes = BitConverter.GetBytes(data);
            Data[_currentPointer++] = intBytes[0];
            Data[_currentPointer++] = intBytes[1];
            Data[_currentPointer++] = intBytes[2];
            Data[_currentPointer++] = intBytes[3];
            BytesWritten += 4;
        }

        public void WriteFloat(float data)
        {
            var floatBuffer = BitConverter.GetBytes(data);
            Data[_currentPointer++] = floatBuffer[0];
            Data[_currentPointer++] = floatBuffer[1];
            Data[_currentPointer++] = floatBuffer[2];
            Data[_currentPointer++] = floatBuffer[3];
            BytesWritten += 4;
        }

        public void WriteDouble(double data)
        {
            var floatBuffer = BitConverter.GetBytes(data);
            Data[_currentPointer++] = floatBuffer[0];
            Data[_currentPointer++] = floatBuffer[1];
            Data[_currentPointer++] = floatBuffer[2];
            Data[_currentPointer++] = floatBuffer[3];
            Data[_currentPointer++] = floatBuffer[4];
            Data[_currentPointer++] = floatBuffer[5];
            Data[_currentPointer++] = floatBuffer[6];
            Data[_currentPointer++] = floatBuffer[7];
            BytesWritten += 8;
        }

        public void WriteShort(short data)
        {
            var floatBuffer = BitConverter.GetBytes(data);
            Data[_currentPointer++] = floatBuffer[0];
            Data[_currentPointer++] = floatBuffer[1];
            BytesWritten += 2;
        }

        public void WriteChar(char data)
        {
            var floatBuffer = BitConverter.GetBytes(data);
            Data[_currentPointer++] = floatBuffer[0];
            BytesWritten += 1;
        }

        public void WriteBoolean(bool data)
        {
            var floatBuffer = BitConverter.GetBytes(data);
            Data[_currentPointer++] = floatBuffer[0];
            BytesWritten += 1;
        }

        public void WriteByteArray(byte[] data)
        {
            Buffer.BlockCopy(data, 0, Data, _currentPointer, data.Length);
            _currentPointer += data.Length;
            BytesWritten += data.Length;
        }

        public void WriteByte(byte data)
        {
            Data[_currentPointer++] = data;
            BytesWritten += 1;
        }

        public void WriteString(string data)
        {
            _encoding.GetBytes(data, 0, data.Length, Data, _currentPointer++);
            BytesWritten += data.Length;
        }

        public override string ToString()
        {
            var sb = new StringBuilder(Data.Length * 2);
            sb.AppendLine("Bytes written: " + BytesWritten);
            for (var i = 0; i < BytesWritten; i++)
            {
                var current = Data[i];
                {
                    sb.AppendFormat("{0:x2}", current);
                    sb.Append(" ");
                }
            }

            return sb.ToString();
        }
    }
}