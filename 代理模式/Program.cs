using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 代理模式
{
    class Program
    {
        static void Main(string[] args)
        {
            Person friend = new Friend();
            friend.BuyProduct();
            Console.ReadLine();
        }
    }

    /// <summary>
    /// 人的抽象类
    /// </summary>
    public abstract class Person
    {
        public abstract void BuyProduct();
    }

    /// <summary>
    /// 产品需求者 
    /// </summary>
    public class RealPerson : Person
    {
        public override void BuyProduct()
        {
            Console.WriteLine("我要有一部苹果手机");
        }
    }
    /// <summary>
    /// 代购的朋友
    /// </summary>
    public class Friend : Person
    {
        RealPerson realPerson;

        public override void BuyProduct()
        {
            Console.WriteLine("通过代理类访问真实对象的方法");

            if (realPerson == null)
            {
                realPerson = new RealPerson();
            }

            this.PreBuyProduct();
            realPerson.BuyProduct();
            this.AfterBuyProduct();
        }

        /// <summary>
        /// 代理角色的一些操作
        /// </summary>
        public void PreBuyProduct()
        {
            Console.WriteLine("准备去出发购买了");
        }


        public void AfterBuyProduct()
        {
            Console.WriteLine("购买回来了");
        }
    }
}
