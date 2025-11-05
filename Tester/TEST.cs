using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Lek2.Tester
{
    public abstract class TEST
    {
        protected GraphicsDeviceManager _graphics;
        protected SpriteBatch _spriteBatch;
        protected Texture2D texture;
        protected SpriteFont font;
        protected KeyboardState kstate;
        protected MouseState mstate;
        protected bool Space = true;
        public TEST(GraphicsDeviceManager a, SpriteBatch b, Texture2D c,SpriteFont d)
        {
            _graphics = a;
            _spriteBatch = b;
            texture = c;
            font = d;
        }
        public abstract void Update(GameTime gametime);
        public abstract void Draw();
    }
}