using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Lek2.T_Hjälpmedel
{
    public class Railgun
    {
        private Vector2 Riktning;
        private Rectangle Size;
        public List<Rectangle> RL = new List<Rectangle>();
        private Stopwatch Stopwatch = new Stopwatch();
        public Railgun(Rectangle a,Vector2 Barrel, Vector2 Target)
        {
            Size = a;
            Stopwatch.Start();
            float X = Target.X - Barrel.X;
            float Y = Target.Y - Barrel.Y;
            double V = Math.Atan2(Y, X);
            Riktning = new Vector2((float)Math.Cos(V), (float)Math.Sin(V));
            int antal = (int)(X / Size.Width + 0.5);
            if(antal<0){ antal *= -1; }
            for(int i = 0; i < antal; i++)
            {
                RL.Add(new Rectangle((int)(Barrel.X+Riktning.X*Size.Width*i),(int)(Barrel.Y+Riktning.Y*Size.Height*i),Size.Width,Size.Height));
            }
        }
        public void Update()
        {

        }
    }
}