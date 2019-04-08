using System.Collections.Generic;
using rayn_comp.rc.structs;

namespace rayn_comp.rc
{
    public class RaynCompiler
    {
        private readonly Head _head;
        private readonly RaynReader _raynReader;
        private readonly RaynWriter _raynWriter;

        public RaynCompiler(int bufferSize)
        {
            _raynWriter = new RaynWriter(bufferSize);
            _head = new Head(_raynWriter);
        }

        public RaynCompiler(byte[] buffer)
        {
            _raynReader = new RaynReader(buffer);
            _head = new Head(_raynReader);
        }

        public void WriteHead()
        {
            _head.Write("RAYN", Program.Version);
        }

        public Head ReadHead()
        {
            _head.Read();
            return _head;
        }

        public void WriteGTable(IEnumerable<GlobalRef> globals)
        {
            foreach (var gRef in globals)
            {
                _raynWriter.WriteByteArray(gRef.Id); //Write the function/variable identifier
                _raynWriter.WriteInt(gRef.Offset); //Write the offset to where method/function actually is in memory
            }
        }

        public List<GlobalRef> ReadGTable()
        {
            var refs = new List<GlobalRef>();

            return null;
        }

        public byte[] GetBuffer()
        {
            return _raynWriter.Data;
        }


        public override string ToString()
        {
            return _raynWriter.ToString();
        }
    }
}