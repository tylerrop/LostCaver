using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LostCaver
{
    //This Control class simply serves as a means to keep the main area of Program as clean as possible
    //This class provides functions for data processing functions, especially the handling of user input
    public class Control
    {
        //used to turn on the GPS device of the user by 
        public void turnOnGPS()
        {
            //turnOn is the user input to turn on their GPS
            string turnOn = "";
            //used as var for first letter of turnOn
            char firstLetter;

            //get the user to turn on their GPS by having them enter the character t || T on its own or first in a string
            do
            {
                Console.WriteLine("Please turn on your specialized GPS device by pressing T");
                turnOn = Console.ReadLine();
                //get only the first character that the user enters, if they enter T first then they have sucessfully turned on the GPS
                turnOn = turnOn.Trim();
                turnOn = turnOn.ToUpper();
                char[] letters = turnOn.ToCharArray();
                firstLetter = letters[0];
            } while (firstLetter != 'T');

            Console.WriteLine("Your GPS device has been turned on!\n");
        }


        //used to gather the starting GPS coordinates from the user
        //intended to make the user fel as if they are sending their coordinates through their GPS device
        //coordinates entered by the user are checked to match their actual coordinates
        public int[] getStartCoordinatesForGuide(Caver caver)
        {    
            //get user to enter in first gps units, make sure they're right
            Console.WriteLine("Your current GPS coordinates in the cave are: (" + caver.getX() + ", " + caver.getY() + ") " + caver.getDirection());
            Console.ReadLine();
            Console.WriteLine("Please enter your current GPS coordinates  in the format (x, y) D to radio them to your Guide.");
            Console.WriteLine("(D is the direction that you are facing)");
            string actualCoordinates = "(" + caver.getX() + ", " + caver.getY() + ") " + caver.getDirection();
            string inputGPS = Console.ReadLine();
            inputGPS = inputGPS.Trim();

            //check and see if the entered coordinates match the actual coordinates of the Caver
            while (inputGPS != actualCoordinates)
            {
                Console.WriteLine("Please re-enter your coordinates correctly in the format (x, y) D");
                Console.WriteLine("(D is the direction that you are facing)");
                inputGPS = Console.ReadLine();
            }

            //remove the brackets and direction, direction will simply be passed from the Caver object
            inputGPS = inputGPS.Replace("(", "");
            inputGPS = inputGPS.Replace(")", "");
            inputGPS = inputGPS.Remove(inputGPS.Length - 1);

            //split up the inputGPS string to seperate the coordinates and cast them into ints
            string[] tokens = inputGPS.Split(',');
            int[] radio = new int[2];
            radio = Array.ConvertAll<string, int>(tokens, int.Parse);

            return radio;
        }


        //used for user mmovement 
        public void moveCaver(Caver caver, Guide guide, Cave cave, char letterOne)
        {
            //move is the user input for their movement
            //string move;
            //used as var for first letter of move string
           

            //Console.WriteLine("You chose to:" + letterOne);

            //determine user movement choice, apply appropriate actions
            switch (letterOne)
            {
                case 'M':
                    //case M moves the user based on their orientation
                    //caver moves North
                    if (caver.getDirection() == 'N')
                    {
                        int caverCurrY = caver.getY();
                        caver.setY(caverCurrY + 1);
                        guide.setYGPS(caverCurrY + 1);
                        Console.WriteLine("You have moved North 1 step");
                        //check if outside boundaries, if caver is outside any boundary the caver will be killed
                        checkBoundaries(caver, cave);
                    }

                    //caver moves East
                    else if (caver.getDirection() == 'E')
                    {
                        int caverCurrX = caver.getX();
                        caver.setX(caverCurrX + 1);
                        guide.setXGPS(caverCurrX + 1);
                        Console.WriteLine("You have moved East 1 step");
                        //check if outside boundaries, if caver is outside any boundary the caver will be killed
                        checkBoundaries(caver, cave);

                    }

                    //caver moves South
                    else if (caver.getDirection() == 'S')
                    {
                        int caverCurrY = caver.getY();
                        caver.setY(caverCurrY - 1);
                        guide.setYGPS(caverCurrY - 1);
                        Console.WriteLine("You have moved South 1 step");
                        //check if outside boundaries, if caver is outside any boundary the caver will be killed
                        checkBoundaries(caver, cave);

                    }

                    //caver moves West
                    else if (caver.getDirection() == 'W')
                    {
                        int caverCurrX = caver.getX();
                        caver.setX(caverCurrX - 1);
                        guide.setXGPS(caverCurrX - 1);
                        Console.WriteLine("You have moved West 1 step");
                        //check if outside boundaries, if caver is outside any boundary the caver will be killed
                        checkBoundaries(caver, cave);
                    }
                    
                    break;
                

                case 'L':
                    //caver wants to turn to their current Left in this case
                    //turn caver West if they are facing North
                    if (caver.getDirection() == 'N')
                    {
                        caver.setDirection('W');
                    }
                    //turn caver North if they are facing East                  
                    else if (caver.getDirection() == 'E')
                    {
                        caver.setDirection('N');
                    }
                    //turn caver East if they are facing South
                    else if (caver.getDirection() == 'S')
                    {
                        caver.setDirection('E');
                    }
                    //turn caver South if they are facing West                    
                    else if (caver.getDirection() == 'W')
                    {
                        caver.setDirection('S');
                    }

                    break;
                

                case 'R':
                    //caver wants to turn to their current Right in this case
                    //turn caver East if they are facing North
                    if (caver.getDirection() == 'N')
                    {
                        caver.setDirection('E');
                    }
                    //turn caver South if they are facing East                  
                    else if (caver.getDirection() == 'E')
                    {
                        caver.setDirection('S');
                    }
                    //turn caver West if they are facing South
                    else if (caver.getDirection() == 'S')
                    {
                        caver.setDirection('W');
                    }
                    //turn caver North if they are facing West                    
                    else if (caver.getDirection() == 'W')
                    {
                        caver.setDirection('N');
                    }
                    break;
            //----------------------end of switch
            }

            Console.WriteLine("Your current GPS location is: (" + caver.getX() + ", " + caver.getY() + ") " + caver.getDirection());
        }


        //used when moving the caver to check and see if they have moved outside of the boundaries of the cave
        //if the caver is outside of the boundaries then they are "killed"
        public void checkBoundaries(Caver caver, Cave cave)
        {
            //check if outside boundaries, if caver is outside any boundary the caver will be killed
            if ((caver.getY() > cave.getHeight()) || (caver.getY() < 0) || (caver.getX() > cave.getWidth()) || (caver.getX() < 0))
            {
                caver.setAlive(false);
                Console.WriteLine(Messages.deadCaverMessage());
                //Suspend console
                Console.ReadLine();
            }
        }

        //--------------------------end of Control class
    }
}
