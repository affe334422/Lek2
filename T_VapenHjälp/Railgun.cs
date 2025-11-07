using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Lek2.T_Hjälpmedel
{
    public class Railgun : H_vapen
    {
        private float timea;
        public List<Rectangle> RL = new List<Rectangle>();
        private float timeb = 0;
        public Railgun(Rectangle a, Vector2 Barrel, Vector2 Target, float time) : base(a,Barrel,Target)
        {
            timea = time;
            int antal = (int)(Math.Pow(Math.Pow(XY[0] / a.Width + 0.5, 2) + Math.Pow(XY[1] / a.Height + 0.5, 2), 0.5) + 0.5);
            if (antal < 0) { antal *= -1; }
            for (int i = 0; i < antal; i++)
            {
                RL.Add(new Rectangle((int)(Barrel.X + Riktning.X * a.Width * i), (int)(Barrel.Y + Riktning.Y * a.Height * i), a.Width, a.Height));
            }
        }

        public override void Update()
        {
            timeb++;
            if (timea < timeb)
            {
                die = true;
            }
        }
        public override void Draw(SpriteBatch _spritebatch,Texture2D texture)
        {
            foreach (Rectangle r in RL)
            {
                _spritebatch.Draw(texture, r, Color.Red);
            }
        }
    }
}