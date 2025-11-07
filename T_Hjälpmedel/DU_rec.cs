using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Lek2.T_Hjälpmedel
{
    public class DU_rec : H_Rectangle
    {
        private Vector2 vel = new Vector2(0, 0);
        private int[] max = { -14, 14 };
        private float Friction = 0.9f;
        private KeyboardState kstate;
        public DU_rec(Rectangle a) : base(a) { }
        
        public void Update()
        {
            kstate = Keyboard.GetState();
            Move();
            Position += vel;
        }
        private void Move()
        {
            if (kstate.IsKeyUp(Keys.A) && kstate.IsKeyUp(Keys.D))
            {
                vel.X *= Friction;
                if (vel.X < 1 && -1 < vel.X)
                {
                    vel.X = 0;
                }
            }
            if(kstate.IsKeyUp(Keys.W) && kstate.IsKeyUp(Keys.S)){
                vel.Y *= Friction;
                if (vel.Y < 1 && -1 < vel.Y)
                {
                    vel.Y = 0;
                }
            }
            if (kstate.IsKeyDown(Keys.A))
            {
                vel.X -= 1;
            }
            else if (kstate.IsKeyDown(Keys.D))
            {
                vel.X += 1;
            }
            if (kstate.IsKeyDown(Keys.W))
            {
                vel.Y -= 1;
            }
            else if (kstate.IsKeyDown(Keys.S))
            {
                vel.Y += 1;
            }
            if (vel.Y > max[1])
            {
                vel.Y = max[1];
            }
            else if (vel.Y < max[0])
            {
                vel.Y = max[0];
            }
            if (vel.X > max[1])
            {
                vel.X = max[1];
            }
            else if (vel.X < max[0])
            {
                vel.X = max[0];
            }
        
        }
    }
}