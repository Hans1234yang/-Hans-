using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 状态者模式1
{
    class Program
    {
        static void Main(string[] args)
        {
            Account account = new Account("Hans");

            //存钱
            account.Depsit(1000.0);
            account.Depsit(200.0);
            account.Depsit(600.0);

            //付利息
            account.PayInterest();

            //取钱
            account.Withdraw(2000);
            account.Withdraw(500);

            Console.ReadLine();
        }
    }
    //账户类 依赖状态接口

    /// <summary>
    /// 账户类
    /// </summary>
    public class Account
    {
        public State state { get; set; }
        public string Owner { get; set; }
        public Account(string owner)
        {
            this.Owner = owner;
            this.state = new SilverState(0.0, this);
        }
        //余额
        public double Balance { get { return state.Balance; } }

        //存钱
        public void Depsit(double amount)
        {
            state.Deposit(amount);
            Console.WriteLine("存款金额为{0}", amount);
            Console.WriteLine("账户金额为{0}", this.Balance);
            Console.WriteLine("账户状态为{0}", this.state.GetType().Name);
            Console.WriteLine();
        }

        //取钱
        public void Withdraw(double amount)
        {
            state.Withdraw(amount);
            Console.WriteLine("取款金额{0}",amount);
            Console.WriteLine("账户金额{0}",this.Balance);
            Console.WriteLine("账户状态{0}",this.state.GetType().Name);
        }

        //获得利息
        public void PayInterest()
        {
            state.PayInterest();
            Console.WriteLine("利息奖励");
            Console.WriteLine("账户余额为{0}",this.Balance);
            Console.WriteLine("账户状态为{0}",this.state.GetType().Name);
            Console.WriteLine();
        }
           





    }

    //状态抽象类
    public abstract class State
    {
        public Account account { get; set; }
        public double Balance { get; set; } //余额
        public double Intersest { get; set; } //利率
        public double LowerLimit { get; set; }//下限
        public double UpperLimit { get; set; }//上限

        public abstract void Deposit(double amount); //存款
        public abstract void Withdraw(double amount); //取钱
        public abstract void PayInterest(); ///获得的利息

    }
    /// <summary>
    /// 意味着Account透支了
    /// </summary>
    public class RedState : State
    {
        public RedState(State state)
        {
            this.Balance = state.Balance;
            this.account = state.account;
            Intersest = 0.00;
            LowerLimit = -100.00;
            UpperLimit = 0.00;
        }

        //存款
        public override void Deposit(double amount)
        {
            Balance += amount;

        }
        //没有利息
        public override void PayInterest()
        {
            //没有利息
        }
        //取钱
        public override void Withdraw(double amount)
        {
            Console.WriteLine("没有钱可以取了");
        }
        //状态改变
        public void StateChangeCheck()
        {
            if(Balance>UpperLimit)
            {
                account.state = new SilverState(this);
            }
        }

    }
    /// <summary>
    /// 刚开户,无利息
    /// </summary>
    public class SilverState : State
    {
        public SilverState(State state)
            : this(state.Balance, state.account)
        {

        }
        public SilverState(double balance, Account _account)
        {
            this.Balance = balance;
            this.account = _account;
            Intersest = 0.00;
            LowerLimit = 0.00;
            UpperLimit = 1000.00;
        }

        //存款
        public override void Deposit(double amount)
        {
            Balance += amount;
        }

        //获得利息
        public override void PayInterest()
        {
            Balance += Intersest * Balance;
            StateChangeCheck();
        }

        //取钱
        public override void Withdraw(double amount)
        {
            Balance -= amount;
            StateChangeCheck();
        }
        //状态监测
        public void StateChangeCheck()
        {
            if (Balance < LowerLimit)
            {
                account.state = new RedState(this);
            }
            else if (Balance > UpperLimit)
            {
                account.state = new GoldState(this);
            }
        }
    }

    /// <summary>
    /// 有利息模式
    /// </summary>
    public class GoldState : State
    {
        public GoldState(State state)
        {
            this.Balance = state.Balance;
            this.account = state.account;
            Intersest = 0.05;
            LowerLimit = 1000.00;
            UpperLimit = 100000.00;

        }
        //存钱
        public override void Deposit(double amount)
        {
            Balance += amount;
            StateChangeCheck();
        }
        //利息
        public override void PayInterest()
        {
            Balance += Balance * Intersest;
            StateChangeCheck();
        }
        //取钱
        public override void Withdraw(double amount)
        {
            Balance -= amount;
            StateChangeCheck();
        }
        public void  StateChangeCheck()
        {
            if(Balance<0.0)
            {
                account.state = new RedState(this);
            }
            else if(Balance<LowerLimit)
            {
                account.state = new SilverState(this);
            }

        }

    }

}
