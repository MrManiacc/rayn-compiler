using System;
using rayn_comp.rc;

namespace rayn_comp
{
    internal static class Program
    {
        public const double Version = 1.0;

        public static void Main()
        {
            var buffer = testWrite();
            testRead(buffer);
        }

        private static byte[] testWrite()
        {
            var compiler = new RaynCompiler(1024);

            //Test writing to head
            compiler.WriteHead();

            //Test writing to globals table


            //Return buffer written to
            return compiler.GetBuffer();
        }

        private static void testRead(byte[] buffer)
        {
            var compiler = new RaynCompiler(buffer);

            //Test reading the head
            var head = compiler.ReadHead();
            Console.WriteLine(head);
            //Test reading the globals table
            // var refs = new List<GlobalRef>
        }
    }
}