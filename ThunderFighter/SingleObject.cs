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

        //存储敌人飞机的集合
        public List<EnemyPlane> listEnemyPlane = new List<EnemyPlane>();

        //存储玩家子弹的集合
        private List<HeroZiDan> listHeroZiDan = new List<HeroZiDan>();

        //存储敌人子弹的集合
        private List<EnemyZiDan> listEnemyZiDan = new List<EnemyZiDan>();

        //写一个游戏对象，将游戏对象们添加进游戏场景中
        public void AddGameObject(GameObject go)
        {
            if (go is Background)
            {
                //如果传进来的参数是背景对象，则赋值给SinleObject类中BG属性
                this.BG = go as Background;

            }
            else if (go is HeroPlane)
            {
                //传进来的是飞机
                this.HP = go as HeroPlane;
            }
            else if (go is EnemyPlane) { 
                this.listEnemyPlane.Add(go as EnemyPlane);
            }
            else if(go is HeroZiDan)
            {
                this.listHeroZiDan.Add(go as HeroZiDan);
            }
            else if(go is EnemyZiDan){
                this.listEnemyZiDan.Add(go as EnemyZiDan);
            }
        }

        //从游戏中将游戏对象移除
        public void RemoveGameObject(GameObject go)
        {
            if (go is EnemyPlane)
            {
                //将当前这架飞机移除
                listEnemyPlane.Remove(go as EnemyPlane);
            }
            else if (go is HeroZiDan) { 
                listHeroZiDan.Remove(go as HeroZiDan);
            }
            else if(go is EnemyPlane) {
                listEnemyZiDan.Remove(go as EnemyZiDan);
            }

        }

        public void DrawGameObject(Graphics g)
        {
            //把所有游戏对象绘制到窗体的Draw函数，都在这个函数中进行调用
            this.BG.Draw(g);
            this.HP.Draw(g);
            //将每一家飞机都绘制到窗体中
            for (int i = 0; i < listEnemyPlane.Count; i++)
            {
                listEnemyPlane[i].Draw(g);
            }
            //将玩家子弹绘制到窗体中
            for (int i = 0;i < listHeroZiDan.Count; i++)
            {
                listHeroZiDan[i].Draw(g);
            }

            //将敌人子弹绘制到窗体中
            for(int i = 0;i < listEnemyZiDan.Count;i++)
            {
                listEnemyZiDan[i].Draw(g);
            }
        }
    }
}
