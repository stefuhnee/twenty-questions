using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyQs
{
    public class Question
    {
        public Question() { }

        public Question(string text)
        {
            this.text = text;
        }

        public string text;
        public Question yes;
        public Question no;

        public bool IsLeaf()
        {
            return yes == null; // no == null too
        }
    }
}
