using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 建造者模式1
{
    class Program
    {
        static void Main(string[] args)
        {
            //创建一个领导 和2个 员工
            Leader leader1 = new Leader();
            Person Jack = new PersonJack();
            Person Hans = new PersonHans();

            leader1.Build(Jack);
            Computer computer1 =Jack.GetComputer();
            computer1.Show();

            leader1.Build(Hans);
            Computer computer2 = Hans.GetComputer();
            computer2.Show();

            Console.ReadLine();
        }
    }

    /// <summary>
    /// 电脑类
    /// </summary>
    public class Computer
    {
       //电脑各个零部件
        private IList<string> parts = new List<string>();

        //把零部件加入到电脑集合中
        public void Add(string part)
        {
            parts.Add(part);
        }
        public void Show()
        {
            Console.WriteLine("电脑开始组装");
            foreach(string part in parts)
            {
                Console.WriteLine("零件"+part+"已装好");
            }

            Console.WriteLine("电脑装好了");
        }
    }
    /// <summary>
    /// 工作人员抽象类
    /// </summary>
    public abstract class Person
    {
        //装cpu
        public abstract void BuildCpu();
        //装主板
        public abstract void BuildMainBoard();

        //已组装好的电脑
        public abstract Computer GetComputer();
    }

    /// <summary>
    /// 工作人员Hans
    /// </summary>
    public class PersonHans : Person
    {
        Computer computer = new Computer();
        public override void BuildCpu()
        {
            computer.Add("CPU1");
        }

        public override void BuildMainBoard()
        {
            computer.Add("MainBoard1");
        }

        public override Computer GetComputer()
        {
            return computer;
        }
    }

    /// <summary>
    /// 工作人员jack
    /// </summary>
    public class PersonJack : Person
    {
        Computer computer = new Computer();
        public override void BuildCpu()
        {
            computer.Add("CPU2");
        }

        public override void BuildMainBoard()
        {
            computer.Add("MainBoard2");
        }

        public override Computer GetComputer()
        {
            return computer;
        }
    }

    /// <summary>
    /// 老板叫人组装电脑
    /// </summary>
    public class Leader
    {
        //组装电脑
        public void Build(Person person)
        {
            //组装主机和cpu
            person.BuildCpu();
            person.BuildMainBoard();
        }
    }
}
