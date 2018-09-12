using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 中介者模式1
{
    class Program
    {
        static void Main(string[] args)
        {
            Cardplayer playerA = new PlayerA();
            playerA.MoneyCount  = 50;
            Cardplayer playerB = new PlayerB();
            playerB.MoneyCount = 50;

            //A赢了B  20 元
            playerA.ChangeCount(20,playerB);
            Console.WriteLine("A现在有多少钱 {0}，B现在有多少钱{1}",playerA.MoneyCount,playerB.MoneyCount);

            Console.WriteLine();

            //B 赢了A 40元
            playerB.ChangeCount(50, playerA);
            Console.WriteLine("A现在有多少钱{0},  B现在有多少钱{1}",playerA.MoneyCount,playerB.MoneyCount);
        }
    }

    /// <summary>
    /// 牌友抽象类
    /// </summary>
    public abstract class Cardplayer
    {
        public int MoneyCount { get; set; }

        public Cardplayer()
        {
            MoneyCount = 0;
        }

        public abstract void ChangeCount(int Count,Cardplayer otherplayer);           
    }
    /// <summary>
    /// 牌友A
    /// </summary>
    public class PlayerA : Cardplayer
    {
        public override void ChangeCount(int Count, Cardplayer otherplayer)
        {
            this.MoneyCount += Count;
            otherplayer.MoneyCount -= Count;
        }
    }

    public class PlayerB : Cardplayer
    {
        public override void ChangeCount(int Count, Cardplayer otherplayer)
        {
            this.MoneyCount += Count;
            otherplayer.MoneyCount -= Count;
        }
    }

}
