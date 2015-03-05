using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LostCaver
{
    public class Guide
    {
        //data for a Guide object
        int xGPS;          //xGPS   - horizontal location of the Caver, as known by the Guide
        int yGPS;          //yGPS   - vertical location of the Caver, as known by the Guide
        char dirGPS;       //dirGPS - direction that the caver is facing, as known by the Guide
        int xCaveExit;     //caveExitX - horizontal coordinate of the cave exit, read in from caveExit.txt file
        int yCaveExit;     //caveExitX - vertical coordinate of the cave exit, read in from caveExit.txt file

        //Guide constructor
        public Guide(int xCaver, int yCaver, char dirCaver)
	    {
            //get cave exit location from caveExit.txt, pass into vars
            int[] exitCoordinates = getCaveExitLocation();
            int xCE = exitCoordinates[0];
            int yCE = exitCoordinates[1];

            //set Guide data. 
            //xGPS, yGPS, and dirGPS are passed in by the user upon Guide object instantiation
            //xCaveExit and yCaveExit are read in from the caveExit.txt file
            this.xGPS = xCaver;         //Caver x location
            this.yGPS = yCaver;         //Caver y location
            this.dirGPS = dirCaver;
            this.xCaveExit = xCE;       //read in cave x location
            this.yCaveExit = yCE;       //read in cave y location
        }

        public void setXGPS(int setX)
        {
            xGPS = setX;
        }

        public int getXGPS()
        {
            return xGPS;
        }

        public void setYGPS(int setY)
        {
            yGPS = setY;
        }

        public int getYGPS()
        {
            return yGPS;
        }

        public void setDirectionGPS(char direction)
        {
            dirGPS = direction;
        }

        public char getDirectionGPS()
        {
            return dirGPS;
        }

        public void setXCaveExit(int setX)
         {
            xCaveExit = setX;
        }

        public int getXCaveExit()
        {
            return xCaveExit;
        }

        public void setYCaveExit(int setY)
        {
            yCaveExit = setY;
        }

        public int getYCaveExit()
        {
            return yCaveExit;
        }


        //reads the exit location for the Cave from the caveExit.txt file and provides it to the Guide 
        //when called in the Guide Constructor
        public int[] getCaveExitLocation()
        {
            int[] ret = new int[2];   //array of cave exit location (as numbers) to return, one slot for x and one for y

            //see if file exists - want to get Cave Exit start data
            //caveExit.txt located in  /bin/Debug
            bool exists = File.Exists("caveExit.txt");
            if (exists == true)
            {
                // Read the file and display it line by line.
                System.IO.StreamReader file = new System.IO.StreamReader("caveExit.txt");
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
                Console.WriteLine("Could not find the exit location coordinates for the Cave in /bin/Debug/data");
                //provide data make the Cave exit at 20, 4 (width, height) if data was was not found
                ret[0] = 20;
                ret[1] = 4;

                // Suspend the screen.
                Console.ReadLine();

                return ret;
            }
        }


        //instructions sent to Caver
        public void navigationInstructions(Cave cave)
        {
            int caveWidth = cave.getWidth();
            int caveHeight = cave.getHeight();
            //caveExitX Y

            int caveX = getXCaveExit();
            int caveY = getYCaveExit();

            int userX = getXGPS();
            int userY = getYGPS();

            Console.WriteLine("Your Guide says:\n");

            //check to see if the cave is to the users right or left and provid a recommendation
            if (caveX - userX == 0)
            {
                Console.WriteLine("Do not move East or West");
            }
            else if (caveX - userX > 0)
            {
                Console.WriteLine("You should move East");
            }
            else if (caveX - userX < 0)
            {
                Console.WriteLine("You should move West");
            }


            //check to see if the cave is above or below the user and provid a recommendation
            if (caveY - userY == 0)
            {
                Console.WriteLine("Do not move North or South");
            }
            else if (caveY - userY > 0)
            {
                Console.WriteLine("You should move North");
            }
            else if (caveY - userY < 0)
            {
                Console.WriteLine("You should move South");
            }
        }
        //-----------------------------------------------------------------------------
        //End of Guide class
    }
}
