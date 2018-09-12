using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 中介者模式2
{
    class Program
    {
        static void Main(string[] args)
        {
            CardPlayer playera = new PlayerA();
            CardPlayer playerb = new PlayerB();

            //初始钱
            playera.MoneyCount = 50;
            playerb.MoneyCount = 50;

            Mediator mediator = new MediatorPater(playera,playerb);
            playera.ChangeCount(20,mediator);

            Console.WriteLine("玩家A有{0}元  ,玩家B有{1}元",playera.MoneyCount,playerb.MoneyCount);
            Console.WriteLine();

            playerb.ChangeCount(30,mediator);
            Console.WriteLine("玩家A有{0}元，  玩家B有{1}元",playera.MoneyCount,playerb.MoneyCount);
        }
    }

    /// <summary>
    /// 抽象的牌友类
    /// </summary>
    public abstract class CardPlayer
    {
        public int MoneyCount { get; set; }

        public CardPlayer()
        {
            MoneyCount = 0;
        }
        //依赖抽象中介者
        public abstract void ChangeCount(int Count, Mediator mediator);
    }

    /// <summary>
    /// 
    /// </summary>
    public class PlayerA: CardPlayer
    {
        //依赖抽象中介者
        public override void ChangeCount(int Count, Mediator mediator)
        {
            mediator.AWin(Count);
        }
    }

    public class PlayerB : CardPlayer
    {
        public override void ChangeCount(int Count, Mediator mediator)
        {
            mediator.Bwin(Count);
        }
    }



    /// <summary>
    /// 抽象中介者类
    /// </summary>
    public abstract class Mediator
    {
        protected CardPlayer A;
        protected CardPlayer B;

        public Mediator(CardPlayer _a,CardPlayer _b)
        {
            A = _a;
            B = _b;
        }

        public abstract void AWin(int count);
        public abstract void Bwin(int count);
    }

    public class MediatorPater:Mediator
    {
        public MediatorPater(CardPlayer a,CardPlayer b)
            :base(a,b)
        {

        }

        public override void Bwin(int count)
        {
            A.MoneyCount += count;
            B.MoneyCount -= count;
        }

        public override void AWin(int count)
        {
            B.MoneyCount += count;
            A.MoneyCount -= count;
        }

      
    }
}
