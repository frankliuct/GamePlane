using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThunderFighter
{
    //敌人飞机类
    class EnemyPlane : PlaneFather
    {
        //导入敌人飞机
        private static Image img1 = Image.FromFile("Resources/enemy0.png");
        private static Image img2 = Image.FromFile("Resources/enemy1.png");
        private static Image img3 = Image.FromFile("Resources/enemy2.png");

        public int EnemyType { get; set; }

        public EnemyPlane(int x, int y,int type):base(x, y, GetImageWithType(type), 
            GetLifeWithType(type), GetSpeedWithType(type), Direction.Down)
        {
            EnemyType = type;
        }
        //敌人发射子弹
        public override void Fire()
        {
            SingleObject.GetSingle().AddGameObject(new EnemyZiDan(this, this.EnemyType));
        }

        //根据不同的飞机类型，返回不同的图片，生命和速度
        public static Image GetImageWithType(int type)
        {
            switch (type)
            {
                case 0:
                    return img1;
                case 1:
                    return img2;
                case 2:
                    return img3;
            }
            return null;
        }

        public static int GetLifeWithType(int type)
        {
            switch (type)
            {
                case 0:
                    return 1;
                case 1:
                    return 2;
                case 2:
                    return 3;
            }
            return 0;
        }

        public static int GetSpeedWithType(int type)
        {
            switch (type)
            {
                case 0:
                    return 10;
                case 1:
                    return 5;
                case 2:
                    return 2;
            }
            return 0;
        }
        Random r = new Random();
        public override void Draw(Graphics g)
        {
            //敌机移动
            base.Move();
            //判断是否可以销毁
            this.MoveToBorder();
            //根据当前飞机的类型，判断应该重绘哪一张图片
            switch(this.EnemyType) {
                case 0:
                    g.DrawImage(img1,this.X,this.Y);
                    break;
                case 1:
                    g.DrawImage(img2, this.X, this.Y);
                    break;
                case 2:
                    g.DrawImage(img3, this.X, this.Y);
                    break;
            }
            //有10%的概率发射子弹
            if(r.Next(0,101) > 97)
            {
                Fire();//让敌机发射子弹
            }


        }


        public override void MoveToBorder()
        {
            if(this.Y >= 812)
            {
                //将敌人飞机销毁
                SingleObject.GetSingle().RemoveGameObject(this);
            }

            if(this.EnemyType == 0 && this.Y >= 200)
            {
                //表示小飞机在左边
                if(this.X >= 0 && this.X <= 240)
                {
                    this.X += r.Next(0, 200);
                }
                else
                {
                    this.X -= r.Next(0, 50);
                }
            }
/*            else
            {
                this.Speed += 1;
            }*/
        }
    }
}
