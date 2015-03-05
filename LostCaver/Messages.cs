using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostCaver
{
    public static class Messages
    {
        //Message used to inform the user of their current situation at the start of the game
        public static string startUpMessage()
        {
            string message = "(Game start up data loaded sucessfully)\n";
            message += "You are lost in a cave, your LED flashlight ran out of batteries and you don't know how to get out, oh no!\n";
            message += "Thankfully your friend on the surface has a GPS radio that can communicate with you, they're going to try and lead you to safety.\n";
            return message;
        }

        //Message used to inform the user that the caver is dead and that the game is over
        public static string deadCaverMessage()
        {
            string message = "You are dead.\nGame Over.";
            return message;
        }

        //Message used to inform the user about their possible movement choices
        public static string movmentOptionsMessage()
        {
            string message = "Please make a move now\n";
            message += "Press M to move forward in your current direction\n";
            message += "Or press L to turn Left 90 degrees\n";
            message += "Or press R to turn Right 90 degrees";
            return message;
        }



    }

    
}
