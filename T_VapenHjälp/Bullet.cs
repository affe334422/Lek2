using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Lek2.T_Hjälpmedel
{
    public class Bullet : H_vapen
    {
        public float Speed;
        public Bullet(Rectangle a, Vector2 Barrel, Vector2 Target, float speed) : base(a,Barrel,Target)
        {
            Speed = speed;
        }

        public override void Update()
        {
            Position += new Vector2(Riktning.X*Speed,Riktning.Y*Speed);
            OutOfBounds();
        }
        private void OutOfBounds()
        {
            if (Position.X + Width / 2 > 2000 || Position.X + Width / 2 < -200 || Position.Y+Height/2 < -200 || Position.Y+Height/2 > 1200)
            {
                die = true;
            }
        }
        
    }
}