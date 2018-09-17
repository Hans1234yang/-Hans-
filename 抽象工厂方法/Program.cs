using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 抽象工厂模式
{
    class Program
    {
        static void Main(string[] args)
        {
            //南京工厂
            Factory factoryNanJing = new NanjingFactory();
            YaBo yaBo1 = factoryNanJing.CreateYaBo();
            yaBo1.PrintYabo();
            HaiDai haiDai1 = factoryNanJing.CreateHaiDai();
            haiDai1.PrintHaiDai();

            //上海工厂
            Factory factoryShangHai = new ShangHaiFactory();
            YaBo yaBo2 = factoryShangHai.CreateYaBo();
            yaBo2.PrintYabo();
            HaiDai haiDai2 = factoryShangHai.CreateHaiDai();
            haiDai2.PrintHaiDai();

            //湖南工厂
            Factory factoryHunan = new HunanFactory();
            YaBo yaBo3 = factoryHunan.CreateYaBo();
            yaBo3.PrintYabo();

            HaiDai haiDai3 = factoryHunan.CreateHaiDai();
            haiDai3.PrintHaiDai();
        }
    }
    /// <summary>
    /// 鸭脖抽象类
    /// </summary>
    public abstract class YaBo
    {
        public abstract void PrintYabo();
    }
    /// <summary>
    /// 海带抽象类
    /// </summary>
    public abstract class HaiDai
    {
        public abstract void PrintHaiDai();             
    }
    /// <summary>
    /// 南京鸭脖
    /// </summary>
    public class NanJingYaBo : YaBo
    {
        public override void PrintYabo()
        {
            Console.WriteLine("南京鸭脖产品");
        }
    }
    /// <summary>
    /// 南京海带
    /// </summary>
    public class NanJingHaiDai : HaiDai
    {
        public override void PrintHaiDai()
        {
            Console.WriteLine("南京海带产品");
        }
    }

    /// <summary>
    /// 上海鸭脖
    /// </summary>
    public class ShangHaiYaBo : YaBo
    {
        public override void PrintYabo()
        {
            Console.WriteLine("上海鸭脖产品");
        }
    }
    /// <summary>
    /// 上海海带
    /// </summary>
    public class ShangHaiHaiDai : HaiDai
    {
        public override void PrintHaiDai()
        {
            Console.WriteLine("上海海带产品");
        }
    }
    /// <summary>
    /// 湖南鸭脖
    /// </summary>
    public class HunanYaBo : YaBo
    {
        public override void PrintYabo()
        {
            Console.WriteLine("我是湖南鸭脖");
        }
    }
    /// <summary>
    /// 湖南海带
    /// </summary>
    public class HunanHaiDai : HaiDai
    {
        public override void PrintHaiDai()
        {
            Console.WriteLine("我是湖南海带");
        }
    }

    /// <summary>
    /// 抽象工厂
    /// </summary>
    public abstract class Factory
    {
        public abstract YaBo CreateYaBo();
        public abstract HaiDai CreateHaiDai();
    }

    /// <summary>
    /// 南京工厂
    /// </summary>
    public class NanjingFactory : Factory
    {
        public override HaiDai CreateHaiDai()
        {
            return new NanJingHaiDai();
        }

        public override YaBo CreateYaBo()
        {
            return new NanJingYaBo();
        }
    }
    /// <summary>
    /// 上海工厂
    /// </summary>
    public class ShangHaiFactory : Factory
    {
        public override HaiDai CreateHaiDai()
        {
            return new  ShangHaiHaiDai();
        }

        public override YaBo CreateYaBo()
        {
            return new ShangHaiYaBo();
        }
    }
    /// <summary>
    /// 湖南工厂
    /// </summary>
    public class HunanFactory : Factory
    {
        public override HaiDai CreateHaiDai()
        {
            return new HunanHaiDai();
        }

        public override YaBo CreateYaBo()
        {
            return new HunanYaBo();
        }
    }



}
