using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Lek2.Tester
{
    public class Test2 : TEST
    {
        public Test2(GraphicsDeviceManager a, SpriteBatch b, Texture2D c, SpriteFont d) : base(a, b, c, d)
        {
            rutBredd = BottenHöger[0] - TopVänster[0];
            rutHöjd = BottenHöger[1] - TopVänster[1];
        }

        private int[] TopVänster = { 200, 200 };
        private int[] BottenHöger = { 1600, 800 };
        private double rutBredd;
        private double rutHöjd;
        private List<RecMedText> RL = new List<RecMedText>();
        private bool start = true;
        int antal = 10;
        
        public override void Update(GameTime gametime)
        {
            mstate = Mouse.GetState();
            kstate = Keyboard.GetState();
            if (start)
            {
                start = false;
                AddRec();
            }
            if (kstate.IsKeyDown(Keys.A)&&Space)
            {
                Space = false;
                antal++;
            }
            RL.Clear();
            AddRec();
            if (kstate.IsKeyUp(Keys.A))
            {
                Space = true;
            }
        }
        public override void Draw()
        {
            _spriteBatch.Draw(texture, new Rectangle(TopVänster[0], TopVänster[1], (int)rutBredd, (int)rutHöjd), Color.SkyBlue);
            foreach (RecMedText rec in RL)
            {
                _spriteBatch.Draw(texture, rec.ForDraw, Color.DarkGreen);
                _spriteBatch.DrawString(font, rec.str, new Vector2(rec.X, rec.Y + rec.Height), Color.Black);
            }
        }

        private void AddRec()
        {
            double Längd = rutBredd;
            double centrum = Längd / 2 + TopVänster[0];
            double A80P = Längd * 0.8;
            int Bredd;
            double steg;
            if (antal > 5)
            {
                Bredd = (int)(A80P + 0.5) / 5;
                steg = Längd / 4;
            }
            else
            {
                Bredd = (int)(A80P + 0.5) / antal;
                steg = Längd / (antal - 1);
            }
            int[] BreddHöjd = { Bredd, Bredd / 2 * 3 };

            double x1 = -Längd / 2;
            

            if (antal<6) {
                for (int i = 0; i < antal; i++)
                {
                    double x = x1 + i * steg;
                    RL.Add(new RecMedText(new Rectangle((int)(x + centrum - BreddHöjd[0] / 2), TopVänster[1] - BreddHöjd[1] / 2, BreddHöjd[0], BreddHöjd[1]), x.ToString()));
                }
            }
            else
            {
                for (int i = 0; i < 5; i++)
                {
                    double x = x1 + i * steg;
                    RL.Add(new RecMedText(new Rectangle((int)(x + centrum - BreddHöjd[0] / 2), TopVänster[1] - BreddHöjd[1] / 2, BreddHöjd[0], BreddHöjd[1]), x.ToString()));
                }
                for (int i = 0; i < antal-5; i++)
                {
                    double x = x1 + i * steg;
                    RL.Add(new RecMedText(new Rectangle((int)(x + centrum - BreddHöjd[0] / 2), TopVänster[1] - BreddHöjd[1] / 2 + BreddHöjd[1]+30, BreddHöjd[0], BreddHöjd[1]), x.ToString()));
                }
            }
        
        } 
    }
}