using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThunderFighter
{
    class HeroZiDan : ZiDan
    {
        //导入玩家子弹图片
        private static Image imgHeroZiDan = Image.FromFile("Resources/bullet.png");

        public HeroZiDan(PlaneFather pf,int speed,int power)
            :base(pf,power,imgHeroZiDan,pf.X + pf.Width / 4 - 4,pf.Y,speed)
        {

        }
    }
}
