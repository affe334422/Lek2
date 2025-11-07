using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Lek2.T_Hjälpmedel
{
    public abstract class H_vapen : H_Rectangle
    {
        protected Vector2 Riktning;
        private bool Die = false;
        public bool die{ get => Die; set => Die = value; }
        protected float[] XY = { 0, 0 };
        public H_vapen(Rectangle a, Vector2 Barrel, Vector2 Target) : base(a)
        {
            XY[0] = Target.X - Barrel.X;
            XY[1] = Target.Y - Barrel.Y;
            double V = Math.Atan2(XY[1], XY[0]);
            Riktning = new Vector2((float)Math.Cos(V), (float)Math.Sin(V));
        }
        public abstract void Update();
        public virtual void Draw(SpriteBatch _spritebatch,Texture2D texture)
        {
            _spritebatch.Draw(texture, ForDraw, Color.Red);
        }
        
    }
}