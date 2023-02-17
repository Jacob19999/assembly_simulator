using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assembly_simulator_dev
{
    class Registers
    {
        // LegV8 General purpose registers.
        // 2 types of registers:
        // 64-bit double work registers X0 to X30
        // 32-bit double work registers W0 to W30
        // X0-X78  : Argument / Results
        // X8      : Indirect result location register
        // X9-X15  : Temporaries
        // X16-X17 : Linker as scratch register or temporary register
        // X19-X27 : Saved
        // X28     : Stack Pointer
        // X29     : Frame Pointer
        // X30     : Link Register
        // XZR     : Loads Zero
        public Registers()
        {
            Register X0 = new Register();
            Register X1 = new Register();
            Register X2 = new Register();
            Register X3 = new Register();
            Register X4 = new Register();
            Register X5 = new Register();
            Register X6 = new Register();
            Register X7 = new Register();
            Register X8 = new Register();
            Register X9 = new Register();
            Register X10 = new Register();
            Register X11 = new Register();






        }

    }
    class Register
    {


        int[] bytes = new int[8] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

        public Register()
        {

        }

        public void UpdateByte(uint byteIndex, int content)
        {
            if (byteIndex > 7) { throw new ArgumentException("Update byte Index must be 0-7"); }
            bytes[byteIndex] = content;

        }
        public void UpdateSingleWord(uint wordIndex, int[] content)
        {
            uint j = wordIndex * 4;

            if (wordIndex > 1) { throw new ArgumentException("Single word index must be 0-1"); }
            if (content.Length != 4) { throw new ArgumentException("Single word Array can only accept 4 bytes.");  }
               
            for (int i = 0; i < content.Length; i++)
            {
                bytes[i + j] = content[i];
            }
        }
        public void UpdateHalfWord(uint wordIndex, int[] content)
        {
            uint j = wordIndex * 2;
            if (wordIndex > 3) { throw new ArgumentException("Single word index must be 0-3"); }
            if (content.Length != 8) { throw new ArgumentException("Double Word Array can only accept 8 bytes."); }

            for (int i = 0; i < bytes.Length; i++)
            {
                bytes[i + j] = content[i];
            }

        }
        public void UpdateDoubleWord(int[] content)
        {
            if (content.Length != 8) { throw new ArgumentException("Double Word Array can only accept 8 bytes."); }
            
            for (int i = 0; i < bytes.Length; i++)
            {
                bytes[i] = content[i];
            }
        }

        public void PrintRegister()
        {
            Console.Write("|");
            for (int i = 0; i < bytes.Length; i++)
            {
                Console.Write("{0:X2}", bytes[i]);
                Console.Write("|");
            }
            Console.WriteLine("");
        }
        public int[] GetRegisterContent()
        {
            return bytes;
        }


    }
}
