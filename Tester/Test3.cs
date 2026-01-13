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

        private DU_rec du = new DU_rec(new Rectangle(850, 450, 100, 100));
        private GameTime time;
        private List<H_vapen> rail = new List<H_vapen>();
        public override void Update(GameTime gametime)
        {
            time = gametime;
            mstate = Mouse.GetState();
            kstate = Keyboard.GetState();
            du.Update();
            DUSkot();
            foreach (H_vapen r in rail)
            {
                r.Update();
            }
            for (int i = rail.Count - 1; i > -1; i--)
            {
                if (rail[i].die)
                {
                    rail.RemoveAt(i);
                }
            }
        }
        public override void Draw()
        {
            _spriteBatch.Draw(texture, du.ForDraw, Color.Black);
            foreach (H_vapen ra in rail)
            {
                ra.Draw(_spriteBatch, texture);
            }
        }
    
    
        /*private void BulletOut()
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
        }*/
        private void DUSkot()
        {
            
            if (kstate.IsKeyDown(Keys.Space))
            {
                rail.Add(new Railgun(new Rectangle((int)(du.X+du.Width/2), (int)(du.Y+du.Height/2), 6, 6), du.ForDraw.Center.ToVector2(), mstate.Position.ToVector2(),100));
            }
        }
    }
}