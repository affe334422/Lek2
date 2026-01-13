using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Lek2.T_Hjälpmedel
{
    public class Du_grav : DU_rec
    {
        private int Ground = 900;
        private bool Jump = true;
        public Du_grav(Rectangle a) : base(a)
        {

        }
        public virtual void Update()
        {
            Move();

        }
        protected override void Move()
        {
            kstate = Keyboard.GetState();
            if (kstate.IsKeyUp(Keys.A) && kstate.IsKeyUp(Keys.D))
            {
                vel.X *= Friction;
                if (vel.X < 1 && -1 < vel.X)
                {
                    vel.X = 0;
                }
            }
            
            if (kstate.IsKeyDown(Keys.A))
            {
                if(vel.X>0){ vel.X *= Friction; }
                vel.X -= 1;
            }
            else if (kstate.IsKeyDown(Keys.D))
            {
                if(vel.X<0){ vel.X *= Friction; }
                vel.X += 1;
            }
            
            if (vel.X > max[1])
            {
                vel.X = max[1];
            }
            else if (vel.X < max[0])
            {
                vel.X = max[0];
            }

            if (X < -Width)
            {
                X = 1800;
            }
            else if (X > 1800)
            {
                X = -Width;
            }

            if (kstate.IsKeyDown(Keys.W)&&Jump)
            {
                Jump = false;
                vel.Y -= 35;
            }
            if (Y < Ground)
            {
                vel.Y += 1;
            }
            else if (vel.Y == 0)
            {
                Jump = true;
            }
            if (Position.Y+vel.Y > Ground)
            {
                vel.Y *= -0f;
                if(vel.Y<1&&vel.Y>-1){ vel.Y = 0; }
                Y = Ground;
            }
            
            Position += vel;
        }

    }
}