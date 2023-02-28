using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assembly_simulator_dev
{
    class Memory {

        int[] bytes = new int[8] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
        

        public Memory(int sizeOfMemory)
        {
            int romSize = 0;
            int memorySize = sizeOfMemory;

            MemoryCell[] MemoryCells = new MemoryCell[memorySize];


            for (int i = 0; i < memorySize; i++)
            {
                MemoryCells[i] = new MemoryCell();
                MemoryCells[i].setMemAddress(i);
                MemoryCells[i].printAddress();

            }


        }

    }
    class MemoryCell
    {

        public MemoryCell()
        {


        }


        int[] bytes = new int[8] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
        int[] address = new int[8] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

        bool realOnly = false;

        public void setROM()
        {
            realOnly = true;
        }

        public void setMemAddress(int position)
        {
            string hexStr = position.ToString("X");  // Gives you hexadecimal
            Console.Write(hexStr + " ");
            int j = 0;

            if (hexStr.Length == 2)
            {
                address[0] = int.Parse(hexStr.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
                hexStr.Remove(0, 2);

            }
            else if (hexStr.Length > 2)
            {
                for (int i = 0; i < hexStr.Length ; i++)
                {
                    address[j] = int.Parse(hexStr.Substring(i, 2), System.Globalization.NumberStyles.HexNumber);
                    hexStr = hexStr.Remove(i, 2);

                    i = i + 1;
                    j = j + 1;

                    if (hexStr.Length == 1)
                    {
                        hexStr = "0" + hexStr;
                        address[j] = int.Parse(hexStr.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
                    }
                }
            }
            else if (hexStr.Length == 1) {
                
                hexStr = "0" + hexStr;
                address[j] = int.Parse(hexStr.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
            }

        }

        public void updateByte(uint byteIndex, int content)
        {
            if (realOnly == false)
            {

                if (byteIndex > 7) { throw new ArgumentException("Update byte Index must be 0-7"); }
                bytes[byteIndex] = content;
            }

        }
        public void updateSingleWord(uint wordIndex, int[] content)
        {
            if (realOnly == false)
            {
                uint j = wordIndex * 4;

                if (wordIndex > 1) { throw new ArgumentException("Single word index must be 0-1"); }
                if (content.Length != 4) { throw new ArgumentException("Single word Array can only accept 4 bytes."); }

                for (int i = 0; i < content.Length; i++)
                {
                    bytes[i + j] = content[i];
                }
            }
        }
        public void updateHalfWord(uint wordIndex, int[] content)
        {
            if (realOnly == false)
            {
                uint j = wordIndex * 2;
                if (wordIndex > 3) { throw new ArgumentException("Single word index must be 0-3"); }
                if (content.Length != 8) { throw new ArgumentException("Double Word Array can only accept 8 bytes."); }

                for (int i = 0; i < bytes.Length; i++)
                {
                    bytes[i + j] = content[i];
                }
            }

        }
        public void updateDoubleWord(int[] content)
        {
            if (realOnly == false)
            {
                if (content.Length != 8) { throw new ArgumentException("Double Word Array can only accept 8 bytes."); }

                for (int i = 0; i < bytes.Length; i++)
                {
                    bytes[i] = content[i];
                }
            }

        }

        public void printContents()
        {
            Console.Write("|");
            for (int i = 0; i < bytes.Length; i++)
            {
                Console.Write("{0:X2}", bytes[i]);
                Console.Write("|");
            }
            Console.WriteLine("");
        }

        public void printAddress()
        {
            Console.Write("Address : ");
            Console.Write("|");
            for (int i = 0; i < address.Length; i++)
            {
                Console.Write("{0:X2}", address[i]);
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
