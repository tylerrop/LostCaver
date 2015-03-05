using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LostCaver
{
    class Program
    {
        static void Main(string[] args)
        {
            //instantiate Caver, Cave, and Control objects
            Caver caver = new Caver();
            Cave cave = new Cave();
            Control control = new Control();
            
            //inform user that they are lost in the cave
            Console.WriteLine(Messages.startUpMessage());
            // Suspend the screen
            Console.ReadLine();

            //ensure that the Caver is alive so that the game can continue
            if (caver.getAlive() == true)
            {
                //get user to turn on their GPS device so that they can be found
                control.turnOnGPS();

                //get the user to enter their starting GPS coordinates
                //user is told of their starting point
                //concept is to similate them radioing the Guide with their location
                int[] startLocation = control.getStartCoordinatesForGuide(caver);
                int xLoc = startLocation[0];
                int yLoc = startLocation[1];
                //create a Guide object, pass in the Cavers coordinates and direction
                Guide guide = new Guide(xLoc, yLoc, caver.getDirection());
                //notify user that the Guide has recieved their GPS coordinates
                Console.WriteLine("The Guide has recieved your GPS coordinates sucessfully!");
                // Suspend the screen.
                Console.ReadLine();


                //loop below code until game ends
                //continue to loop is the caver is alive, and their location is no the cave exit
                //while ( (caver.getAlive() == true) && (caver.getX() != guide.getXCaveExit()) && (caver.getY() != guide.getYCaveExit()) )
                while (caver.getAlive() == true)
                {
                    //se if the caver is on the cave exit now, if they are notify them and break loop to end game, otherwise take their next move
                    if( (caver.getX() == guide.getXCaveExit()) && (caver.getY() == guide.getYCaveExit()) )
                    {
                        Console.WriteLine("Congratulations, you successfully made it out of the cave alive!\nEnjoy the sunlight.");
                        Console.ReadLine();
                        break;
                    }

                    else
                    {
                        //send reccommendations from Guide to Caver
                        guide.navigationInstructions(cave);
                        
                        // Suspend the screen.
                        Console.ReadLine();
                        //-----------------------------------------------------
                        //move is the user input for their movement
                        //string move;
                        //used as var for first letter of move string
                        char letterOne;

                        //get user moves
                        //get the user to indicate which way the would like to move
                        //M for move forward
                        //L for turn left
                        //R for turn right
                        string move;
                        do
                        {
                            move = "";

                            //tell user their movement options
                            Console.WriteLine(Messages.movmentOptionsMessage());
                            move = Console.ReadLine();
                            //get only the first character that the user enters 
                            move = move.Trim();
                            move = move.ToUpper();
                            char[] moveLetters = move.ToCharArray();
                            letterOne = moveLetters[0];
                            //user must enter M (move), L (left turn), or R (right turn)
                        } while ((letterOne != 'M') && (letterOne != 'L') && (letterOne != 'R'));

                        control.moveCaver(caver, guide, cave, letterOne);
                    }
                }
            }

            //Caver is not alive
            else
            {
                //death message displayed to user
                Console.WriteLine(Messages.deadCaverMessage());
            }



        }


        
       


    }
}
