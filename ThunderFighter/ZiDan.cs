using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThunderFighter
{
    class ZiDan : GameObject
    {
        //子弹的图片
        private Image imgZiDan;

        //子弹的威力
        public int Power { get; set; }
        public ZiDan(PlaneFather pf, int power, Image img, int x, int y, int speed) 
            : base(x,y,img.Width,img.Height,speed,0,pf.Dir)
        {
            this.imgZiDan = img;
            this.Power = power;
        }

        public override void Draw(Graphics g)
        {
            base.Move();
            g.DrawImage(imgZiDan, this.X, this.Y,
                this.Width / 2,this.Height / 2);
        }

        public override void MoveToBorder()
        {
            if(this.Y <= 0 || this.Y >= 812)
            {
                //将子弹对象移除
                SingleObject.GetSingle().RemoveGameObject(this);
            }
        }
    }
}
