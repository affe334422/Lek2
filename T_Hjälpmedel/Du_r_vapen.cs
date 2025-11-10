using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lek2.T_VapenHjälp;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Lek2.T_Hjälpmedel
{
    public class Du_r_vapen : DU_rec
    {
        public List<H_vapen> VapenL = new List<H_vapen>();
        private KeyboardState kstate;
        public Du_r_vapen(Rectangle a) : base(a)
        {

        }

        public override void Update()
        {
            kstate = Keyboard.GetState();
            if (kstate.IsKeyDown(Keys.C)) { VapenL.Clear(); }

            Move();
        }
    }
}