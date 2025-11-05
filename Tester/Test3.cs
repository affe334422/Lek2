using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lek2.T_Hjälpmedel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Lek2.Tester
{
    public class Test3 : TEST
    {
        public Test3(GraphicsDeviceManager a, SpriteBatch b, Texture2D c, SpriteFont d) : base(a, b, c, d) { }

        private Rectangle du = new Rectangle(850, 450, 100, 100);
        private List<Bullet> BL = new List<Bullet>();
        public override void Update(GameTime gametime)
        {
            mstate = Mouse.GetState();
            kstate = Keyboard.GetState();
            DUMove();
            DUSkot();
            BulletOut();


        }
        public override void Draw()
        {
            _spriteBatch.Draw(texture, du, Color.Black);
            foreach (Bullet b in BL)
            {
                _spriteBatch.Draw(texture, b.ForDraw, Color.Red);
            }
            _spriteBatch.DrawString(font, (mstate.X - du.Center.X) + " " + (mstate.Y - du.Center.Y), new Vector2(mstate.X, mstate.Y - 20), Color.Black);
        }
    
    
        private void BulletOut()
        {
            List<int> BS = new List<int>();
            for (int i = 0; i < BL.Count; i++)
            {
                if (BL[i].Die)
                {
                    BS.Add(i);
                }
            }
            BS.Reverse();
            foreach (int b in BS)
            {
                BL.RemoveAt(b);
            }
        }
        private void DUSkot()
        {
            foreach(Bullet b in BL)
            {
                b.Update();
            }
            if (kstate.IsKeyDown(Keys.Space))
            {
                float X = mstate.X - du.Center.X;
                float Y = mstate.Y - du.Center.Y;
                double V = Math.Atan2(Y, X);
                Vector2 rik = new Vector2((float)Math.Cos(V), (float)Math.Sin(V));
                BL.Add(new Bullet(new Rectangle(du.Center.X, du.Center.Y, 5, 5), rik, 1));
            }
        }
        private void DUMove()
        {
            if (kstate.IsKeyDown(Keys.A) && Space)
            {
                du.X -= 3;
            }
            if (kstate.IsKeyDown(Keys.W) && Space)
            {
                du.Y -= 3;
            }
            if (kstate.IsKeyDown(Keys.S) && Space)
            {
                du.Y += 3;
            }
            if (kstate.IsKeyDown(Keys.D) && Space)
            {
                du.X += 3;
            }
            if (kstate.IsKeyUp(Keys.A) && kstate.IsKeyUp(Keys.W) && kstate.IsKeyUp(Keys.S) && kstate.IsKeyUp(Keys.D))
            {
                Space = true;
            }
        }
    }
}