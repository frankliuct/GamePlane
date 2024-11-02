using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThunderFighter
{
    enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }
    abstract class GameObject
    {

        //游戏对象的x，y坐标
        public int X { get; set; }
        public int Y { get; set; }
        //游戏对象的宽度和高度
        public int Width { get; set; }
        public int Height { get; set; }
        //游戏对象的速度
        public int Speed { get; set; }
        //游戏对象的生命值
        public int Life { get; set; }
        //游戏对象的方向
        public Direction Dir { get; set; }

        public GameObject(int x, int y, int width, int height, int speed, int life, Direction dir)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Speed = speed;
            Life = life;
            Dir = dir;
        }

        //游戏对象移动的方法
        public virtual void Move()
        {
            //根据当前方向移动
            switch (this.Dir)
            {
                case Direction.Up:
                    this.Y -= this.Speed; break;
                case Direction.Down:
                    this.Y += this.Speed; break;
                case Direction.Left:
                    this.X -= this.Speed; break;
                case Direction.Right:
                    this.X += this.Speed; break;
            }
        }

        //绘制游戏对象的方法
        public abstract void Draw(Graphics g);

        //当游戏对象移动到窗体边缘时，对游戏对象坐标处理的方法
        public abstract void MoveToBorder();

        //获得游戏对象当前所在的句型，用于碰撞检测
        public Rectangle GetRectangle()
        {
            return new Rectangle(X, Y, Width, Height);
        }
    }
}