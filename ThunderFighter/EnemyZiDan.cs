using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThunderFighter
{
    class EnemyZiDan : ZiDan
    {
        private static Image img = Image.FromFile("Resources/bullet1.png");

        public int Type {  get; set; }
        public EnemyZiDan(PlaneFather pf,int type)
            : base(pf,GetPowerWithType(type),
                  img,pf.X + pf.Width / 2,pf.Y + pf.Height,GetSpeedWithType(type))
        {
            this.Type = type;
        }
        //根据敌人的类型返回不同的速度和威力
        public static int GetPowerWithType(int type)
        {
            switch(type)
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
                    return 20;
                case 1:
                    return 10;
                case 2:
                    return 5;
            }
            return 0;
        }

    }
}
