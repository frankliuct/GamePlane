using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThunderFighter
{
    class HeroBoom : Boom
    {
        private Image[] imgs =
        {
            Image.FromFile("Resources/hero_blowup_n1.png"),
            Image.FromFile("Resources/hero_blowup_n2.png"),
            Image.FromFile("Resources/hero_blowup_n3.png"),
            Image.FromFile("Resources/hero_blowup_n4.png")
        };

        public HeroBoom(int x, int y)
            : base(x, y)
        { }


        public override void Draw(Graphics g)
        {
            for (int i = 0; i < imgs.Length; i++)
            {
                g.DrawImage(imgs[i],this.X,this.Y);
            }
            SingleObject.GetSingle().RemoveGameObject(this);
        }

        public override void MoveToBorder()
        {
            //bug
        }
    }
}
