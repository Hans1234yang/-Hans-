using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 简单工厂2
{
    class Program
    {
        static void Main(string[] args)
        {
            Food foodEgg = FoodSimpleFactory.CreateFood("鸡蛋");
            foodEgg.PrintFood();
            Food foodMeat = FoodSimpleFactory.CreateFood("炒肉");
            foodMeat.PrintFood();
        }
    }

    /// <summary>
    /// 菜抽象类
    /// </summary>
    public abstract class Food
    {
        public abstract void PrintFood();
    }
    /// <summary>
    /// 鸡蛋类
    /// </summary>
    public class Egg : Food
    {
        public override void PrintFood()
        {
            Console.WriteLine("我要一份鸡蛋");
        }
    }
    /// <summary>
    /// 肉类
    /// </summary>
    public class Meat : Food
    {
        public override void PrintFood()
        {
            Console.WriteLine("我要一份炒肉");
        }
    }

    public class FoodSimpleFactory
    {
       public static Food CreateFood(string type)
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
