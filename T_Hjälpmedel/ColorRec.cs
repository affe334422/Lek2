using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Lek2.T_Hjälpmedel
{
    public class ColorRec : H_Rectangle
    {
        public Color Color;
        public Vector2 vel = new Vector2(0, 0);
        public ColorRec(Rectangle a,Color b) : base(a)
        {
            Color = b;
        }
    }
}