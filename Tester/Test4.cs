using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Lek2.T_Hjälpmedel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Lek2.Tester
{
    public class Test4 : TEST
    {
        public Test4(GraphicsDeviceManager a, SpriteBatch b, Texture2D c, SpriteFont d) : base(a, b, c, d) { }

        private List<H_vapen> BL = new List<H_vapen>();
        //private Vector2 Target = new Vector2(1800, 0);
        private float THas = 1;
        private DU_rec du = new DU_rec(new Rectangle(500,500,50,50));
        private int Aim = 0;
        private Stopwatch StopWatch = new Stopwatch();
        //private ColorRec[] Crec = { new ColorRec(new Rectangle(780, 100, 100, 50), Color.Red), new ColorRec(new Rectangle(920, 100, 100, 50), Color.Green) };
        private ColorRec[] Targets = { new ColorRec(new Rectangle(200,200,20,20),Color.Aqua),new ColorRec(new Rectangle(200,780,20,20),Color.Coral),new ColorRec(new Rectangle(1580,200,20,20),Color.Bisque),new ColorRec(new Rectangle(1580,780,20,20),Color.MistyRose)};
        public override void Update(GameTime gametime)
        {
            StopWatch.Start();
            mstate = Mouse.GetState();
            kstate = Keyboard.GetState();
            Rectangle m = new Rectangle(mstate.X + 3, mstate.Y + 3, 6, 6);

            /*if (m.Intersects(Crec[0].ForDraw))
            {
                GHas--;
            }
            if (m.Intersects(Crec[1].ForDraw))
            {
                GHas++;
            }*/

            du.Update();
            ClosestTarget();

            
            foreach (H_vapen b in BL)
            {
                b.Update();
            }
            for (int i = BL.Count - 1; i > -1; i--)
            {
                if (BL[i].die)
                {
                    BL.RemoveAt(i);
                }
            }
            if (StopWatch.ElapsedMilliseconds > 200 || kstate.IsKeyDown(Keys.Space))
            {
                DUSkot();
                StopWatch.Restart();
            }
        }
        public override void Draw()
        {
            //_spriteBatch.DrawString(font, "" + GHas, new Vector2(890, 80), Color.Black);
            _spriteBatch.Draw(texture, du.ForDraw, Color.Black);
            foreach(ColorRec Target in Targets)
            {
                _spriteBatch.Draw(texture, Target.ForDraw, Target.Color);
            }
            foreach (H_vapen b in BL)
            {
                b.Draw(_spriteBatch, texture);
            }

            /*foreach(ColorRec cr in Crec)
            {
                _spriteBatch.Draw(texture, cr.ForDraw, cr.b);
            }*/
        }
        

        /*private void TargetMove()
        {
            Target.Y += THas;
            if (Target.Y < 0||Target.Y>1000)
            {
                THas *= -1;
            }
        }*/
        private void ClosestTarget()
        {
            List<double> DL = new List<double>();
            foreach (ColorRec Target in Targets)
            {
                float[] XY = { 0, 0 };
                XY[0] = Target.X - du.X;
                XY[1] = Target.Y - du.Y;
                DL.Add(Math.Pow(Math.Pow(XY[0], 2) + Math.Pow(XY[1], 2), 0.5));
            }
            for(int i = 0; i < DL.Count; i++)
            {
                if (DL[Aim] > DL[i])
                {
                    Aim = i;
                }
            }
        }
        private void DUSkot()
        {
            if (true)
            {
                BL.Add(new Bullet(new Rectangle((int)du.ForDraw.Center.X,(int)du.ForDraw.Center.Y, 6, 6),du.ForDraw.Center.ToVector2() , Targets[Aim].ForDraw.Center.ToVector2(), 3));
            }
        }

    }
}