using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Lek2.T_Hjälpmedel;
using Lek2.T_VapenHjälp;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Lek2.Tester
{
    public class Test4 : TEST
    {
        public Test4(GraphicsDeviceManager a, SpriteBatch b, Texture2D c, SpriteFont d) : base(a, b, c, d) { }
        private bool T = true;
        private Du_r_vapen Du = new Du_r_vapen(new Rectangle(500,500,50,50));
        private int Aim = 0;
        private Stopwatch StopWatch = new Stopwatch();
        //private ColorRec[] Crec = { new ColorRec(new Rectangle(780, 100, 100, 50), Color.Red), new ColorRec(new Rectangle(920, 100, 100, 50), Color.Green) };
        private static int[] boxXY = { 450,480,1350,480 }; // x200, y200, x1580, y780
        private ColorRec[] Targets = { new ColorRec(new Rectangle(boxXY[0], boxXY[1], 20, 20), Color.Aqua), new ColorRec(new Rectangle(boxXY[0], boxXY[3], 20, 20), Color.Coral), new ColorRec(new Rectangle(boxXY[2], boxXY[1], 20, 20), Color.Bisque), new ColorRec(new Rectangle(boxXY[2], boxXY[3], 20, 20), Color.MistyRose) };
        
        public DU_rec du{ get => Du; }
        
        public override void Update(GameTime gametime)
        {
            StopWatch.Start();
            mstate = Mouse.GetState();
            kstate = Keyboard.GetState();
            Rectangle m = new Rectangle(mstate.X + 3, mstate.Y + 3, 6, 6);

            if (kstate.IsKeyDown(Keys.T) && Space)
            {
                Space = false;
                if (T)
                {
                    T = false;
                }else{ T = true; }
            }

            du.Update();
            //MoveTargets();
            Skjut();
            
            
            
            if (kstate.IsKeyUp(Keys.Space)&&kstate.IsKeyUp(Keys.T))
            {
                Space = true;
            }
        }
        public override void Draw()
        {

            
            //_spriteBatch.DrawString(font, "" + GHas, new Vector2(890, 80), Color.Black);
            _spriteBatch.Draw(texture, du.ForDraw, Color.DarkGray);
            foreach (ColorRec Target in Targets)
            {
                _spriteBatch.Draw(texture, Target.ForDraw, Target.Color);
            }
            foreach (H_vapen b in Du.VapenL)
            {
                b.Draw(_spriteBatch, texture);
            }

            /*foreach(ColorRec cr in Crec)
            {
                _spriteBatch.Draw(texture, cr.ForDraw, cr.b);
            }*/
        }
        private void Skjut()
        {
            foreach (H_vapen b in Du.VapenL)
            {
                if (T)
                {
                    b.target = du.Position;
                }
                else
                {
                    b.target = Targets[ClosestTarget(b)].Position;
                }
                b.Update();
            }
            for (int i = Du.VapenL.Count - 1; i > -1; i--)
            {
                if (Du.VapenL[i].die)
                {
                    Du.VapenL.RemoveAt(i);
                }
            }

            if (kstate.IsKeyDown(Keys.Space))
            {
                // välj vad du vill testa
                //du.VapenL.Add(new Bullet(new Rectangle(du.ForDraw.Center.X + 3, du.ForDraw.Center.Y + 3, 6, 6), du.ForDraw.Center.ToVector2(), mstate.Position.ToVector2(), 3));
                //du.VapenL.Add(new Railgun(new Rectangle(du.ForDraw.Center.X + 3, du.ForDraw.Center.Y + 3, 6, 6), du.ForDraw.Center.ToVector2(), Targets[ClosestTarget(du)].Position, 120));
                Du.VapenL.Add(new Homing_bullet(new Rectangle(Du.ForDraw.Center.X + 3, Du.ForDraw.Center.Y + 3, 6, 6), du.ForDraw.Center.ToVector2(), Targets[ClosestTarget(du)].Position, du.Vel, 3));
                Space = false;
                StopWatch.Restart();
            }
        }
        private int ClosestTarget(DU_rec d)
        {
            List<double> DL = new List<double>();
            foreach (ColorRec Target in Targets)
            {
                float[] XY = { 0, 0 };
                XY[0] = Target.X - d.X;
                XY[1] = Target.Y - d.Y;
                DL.Add(Math.Pow(Math.Pow(XY[0], 2) + Math.Pow(XY[1], 2), 0.5));
            }
            for (int i = 0; i < DL.Count; i++)
            {
                if (DL[Aim] > DL[i])
                {
                    Aim = i;
                }
            }
            return Aim;
        }
        private int ClosestTarget(H_vapen d)
        {
            List<double> DL = new List<double>();
            foreach (ColorRec Target in Targets)
            {
                float[] XY = { 0, 0 };
                XY[0] = Target.X - d.X;
                XY[1] = Target.Y - d.Y;
                DL.Add(Math.Pow(Math.Pow(XY[0], 2) + Math.Pow(XY[1], 2), 0.5));
            }
            for (int i = 0; i < DL.Count; i++)
            {
                if (DL[Aim] > DL[i])
                {
                    Aim = i;
                }
            }
            return Aim;
        }
        private void MoveTargets()
        {
            Random ran = new Random();
            float[] max = { -20, 20 };
            foreach (ColorRec r in Targets)
            {
                if (r.vel.X == 0)
                {
                    r.vel = new Vector2(ran.Next(-20,21), ran.Next(-20,21));
                }
                if (r.vel.Y > max[1])
                {
                    r.vel.Y = max[1];
                }
                else if (r.vel.Y < max[0])
                {
                    r.vel.Y = max[0];
                }
                if (r.vel.X > max[1])
                {
                    r.vel.X = max[1];
                }
                else if (r.vel.X < max[0])
                {
                    r.vel.X = max[0];
                }
                if (r.ForDraw.Center.X < 0 || r.ForDraw.Center.X > 1800)
                {
                    r.vel.X *= -1;
                }
                if (r.ForDraw.Center.Y < 0 || r.ForDraw.Center.Y > 1000)
                {
                    r.vel.Y *= -1;
                }
                r.Position += r.vel;
            
            }
        }

    }
}