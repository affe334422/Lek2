using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Lek2.T_Hjälpmedel
{
    public class Bullet : H_Rectangle
    {
        private Vector2 Riktning;
        public bool Die = false;
        public float Speed;
        public Bullet(Rectangle a, Vector2 Barrel, Vector2 Target, float speed) : base(a)
        {
            Speed = speed;
            float X = Target.X - Barrel.X;
            float Y = Target.Y - Barrel.Y;
            double V = Math.Atan2(Y, X);
            Riktning = new Vector2((float)Math.Cos(V)*speed, (float)Math.Sin(V)*speed);
        }

        public void Update()
        {
            Position += Riktning;
            OutOfBounds();
        }
        
        private void OutOfBounds()
        {
            if (Position.X + Width / 2 > 2000 || Position.X + Width / 2 < -200 || Position.Y+Height/2 < -200 || Position.Y+Height/2 > 1200)
            {
                Die = true;
            }
        }
    }
}