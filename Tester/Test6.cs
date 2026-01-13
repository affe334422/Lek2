using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lek2.T_VapenHjälp;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Lek2.Tester
{
    public class Test6 :TEST
    {
        public Test6(GraphicsDeviceManager a, SpriteBatch b, Texture2D c,SpriteFont d):base(a,b,c,d){}

        private List<V2Homing_Bullet> Hlist = new List<V2Homing_Bullet>();
        private Random ran = new Random();
        public Vector2 cam = new Vector2(0,0);

        public override void Update(GameTime gametime)
        {
            kstate = Keyboard.GetState();
            mstate = Mouse.GetState();
            if(kstate.IsKeyDown(Keys.C)){Hlist.Clear();}
            if (kstate.IsKeyDown(Keys.A)&&Space)
            {
                Space=false;
                Vector2 vec = new Vector2(mstate.Position.X,mstate.Position.Y);
                Hlist.Add(new V2Homing_Bullet(new Rectangle((int)vec.X,(int)vec.Y,10,10),vec,vec,new Vector2(0,0),100));
                cam = vec;
            }
            foreach(V2Homing_Bullet h in Hlist)
            {
                foreach(V2Homing_Bullet b in Hlist)
                {
                    h.CalVelocity(b.Position);
                }
            }
            foreach(V2Homing_Bullet h in Hlist)
            {
                h.Update();
            }
            if(Hlist.Count>0){
                cam=Hlist[0].Position;
            }
            if (kstate.IsKeyUp(Keys.A))
            {
                Space=true;
            }
            


        }
        public override void Draw()
        {
            foreach(Homing_bullet r in Hlist)
            {
                _spriteBatch.Draw(texture,r.ForDraw,Color.Red);
            }
        }
        public override void UIDraw()
        {
            
        }
    }
}