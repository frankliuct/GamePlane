using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThunderFighter
{
    class EnemyBoom : Boom
    {
        //导入爆炸图片
        private Image[] imgs1 = {
        Image.FromFile("Resources/enemy0_down1.png"),
        Image.FromFile("Resources/enemy0_down2.png"),
        Image.FromFile("Resources/enemy0_down3.png"),
        Image.FromFile("Resources/enemy0_down4.png")
        };

        private Image imgs2 = Image.FromFile("Resources/enemy1_down1.png") ;

        private Image imgs3 = Image.FromFile("Resources/enemy2_down3.png");


        public int Type {  get; set; }
        public EnemyBoom(int x,int y,int type)
            : base(x,y)
        {
            this.Type = type;
        }

        public override void Draw(Graphics g)
        {
            switch(this.Type)
            {
                case 0:
                    for(int i = 0;i < imgs1.Length; i++)
                    {
                        g.DrawImage(imgs1[i],this.X,this.Y);
                    }
                    break;
                case 1:
                    g.DrawImage(imgs2 ,this.X,this.Y);
                    break;
                case 2:
                    g.DrawImage(imgs3 ,this.X,this.Y);
                    break;
            }
            //飞机爆炸后消失
            SingleObject.GetSingle().RemoveGameObject(this);
        }

        public override void MoveToBorder()
        {
            //bug,多余的功能
        }
    }
}
