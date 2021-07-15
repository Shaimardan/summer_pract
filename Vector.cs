using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vector
{
    class Vector
    {
        public double x;
        public double y;
        public double z;

        public Vector(double x,double y,double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public double modul()
        {
            return Math.Sqrt(x * x + y * y + z *z);
        }

        public double scalar_product(Vector a,Vector b)
        {
            return a.x * b.x + a.y * b.y + a.z * b.z;
        }

        public void produce(Vector a,Double b)
        {
            a.x = a.x * b;
            a.y = a.y * b;
            a.z = a.z * b;
            
        }

        public string Vec()
        {
            return "(" + x + "," + y + "," + z + ")";
        }

        public Vector vector_product(Vector a,Vector b)
        {
            Vector res;
            res = new Vector(a.y*b.z-a.z*b.y,a.z*b.x-a.x*b.z , a.x*b.y-a.y*b.x);
            return res;
        }



    }
}
