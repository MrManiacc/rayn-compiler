using System;

namespace rayn_comp.rc.structs
{
    public class Head
    {
        private readonly RaynReader _reader;
        private readonly RaynWriter _writer;

        public Head(RaynWriter writer)
        {
            _writer = writer;
        }

        public Head(RaynReader reader)
        {
            _reader = reader;
        }


        public double Version { get; private set; }
        public string Name { get; private set; }
        public int Length { get; private set; }

        public void Read(int offset = 0)
        {
            if (_reader != null)
            {
                Name = _reader.ReadString(0, 4);
                var major = _reader.readByte(offset + 4);
                var minor = _reader.readByte(offset + 5);
                Version = double.Parse(major + "." + minor);
                Length = _reader.BytesRead - offset;
            }
            else
            {
                throw new RaynCompilationException();
            }
        }

        public void Write(string name, double version)
        {
            if (_writer != null)
            {
                var chars = name.ToCharArray();
                _writer.WriteChar(chars[0]);
                _writer.WriteChar(chars[1]);
                _writer.WriteChar(chars[2]);
                _writer.WriteChar(chars[3]);
                var major = (byte) Math.Truncate(version);
                var minor = (byte) ((version - Math.Truncate(version)) * 10);
                _writer.WriteByte(major);
                _writer.WriteByte(minor);
            }
            else
            {
                throw new RaynCompilationException();
            }
        }


        public override string ToString()
        {
            return "Head: [" + $"{nameof(Version)}: {Version}, {nameof(Name)}: {Name}, {nameof(Length)}: {Length}" +
                   "]";
        }
    }
}