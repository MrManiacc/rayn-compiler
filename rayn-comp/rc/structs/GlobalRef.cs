using System;
using System.Text;

namespace rayn_comp.rc.structs
{
    public class GlobalRef
    {
        private readonly UTF8Encoding _encoding = new UTF8Encoding();
        private string _name;
        private RaynReader _reader;
        private bool _type;


        public GlobalRef(RaynReader reader)
        {
            Id = GetUuid();
        }

        public GlobalRef(RaynWriter writer)
        {
            Id = GetUuid();
        }


        public int Offset { get; }

        public byte[] Id { get; }


        private byte[] GetUuid()
        {
            var bytes = new byte[sizeof(byte) + sizeof(short) + _name.Length];
            bytes[0] = BitConverter.GetBytes(_type)[0];
            var nameLength = BitConverter.GetBytes(_name.Length);
            bytes[1] = nameLength[0];
            bytes[2] = nameLength[1];
            _encoding.GetBytes(_name, 0, _name.Length, bytes, 3);
            return bytes;
        }


        public override string ToString()
        {
            var sb = new StringBuilder(Id.Length * 2);
            sb.AppendLine(_name + " wrote: " + Id.Length);
            foreach (var current in Id)
            {
                sb.AppendFormat("{0:x2}", current);
                sb.Append(" ");
            }

            return sb.ToString();
        }
    }
}