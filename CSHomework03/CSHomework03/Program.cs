using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSHomework03
{
    class Shape
    {
       virtual public void  Area()
        {
        }
    }
    class Triangle:Shape
    {
        private double height,width;    //三角形的长宽
        public Triangle(double h,double w)
        {
            height = h;
            width = w;
        }
        override public void Area()
        {
            Console.WriteLine("边长为 "+height+" "+width+" 的三角形面积是：" + 0.5 * height * width);
        }
    }
    class Rectangle:Shape
    {
        private double height, width;    //长方形的长宽
        public Rectangle(double h, double w)
        {
            height = h;
            width = w;
        }
        override public void Area()
        {
            Console.WriteLine("边长为 " + height + " " + width + " 的长方形面积是：" + height * width);
        }
    }
    class Circle:Shape
    {
        private double radius;    //圆形的半径
        public Circle(double r)
        {
            radius = r;
        }
        override public void Area()
        {
            Console.WriteLine("半径为 " +radius+ " 的圆形面积是：" + 3.14*radius*radius);
        }
    }
    class Square:Shape
    {
        private double length;    //正方形的边长
        public Square(double l)
        {
            length = l;
        }
        override public void Area()
        {
            Console.WriteLine($"边长为 {length} 的正方形面积是{length*length}");
        }
    }

    class Factory
    {
        public static Shape CreateShape(int index,double a=0.0,double b=0.0)
        {
            Shape shape = null;
            switch (index)
            {
                case 0: shape = new Triangle(a,b);break;    //新建三角形
                case 1: shape = new Rectangle(a, b);break;  //新建长方形
                case 2: shape = new Circle(a); break;       //新建圆形
                case 3: shape = new Square(a); break;       //新建正方形
            }
            return shape;
        }
        public void Area(Shape shape)
        {
            shape.Area();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Shape triange = Factory.CreateShape(0, 3, 4);
            Shape rectangle = Factory.CreateShape(1, 3, 4);
            Shape circle = Factory.CreateShape(2, 3);
            Shape square = Factory.CreateShape(3, 3);
            triange.Area();
            rectangle.Area();
            circle.Area();
            square.Area();
        }
    }
}
