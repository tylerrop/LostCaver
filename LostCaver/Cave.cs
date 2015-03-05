using System;
using System.IO;

namespace LostCaver
{
    public class Cave
    {
        int width;          //horizontal grid size
        int height;         //vertical grid sizer

        //Cave constructor
        public Cave()
        {
            //get cave dimensions from txt file and apply them
            int[] dimensions = getCaveStartDimensions();
            int w = dimensions[0];
            int h = dimensions[1];
            this.width = w;
            this.height = h;
        }

        public void setWidth(int w)
        {
            width = w;
        }

        public int getWidth()
        {
            return width;
        }

        public void setHeight(int h)
        {
            height = h;
        }

        public int getHeight()
        {
            return height;
        }

        //reads the start location of the lost Caver from the caveDimensions.txt file and sets it for the Cave 
        //when called in the Cave Constructor
        public int[] getCaveStartDimensions()
        {
            int[] ret = new int[2];   //array of dimension numbers to return, one slot for width and onr for height

            //see if file exists - want to get Cave start data
            //caverStart.txt located in  /bin/Debug
            bool exists = File.Exists("caveDimensions.txt");
            if (exists == true)
            {
                // Read the file and display it line by line.
                System.IO.StreamReader file = new System.IO.StreamReader("caveDimensions.txt");
                String chop = file.ReadLine();
                //Console.WriteLine(chop);
                string[] tokens = chop.Split(',');
                ret = Array.ConvertAll<string, int>(tokens, int.Parse);
                
                file.Close();

                // Suspend the screen.
                //Console.ReadLine();

                return ret;
            }

            else
            {
                Console.WriteLine("Could not find the data for the Cave dimensions in /bin/Debug/data");
                //provide data to make the Cave grid 20x16 if the file for the Caver was not found
                ret[0] = 20;
                ret[1] = 16;

                // Suspend the screen.
                Console.ReadLine();

                return ret;
            }
        }
        //-----------------------------------------------------------------------------
        //End of Cave class
    }
}
