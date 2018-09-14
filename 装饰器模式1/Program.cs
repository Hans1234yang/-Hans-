using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 装饰器模式1
{
    class Program
    {
        static void Main(string[] args)
        {
            //苹果手机一部
            Phone applephone = new ApplePhone();

            //准备贴膜
            Decorator applesticker = new Staicker(applephone);
            //开始贴膜 
            applesticker.Printinformation();
            Console.WriteLine();

            Decorator aplpleToy = new Toy(applephone);
            aplpleToy.Printinformation();
            Console.WriteLine();

        }
    }

    /// <summary>
    /// 手机抽象类
    /// </summary>
    public abstract class Phone
    {
        public abstract void Printinformation();
    }
    /// <summary>
    /// 苹果手机
    /// </summary>
    public class ApplePhone : Phone
    {
        public override void Printinformation()
        {
            Console.WriteLine("我是一台苹果手机");
        }
    }
    /// <summary>
    /// 配件的抽象类 ，继承手机抽象类 
    /// </summary>
    public abstract class Decorator:Phone
    {
        private Phone thephone;
        public Decorator(Phone _phone)
        {
            thephone = _phone;
        }

        ///重载phone类的 Printinformation方法
        public override void Printinformation()
        {
            thephone.Printinformation();
        }

    }
    /// <summary>
    /// 贴膜 具体装饰者
    /// </summary>
    public class Staicker : Decorator
    {
        //调用父类的 方法

        public Staicker(Phone ppp)
            :base(ppp)
        {

        }

        public override void Printinformation()
        {
            //调用父类的方法 
            base.Printinformation();
            AddSticker();
        }
        public  void AddSticker()
        {
            Console.WriteLine("你的苹果手机贴膜了");
        }
    }

    /// <summary>
    /// 手机玩具
    /// </summary>
    public class Toy : Decorator
    {
        public Toy(Phone _phone) : base(_phone)
        {
        }

        public override void Printinformation()
        {
            base.Printinformation();
            AddToy();
        }

        public void AddToy()
        {
            Console.WriteLine("你的手机有了新的挂件玩具了");
        }
    }

}
