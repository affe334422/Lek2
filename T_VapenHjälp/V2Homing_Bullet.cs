using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Lek2.T_VapenHjälp
{
    public class V2Homing_Bullet : Homing_bullet
    {
        public V2Homing_Bullet(Rectangle a, Vector2 Barrel, Vector2 Target, Vector2 Duvel, float speed) : base(a, Barrel, Target, Duvel, speed)
        {
            max[0] = -1000;
            max[1] = 1000;
        }
        public bool CanBounce = true;
        public override void Update()
        {
            vel.X = vel.X * friction;
            vel.Y = vel.Y * friction;
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
        public void CalVelocity(Vector2 Tarss)
        {
            XY[0] = Tarss.X - Position.X;
            XY[1] = Tarss.Y - Position.Y;
            double hyp = Math.Pow(Math.Pow(XY[0],2)+Math.Pow(XY[1],2),0.5);
            double V = Math.Atan2(XY[1], XY[0]);
            double Force=0;
            if(Math.Pow(hyp,2)!=0){
                Force = 4*(10 / Math.Pow(hyp,2));
            }
            Console.WriteLine(Force);
            if(XY[0]!=0||XY[1]!=0){
                if(true){
                    // f = g * (m1*m2)/r^2
                    vel += new Vector2((float)(Math.Cos(V)*Force),(float)(Math.Sin(V)*Force));
                }
                else
                {
                    
                }
            }
            
            
        }
        public void Bounce()
        {
            vel*=new Vector2(-0.9f,-0.9f);
        }
    }
}