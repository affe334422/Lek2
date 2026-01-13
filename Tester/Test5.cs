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
    public class Test5:TEST
    {
        public Test5(GraphicsDeviceManager a, SpriteBatch b, Texture2D c, SpriteFont d) : base(a, b, c, d) { }
        private DU_rec Du = new Du_grav(new Rectangle(500, 500, 30, 30));
        public DU_rec du{ get => Du; }


        private List<Rectangle> recs = new List<Rectangle>{new Rectangle(400,100,20,20)};
        private ColorRec ViewPoint = new ColorRec(new Rectangle(200,100,33*3,33*2),Color.LawnGreen);
        private Rectangle Mousee = new Rectangle(0,0,10,10);
        private bool Button = true;
        public bool button {get=>Button;}
        private bool change = true;
        public override void Update(GameTime gametime)
        {
            Du.Update();
            mstate = Mouse.GetState();
            kstate = Keyboard.GetState();
            Mousee.Location = new Point(mstate.X-Mousee.Width/2,mstate.Y-Mousee.Height/2);

           
            if (ViewPoint.ForDraw.Intersects(Mousee)&&change&&kstate.IsKeyDown(Keys.C))
            {
                change=false;
                if (Button)
                {
                    Button = false;
                    ViewPoint.Color=Color.IndianRed;
                }
                else
                {
                    Button = true;
                    ViewPoint.Color=Color.LawnGreen;
                }
            }
            if (kstate.IsKeyUp(Keys.C))
            {
                change=true;
            }
        }
        public override void Draw()
        {
            _spriteBatch.Draw(texture, Du.ForDraw, Color.DarkBlue);
            foreach(Rectangle r in recs){
                _spriteBatch.Draw(texture,r,Color.Blue);
            }
        }
        public override void UIDraw()
        {
            _spriteBatch.Draw(texture,ViewPoint.ForDraw,ViewPoint.Color);
            _spriteBatch.Draw(texture,Mousee,Color.Green);
        }
        
    }
}