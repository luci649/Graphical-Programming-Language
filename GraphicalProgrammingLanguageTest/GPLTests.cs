using GraphicalProgrammingLanguage;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;
using static System.Net.Mime.MediaTypeNames;

namespace GraphicalProgrammingLanguageTest
{
    [TestClass]
    public class GPLTestS1 
    {      
        /// <summary>
        /// Testing drawto command by checking the position of a pen after being used.
        /// </summary>
        [TestMethod]
        public void TestDrawLineCommand()
        {
            //Arrange
            Canvas test = new Canvas();
            
            //Act 
            test.DrawLine(20,24);
            
            // Arrange
            int x = test.Xpos;
            int y = test.Ypos;

            //Assert
            Assert.AreEqual(20,x);
            Assert.AreEqual(24,y);
            Assert.AreNotEqual(24,x);
            Assert.AreNotEqual(20,y);
        }

        /// <summary>
        /// Testing moveto command by checking the position of a pen after being used.
        /// </summary>
        [TestMethod]
        public void TestMoveToCommand() 
        {
            //Arrange
            Canvas test = new Canvas();
            
            //Act 
            test.MoveTo(60,34);
            
            // Arrange
            int x = test.Xpos;
            int y = test.Ypos; 
            
            //Assert
            Assert.AreEqual(60,x);
            Assert.AreNotEqual(60,y);
            Assert.AreEqual(34,y);
            Assert.AreNotEqual(34,x);
        }

        /// <summary>
        /// Testing reset command by checking the position of a pen after being used.
        /// </summary>
        [TestMethod]
        public void TestRestCommand() 
        {
            //Arrange
            Canvas test = new Canvas();
            
            //Act
            test.MoveTo(40,50);
            test.Reset();
            
            //Arrange
            int x = test.Xpos;
            int y = test.Ypos;
            
            //Assert
            Assert.AreEqual(0,x);
            Assert.AreEqual(0,y);
            Assert.AreNotEqual(40,x);
            Assert.AreNotEqual(50,y);
        }

        /// <summary>
        /// Testing commands being entered into the command line then checking the pen position.
        /// </summary>
        [TestMethod]
        public void TestCommandLineRun() 
        {
            //Arrange
            Canvas test = new();
            Parser p = new(test);

            //Act
            p.CommandParser("moveto 23,53");
            p.CommandParser("drawto 50,35");
            p.CommandParser("reset");

            //Arrange
            int x = test.Xpos;
            int y = test.Ypos;

            //Assert
            Assert.AreEqual(0, x);
            Assert.AreEqual(0, y);            
        }

        /// <summary>
        /// Testing invalid commands and having correct exceptions being thrown.
        /// </summary>
        [TestMethod]
        public void TestValidCommands() 
        {
            //Arrange
            Canvas test = new();
            Parser p = new(test);

            //Assert and act
            Assert.ThrowsException<System.ArgumentNullException>(() => p.CommandParser(""));
            Assert.ThrowsException<System.ArgumentNullException>(() => p.CommandParser("invalid"));
            Assert.ThrowsException<System.ArgumentNullException>(() => p.CommandParser("crcle 50"));
            Assert.ThrowsException<System.ArgumentNullException>(() => p.CommandParser("movto 100,100"));
        }

        /// <summary>
        /// Testing invalid parameters and having correct exceptions being thrown.
        /// </summary>
        [TestMethod]
        public void TestInvalidParameters()
        {
            //Arrange
            Canvas test = new();
            Parser p = new(test);

            //Assert
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => p.CommandParser("circle x"));
            Assert.ThrowsException<System.InvalidOperationException>(() => p.CommandParser("moveto 100"));
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => p.CommandParser("drawto 100,100,100"));
        }

        /// <summary>
        /// Testing the clear command by drawing something clearing the display(not actual display while testing) then checking pen position.
        /// </summary>
        [TestMethod]
        public void TestClear() 
        {
            //Arrange
            Canvas test = new();

            //Act
            test.DrawLine(20,50);

            //Arrange
            int x = test.Xpos;
            int y = test.Ypos;

            //Assert
            Assert.AreEqual(50, y);
            Assert.AreEqual(20, x);
            Assert.AreNotEqual(50, x);
            Assert.AreNotEqual(20, y);

            //Act
            test.Clear();
            test.DrawCircle(40);

            //Arrange
            x = test.Xpos;
            y = test.Ypos;

            //Assert
            Assert.AreEqual(50, y);
            Assert.AreEqual(20, x);
            Assert.AreNotEqual(50, x);
            Assert.AreNotEqual(20, y);
        }

        /// <summary>
        /// Testing the rectangle command by calling the command then checking the position of the pen after.
        /// </summary>
        [TestMethod]
        public void TestRectangleCommand() 
        {
            //Arrange
            Canvas test = new();

            //Act
            test.DrawRectangle(40,90);

            //Arrange
            int x = test.Xpos;
            int y = test.Ypos;

            //Assert
            Assert.AreEqual(0, y);
            Assert.AreEqual(0, x);
            Assert.AreNotEqual(50, x);
            Assert.AreNotEqual(20, y);
        }

        /// <summary>
        /// Testing the circle command by calling the command then checking the position of the pen after.
        /// </summary>
        [TestMethod]
        public void TestCircleCommand()
        {
            //Arrange
            Canvas test = new();

            //Act
            test.DrawCircle(40);

            //Arrange
            int x = test.Xpos;
            int y = test.Ypos;

            //Assert
            Assert.AreEqual(0, y);
            Assert.AreEqual(0, x);
            Assert.AreNotEqual(50, x);
            Assert.AreNotEqual(20, y);
        }

        /// <summary>
        /// Testing the triangle command by calling the command then checking the position of the pen after.
        /// </summary>
        [TestMethod]
        public void TestTriangleCommand()
        {
            //Arrange
            Canvas test = new();

            //Act
            test.DrawTriangle(40);

            //Arrange
            int x = test.Xpos;
            int y = test.Ypos;

            //Assert
            Assert.AreEqual(0, y);
            Assert.AreEqual(0, x);
            Assert.AreNotEqual(50, x);
            Assert.AreNotEqual(20, y);
        }

        /// <summary>
        /// This tests the fill command by at first drawing a circle then checking if the fill is on then turning fill on and drawing then 
        /// checking if the fill is on again.
        /// </summary>
        [TestMethod]
        public void TestFillCommand() 
        {
            //Arrange
            Canvas test = new();
            Parser p = new Parser(test);

            //Act
            p.CommandParser("circle 20");

            //Assert
            Assert.IsFalse(p.Fill);

            //Act
            p.CommandParser("fill on");
            p.CommandParser("circle 20");

            //Assert
            Assert.IsTrue(p.Fill);
        }

        /// <summary>
        /// This tests the colour of the pen.
        /// </summary>
        [TestMethod]
        public void TestPenColour()
        {
            //Arrange
            Canvas test = new();
            
            //Act
            test.Pen("red");

            //Assert
            Assert.AreEqual(Color.Red,test.PenColour);
        }       
    }
}