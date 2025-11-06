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

        private List<Bullet> BL = new List<Bullet>();
        private Vector2 Target = new Vector2(1800, 0);
        private float THas = 1;
        private Vector2 Gun = new Vector2(0, 500);
        private float GHas = 1;
        private Stopwatch StopWatch = new Stopwatch();
        private ColorRec[] Crec = { new ColorRec(new Rectangle(780, 100, 100, 50), Color.Red), new ColorRec(new Rectangle(920, 100, 100, 50), Color.Green) };

        public override void Update(GameTime gametime)
        {
            StopWatch.Start();
            mstate = Mouse.GetState();
            Rectangle m = new Rectangle(mstate.X + 3, mstate.Y + 3, 6, 6);

            if (m.Intersects(Crec[0].ForDraw))
            {
                GHas--;
            }
            if (m.Intersects(Crec[1].ForDraw))
            {
                GHas++;
            }



            TargetMove();
            foreach(Bullet b in BL)
            {
                b.Update();
            }
            if (StopWatch.ElapsedMilliseconds > 200)
            {
                DUSkot();
                StopWatch.Restart();
            }
        }
        public override void Draw()
        {
            //_spriteBatch.DrawString(font, ""+a.Elapsed.Seconds, new Vector2(900, 500), Color.Black);
            _spriteBatch.DrawString(font, "" + GHas, new Vector2(890, 80), Color.Black);
            foreach (Bullet b in BL)
            {
                _spriteBatch.Draw(texture, b.ForDraw, Color.Red);
            }
            foreach(ColorRec cr in Crec)
            {
                _spriteBatch.Draw(texture, cr.ForDraw, cr.b);
            }
        }
        

        private void TargetMove()
        {
            Target.Y += THas;
            if (Target.Y < 0||Target.Y>1000)
            {
                THas *= -1;
            }
        }
        private void DUSkot()
        {
            if (true)
            {
                BL.Add(new Bullet(new Rectangle((int)(Gun.X+0.5)+3, (int)(Gun.Y+0.5)+3, 6, 6),Gun , Target, GHas));
            }
        }

    }
}