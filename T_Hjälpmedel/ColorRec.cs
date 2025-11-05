using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Lek2.T_Hjälpmedel
{
    public class ColorRec : H_Rectangle
    {
        public Color b;
        public ColorRec(Rectangle a,Color b) : base(a)
        {
            this.b = b;
        }
    }
}