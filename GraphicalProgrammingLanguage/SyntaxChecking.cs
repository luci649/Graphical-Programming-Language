using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalProgrammingLanguage
{
    public class SyntaxChecking : Exception
    {

        public SyntaxChecking(string msg): base(msg)
        {

        }
    }
}
