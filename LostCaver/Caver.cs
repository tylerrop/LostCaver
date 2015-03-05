using System;
using System.IO;
namespace LostCaver
{
    public class Caver
    {
        //class is public to allow testing from LostCaverTests
        //data for a Caver object
        bool alive;     //living state of the Caver
        int x;          //x - horizontal location of the Caver
        int y;          //y - vertical location of the Caver
        char dir;       //direction that the caver is facing

        //Caver constructor
        public Caver()
        {
            //get caver start data from txt file and apply it
            string s = getCaverStartData();
            string[] characters = s.Split(',');

            string xLocation = characters[0];
            int xLocationI = int.Parse(xLocation);

            string yLocation = characters[1];
            int yLocationI = int.Parse(yLocation);

            string dirString = characters[2];
            char dirStringI = char.Parse(dirString);

            this.alive = true; //Caver is alive by default
            this.x = xLocationI;
            this.y = yLocationI;
            this.dir = dirStringI;
        }


        public void setAlive(bool b)
        {
            alive = b;
        }

        public bool getAlive()
        {
            return alive;
        }

        public void setX(int setX)
        {
            x = setX;
        }

        public int getX()
        {
            return x;
        }

        public void setY(int setY)
        {
            y = setY;
        }

        public int getY()
        {
            return y;
        }

        public void setDirection(char direction)
        {
            dir = direction;
        }

        public char getDirection()
        {
            return dir;
        }


        //reads the start location of the lost Caver from the txt file and sets it for the Caver when called in the Caver Constructor
        public string getCaverStartData()
        {
            string line; //line read from file
            string ret;  //string to return

            //see if file exists - want to get Caver start data
            //caverStart.txt located in  /bin/Debug
            bool exists = File.Exists("caverStart.txt");
            if (exists == true)
            {
                ret = "";
                // Read the file and display it line by line.
                //Made as a loop in case of future needs.
                System.IO.StreamReader file = new System.IO.StreamReader("caverStart.txt");
                while ((line = file.ReadLine()) != null)
                {
                    //Console.WriteLine(line);
                    ret += line;
                }
                file.Close();

                // Suspend the screen.
                //Console.ReadLine();

                return ret;
            }

            else
            {
                Console.WriteLine("Could not find the starting location data for the Caver in /bin/Debug/data");
                //provide data place the Caver in the bottom corner of the cave and face them North if the file for the Caver was not found
                ret = "0,0,N";

                // Suspend the screen.
                //Console.ReadLine();

                return ret;
            }
        }


    }
    //end of class caver-----------------------------

}