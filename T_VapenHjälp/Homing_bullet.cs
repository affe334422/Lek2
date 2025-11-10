using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lek2.T_Hjälpmedel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Lek2.T_VapenHjälp
{
    public class Homing_bullet : H_vapen
    {
        private float Speed;
        private Vector2 vel;
        private float friction = 0.9995f; // 0.925f så träffar den snabt med kanska relaistisk båge
        private float[] max = { -1000, 1000 };
        public Homing_bullet(Rectangle a, Vector2 Barrel, Vector2 Target, Vector2 Duvel, float speed) : base(a, Barrel, Target)
        {
            Speed = speed;
            vel.X=20;
        }
        public override void Update()
        {
            XY[0] = Target.X - Position.X;
            XY[1] = Target.Y - Position.Y;
            double V = Math.Atan2(XY[1], XY[0]);
            vel.X = vel.X * friction;
            vel.Y = vel.Y * friction;
            vel += new Vector2((float)Math.Cos(V) * Speed,(float)Math.Sin(V) * Speed);
            
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
            
            Position += vel;
        }
    }
}