using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThunderFighter
{
    class SingleObject
    {
        //私有化构造函数
        private SingleObject() { }

        //声明全局唯一的单例对象
        private static SingleObject _single = null;

        //声明一个静态函数返回全局唯一的单例对象
        public static SingleObject GetSingle()
        {
            if( _single == null)
            {
                _single = new SingleObject();
            }
            return _single;
        }


        //在单例类中存储背景对象
        public Background BG { get; set; }

        //玩家对象
        public HeroPlane HP { get; set; }

        //写一个游戏对象，将游戏对象们添加进游戏场景中
        public void AddGameObject(GameObject go)
        {
            if (go is Background)
            {
                //如果传进来的参数是背景对象，则赋值给SinleObject类中BG属性
                this.BG = go as Background;

            }
            else if (go is HeroPlane) { 
                //传进来的是飞机
                this.HP = go as HeroPlane;
            }
        }

        public void DrawGameObject(Graphics g)
        {
            //把所有游戏对象绘制到窗体的Draw函数，都在这个函数中进行调用
            this.BG.Draw(g);
            this.HP.Draw(g);
        }
    }
}
