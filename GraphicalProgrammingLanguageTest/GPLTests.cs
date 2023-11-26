using GraphicalProgrammingLanguage;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GraphicalProgrammingLanguageTest
{
    [TestClass]
    public class GPLTestS1
    {          
       

        [TestMethod]
        public void TestMethod1()
        {           
            Form1 form = new Form1("moveto 3131,1312");
            
            //assert
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => form);
        }
    }
}