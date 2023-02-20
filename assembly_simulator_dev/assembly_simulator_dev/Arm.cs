using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assembly_simulator_dev
{
    class Arm
    {
        public Register[] registers { get; set; }

        public Arm()
        {

            createRegisters();




        }

        public void createRegisters()
        {
            // Create all registers
            registers = new Register[32];

            for (int i = 0; i < 32; i++)
            {
                Register register_ = new Register();
                registers[i] = register_;
            }
            registers[31].setReadOnlyRegister();





        }




    }
}
