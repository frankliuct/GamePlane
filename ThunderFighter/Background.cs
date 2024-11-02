using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace ThunderFighter
{
    class Background : GameObject
    {

        private static Image img = Image.FromFile("Resources/background.png");
        public Background(int x, int y, int speed) : base(x, y, img.Width, img.Height, speed, 0, Direction.Down)
        { }


        public override void Draw(Graphics g)
        {
            this.MoveToBorder();
            g.DrawImage(img, this.X, this.Y);
        }

        public override void MoveToBorder()
        {
            this.Y += this.Speed;
            if (this.Y == 0)
            {
                this.Y = -850;
            }
        }
    }
}