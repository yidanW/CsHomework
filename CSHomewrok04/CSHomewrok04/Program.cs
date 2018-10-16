using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
/*
第四次作业（两个工程):
1、
使用事件机制，模拟实现一个闹钟的定时功能，
可以设置闹钟，在闹钟时间到了以后，在控制台显示提示信息。
*/
/*
 事件：
 1、类外声明参数类型
 2、类外声明委托类型
 定义事件源
 3、类内声明事件
 4、在一定的情况下，调用事件，即通知外界
 5、在主类里的主函数注册事件
 6、在主类里注册事件处理方法
*/
namespace Clock
{
    // 2、类外声明委托类型
    public delegate void ClockHandler(object sender, EventArgs args);
    // 定义事件源
    class MyClock
    {
        // 3、类内声明事件
        public event ClockHandler Ringing;

        public void DoSetTime()
        {
            DateTime now = DateTime.Now;
            int year, month, day, hour, mintue, second;
            Console.WriteLine("Please input year, month, day, hour, mintue, second:");
            year = int.Parse(Console.ReadLine());
            month = int.Parse(Console.ReadLine());
            day = int.Parse(Console.ReadLine());
            hour = int.Parse(Console.ReadLine());
            mintue = int.Parse(Console.ReadLine());
            second = int.Parse(Console.ReadLine());
            DateTime ringTime = new DateTime(year, month, day, hour, mintue, second);
            TimeSpan duration = ringTime - now;
            Thread.Sleep(duration);
            // 4、在一定的情况下，调用事件，即通知外界
            if (Ringing != null)
            {
                EventArgs args = new EventArgs();
                Ringing(this, args);
            }
        }
    }
    class program
    {

        static void Main(string[] args)
        {
            var clock = new MyClock();
            // 5、在主类里的主函数注册事件
            clock.Ringing += Ring;
            clock.DoSetTime();
        }
        // 6、在主类里注册事件处理方法
        static void Ring(object sender, EventArgs args)
        {
            Console.WriteLine("Times up!");
        }
    }
}