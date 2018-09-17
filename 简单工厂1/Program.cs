using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 简单工厂1
{
    class Program
    {
        static void Main(string[] args)
        {
            Food foodEgg = Customer.Cookfood("鸡蛋");
            foodEgg.PrintFood();

            Food foodMeat = Customer.Cookfood("炒肉");
            foodMeat.PrintFood();
        }
    }
    /// <summary>
    /// 菜的抽象类
    /// </summary>
    public abstract class Food
    {
        public abstract void PrintFood();
    }
    /// <summary>
    /// 鸡蛋
    /// </summary>
    public class Egg : Food
    {
        public override void PrintFood()
        {
            Console.WriteLine("我要一份鸡蛋");
        }
    }
    /// <summary>
    /// 肉
    /// </summary>
    public class Meat : Food
    {
        public override void PrintFood()
        {
          Console.WriteLine("我要一份炒肉");
        }
    }

    //客户类
    public class Customer
    {
        public static Food Cookfood(string type)
        {
            Food food = null;

            if(type.Equals("鸡蛋"))
            {
                food = new Egg();
            }
            else if(type.Equals("炒肉"))
            {
                food = new Meat();
            }
            return food;
        }
    }
}
