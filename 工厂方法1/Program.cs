using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 工厂方法1
{
    class Program
    {
        static void Main(string[] args)
        {
            ///初始化两个工厂
            EggFactory eggFactory = new EggFactory();
            MeatFactory meatFactory = new MeatFactory();
            FruitFactory fruitFactory = new FruitFactory();
            //利用工厂给 接口赋予
            Food foodEgg = eggFactory.CrateFood();
            foodEgg.Printfood();

            Food foodMeat = meatFactory.CrateFood();
            foodMeat.Printfood();

            Food foodFruit = fruitFactory.CrateFood();
            foodFruit.Printfood();

        }
    }

    /// <summary>
    /// 菜的抽象类
    /// </summary>
    public abstract class Food
    {
        public abstract void Printfood();
    }
    /// <summary>
    /// 鸡蛋类
    /// </summary>
    public class Egg : Food
    {
        public override void Printfood()
        {
            Console.WriteLine("我要点一份鸡蛋");
        }
    }
    /// <summary>
    /// 肉类
    /// </summary>
    public class Meat : Food
    {
        public override void Printfood()
        {
            Console.WriteLine("我要一份肉");
        }
    }

    /// <summary>
    /// 水果类
    /// </summary>
    public class fruit : Food
    {
        public override void Printfood()
        {
            Console.WriteLine("我要一份水果");
        }
    }

    /// <summary>
    /// 抽象工厂
    /// </summary>
    public abstract class Factory
    {
        //工厂方法
        public abstract Food CrateFood();
    }

    /// <summary>
    /// 鸡蛋工厂
    /// </summary>
    public class EggFactory : Factory
    {
        public override Food CrateFood()
        {
            return new Egg();
        }
    }
    /// <summary>
    /// 肉工厂
    /// </summary>
    public class MeatFactory : Factory
    {
        public override Food CrateFood()
        {
            return new Meat();
        }
    }

    public class FruitFactory : Factory
    {
        public override Food CrateFood()
        {
            return new fruit();
        }
    }

}

