using System;
using LostCaver;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LostCaverTests
{
    [TestClass]
    public class CaverTests
    {
        [TestMethod]
        public void SetExitLocationTo10X15Y()
        {
            // Arrange
            int x = 10;
            int y = 15;
            Guide guide = new Guide(0, 0,'N');

            //set cave exit location
            guide.setXCaveExit(x);
            guide.setYCaveExit(y);

            // Act
            int actualX = guide.getXCaveExit();
            int actualY = guide.getYCaveExit();

            // Assert, expected to be true in both cases
            Assert.AreEqual(x, actualX);
            Assert.AreEqual(y, actualY);
        }
        /*
        [TestMethod]
        public void caverStartXCoordinateEquals3()
        {
            // Arrange
            Caver caver = new Caver();

            // Actual
            int actualX = caver.getX();

            // Assert
            const int expected = 3;
            Assert.AreEqual(expected, actualX);
        }


        [TestMethod]
        public void caverStartYCoordinateEquals4()
        {
            // Arrange
            Caver caver = new Caver();

            // Actual
            int actualY = caver.getY();

            // Assert
            const int expected = 4;
            Assert.AreEqual(expected, actualY);
        }
        */

        [TestMethod]
        public void MoveCaverWorks()
        {
            // Arrange
            Caver caver = new Caver();
            Cave cave = new Cave();
            Control control = new Control();
            int[] startLocation = control.getStartCoordinatesForGuide(caver);
            int xLoc = startLocation[0];
            int yLoc = startLocation[1];
            //create a Guide object, pass in the Cavers coordinates and direction
            Guide guide = new Guide(xLoc, yLoc, caver.getDirection());
            //caver will start at (3, 4) N if startCave.txt is unaltered

            //caver should be at (2, 5) W after these inputted move values
            char[] moves = {'M','M','L','M','L','M','R'};
            /*
            moves[0] = 'M';
            moves[1] = 'M';
            moves[2] = 'L';
            moves[3] = 'M';
            moves[4] = 'L';
            moves[5] = 'M';
            moves[6] = 'R';
             * */
            
            for (int i = 0; i < moves.Length; i++ )
            {
                control.moveCaver(caver, guide, cave, moves[i]);

            }

            // Actual
            const int expectedX = 2;
            const int expectedY = 5;
            const char expectedD = 'W';

            // Assert
            Assert.AreEqual(expectedX, caver.getX());
            Assert.AreEqual(expectedY, caver.getY());
            Assert.AreEqual(expectedD, caver.getDirection());
        }
         
    }
}
