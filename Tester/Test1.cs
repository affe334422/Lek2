using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Lek2.Tester
{
    public class Test1 : TEST
    {
        public Test1(GraphicsDeviceManager a, SpriteBatch b, Texture2D c,SpriteFont d) : base(a, b, c,d) { }

        private Vector2 Center = new Vector2(900, 500);
        private float radius = 200; // du kan ändra den.                   
        private float angle;                 
        private float FullCirkle = 64; // man kan ändra den för hur många rektanglar som används för att göra cirklen 
        private float speed;

        private float a = 0.01f; // behöver den för annars så snurrar cirklen hela tiden.
        private float b = 0.0f; // gör att cirklen snurrar.
        private bool start = true;

        private List<Rectangle> RL = new List<Rectangle>();
        public override void Update(GameTime gameTime)
        {
            mstate = Mouse.GetState();
            kstate = Keyboard.GetState();
            speed = 3.14159265f / FullCirkle;
            angle = a;
            a -= b;

            if (kstate.IsKeyDown(Keys.A)) // ändrar bara var cirklens centrum är.
            {
                Center = new Vector2(mstate.X,mstate.Y);
            }

            Circle();

            if (a < -8 || a > 8) // om b är mer än 0
            {
                b *= -1;
            }
            Console.WriteLine(a);

        }
        public override void Draw()
        {
            foreach (Rectangle rec in RL)
            {
                _spriteBatch.Draw(texture, rec, Color.DarkGreen);
            }
        }

        private void Circumfrance()
        {
            angle += speed;
            float PosX = Center.X + (float)Math.Cos(angle) * radius;
            float PosY = Center.Y + (float)Math.Sin(angle) * radius;
            RL.Add(new Rectangle((int)PosX - 5, (int)PosY - 5, 10, 10));  
        }
        private void Circle()
        {
            RL.Clear();
            for (int i = 0; i < (FullCirkle * 2); i++)
            {
                Circumfrance();
            }  
        }
    }
    
    
    
}