using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThunderFighter
{
    class HeroPlane : PlaneFather
    {
        //导入玩家飞机图片
        private static Image imgHero = Image.FromFile("Resources/hero1.png");
        public HeroPlane(int x, int y, int speed, int life,  Direction dir) : base(x, y, imgHero, life, speed, dir)
        {}

        public override void Draw(Graphics g)
        {
            //在绘制图片的过程中不停的判断飞机是否超出了范围
            this.MoveToBorder();
            g.DrawImage(imgHero,this.X,this.Y,this.Width / 2, this.Height / 2);
            //g.DrawImage(imgHero, this.X, this.Y);
        }

        public override void MoveToBorder()
        {
            if(this.X <= 0)
            {
                this.X = 0;
            }
            if(this.Y <= 0)
            {
                this.Y = 0;
            }
            if(this.X >= 480 - this.Width / 2)
            {
                this.X = 480 - this.Width / 2;
            }
            if( this.Y >= 812 - this.Height / 2)
            {
                this.Y = 812 - this.Height / 2;
            }
        }

        public void MoveWithMouse(MouseEventArgs e)
        {
            this.X = e.X;
            this.Y = e.Y;
        }
    }
}
