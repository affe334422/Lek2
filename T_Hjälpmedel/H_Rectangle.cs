using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Lek2.T_Hjälpmedel
{
    public abstract class H_Rectangle
    {
        private Rectangle Rec;
        private Vector2 Pos;
        public H_Rectangle(Rectangle r)
        {
            Rec = r;
            Pos = new Vector2(Rec.X, Rec.Y);
        }
        public Rectangle ForDraw { get => Rec; }
        public int Height { get => Rec.Height; set => Rec.Height = value; }
        public int Width { get => Rec.Width; set => Rec.Width = value; }
        public float X
        {
            get => Pos.X;
            set
            {
                Pos.X = value;
                Rec.X = (int)(Pos.X + 0.5);
            }
        }
        public float Y {
            get => Pos.Y;
            set
            {
                Pos.Y = value; 
                Rec.Y = (int)(Pos.Y + 0.5);
            }
        }
        public Vector2 Position
        {
            get => Pos;
            set
            {
                Pos = value;
                Rec.X = (int)(Pos.X+0.5);
                Rec.Y = (int)(Pos.Y+0.5);
            }
        }
    }
}