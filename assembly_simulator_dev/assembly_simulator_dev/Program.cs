using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assembly_simulator_dev
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var X0 = new Register();
            var X1 = new Register();
            var X2 = new Register();
            var X3 = new Register();

            X1.UpdateSingleWord(0, new int[] { 0xff, 0x15, 0xe6, 0xc2 });
            X1.PrintRegister();

        }
    }
}

