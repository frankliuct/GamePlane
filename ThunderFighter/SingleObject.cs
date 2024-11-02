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

        //存储敌人爆炸的集合
        private List<EnemyBoom> listEnemyBoom = new List<EnemyBoom>();

        //存储玩家爆炸的集合
        private List<HeroBoom> listHeroBoom = new List<HeroBoom>();

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
            else if(go is EnemyBoom) {
                this.listEnemyBoom.Add(go as EnemyBoom);
            }
            else if(go is HeroBoom)
            {
                this.listHeroBoom.Add(go as HeroBoom);
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
            else if(go is EnemyBoom)
            {
                listEnemyBoom.Remove(go as EnemyBoom) ;
            }
            else if(go is HeroBoom)
            {
                listHeroBoom.Remove(go as HeroBoom) ;
            }

        }

        //将游戏对象绘制到窗体上
        public void DrawGameObject(Graphics g)
        {
            //把所有游戏对象绘制到窗体的Draw函数，都在这个函数中进行调用
            // this.BG.Draw(g);
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

            //绘制敌人爆炸
            for(int i = 0;i < listEnemyBoom.Count; i++)
            {
                listEnemyBoom[i].Draw(g);
            }

            //绘制玩家爆炸
            for(int i = 0;i < listHeroBoom.Count; i++)
            {
                listHeroBoom[i].Draw(g);
            }
        }

        //声明一个属性存储玩家分数
        public int Score { get; set; }

        //碰撞检测
        public void PZJC()
        {
            //检测玩家是否击中敌机
            for(int i = 0;i < listHeroZiDan.Count;++i)
            {
                //玩家打出的每一发子弹，进入j循环，判断是否打中敌机
                for (int j = 0;j < listEnemyPlane.Count;++j)
                {
                    if (listHeroZiDan[i].GetRectangle()
                        .IntersectsWith(listEnemyPlane[j].GetRectangle()))
                    {
                        //如果成立，表示玩家子弹击中
                        //敌机生命值减小
                        listEnemyPlane[j].Life -= listHeroZiDan[i].Power;
                        //检测是否生命为0，是则加分
                        CountScore(j);

                        listEnemyPlane[j].IsOver();

                        //碰撞后子弹消失
                        listHeroZiDan.Remove(listHeroZiDan[i]);
                        break;
                    }
                }
            }

            //检测敌人是否打中玩家
            for (int i = 0;i < listEnemyZiDan.Count; i++)
            {
                if (listEnemyZiDan[i].GetRectangle().IntersectsWith
                    (this.HP.GetRectangle()))
                {
                    this.HP.IsOver();
                    //移除敌人子弹
                    listEnemyZiDan.Remove (listEnemyZiDan[i]);
                }
            }

            //检测玩家和敌机是否碰撞
            for(int i = 0;i < listEnemyPlane.Count; i++)
            {
                if (listEnemyPlane[i].GetRectangle().IntersectsWith
                    (this.HP.GetRectangle()))
                {
                    listEnemyPlane[i].Life = 0;
                    CountScore(i);
                    listEnemyPlane[i].IsOver();
                }
            }

            //检测玩家子弹是否打中敌人子弹
            for(int i = 0; i < listHeroZiDan.Count; i++)
            {
                for(int j = 0; j < listEnemyZiDan.Count; j++)
                {
                    if (listHeroZiDan[i].GetRectangle().IntersectsWith
                        (listEnemyZiDan[j].GetRectangle()))
                    {
                        //移除敌人子弹和玩家子弹
                        listEnemyZiDan.Remove(listEnemyZiDan[j]);
                        listHeroZiDan.Remove(listHeroZiDan[i]);
                        break;
                    }
                }
            }
        }

        public void CountScore(int j)
        {
            switch (listEnemyPlane[j].EnemyType)
            {
                case 0:
                    Score += 100;
                    break;
                case 1:
                    Score += 200;
                    break;
                case 2:
                    Score += 300;
                    break;
            }
        }
    }
}
