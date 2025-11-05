using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lek2.T_Hjälpmedel;
using Microsoft.Xna.Framework;

namespace Lek2.Tester
{
    public class RecMedText : H_Rectangle
    {
        private string s;
        public RecMedText(Rectangle r, string s):base(r)
        {
            this.s = s;
        }
        public string str{ get => s; }
    }
}