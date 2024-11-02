using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThunderFighter
{
    abstract class PlaneFather : GameObject
    {
        private Image imgPlane;
        public PlaneFather(int x, int y, Image img, int life, int speed, Direction dir):base(x, y, img.Width,img.Height,speed, life, dir)
        {
            this.imgPlane = img;
        }


        public abstract void Fire();
        //public abstract void IsOver();
    }
}
