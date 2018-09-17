using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 命令模式1
{
    class Program
    {
        static void Main(string[] args)
        {
            Reciver r = new Reciver();
            Command c = new Command(r);
            Police police = new Police(c);

            police.ExeceteCommand();
        }
    }
    /// <summary>
    /// 命令抽象类
    /// </summary>
    public abstract class AbstractCommand
    {
        //命令应该要知道接受者是谁，所以有Receiver变量

        protected Reciver _Reciver;

        public AbstractCommand(Reciver thereciver)
        {
            _Reciver = thereciver;
        }

        ///命令执行方法
        public abstract void Action();
    }

    //具体命令类
    public class Command : AbstractCommand
    {
        public Command(Reciver thereciver):base(thereciver)
        {

        }
        public override void Action()
        {
            _Reciver.Run100Meters();
        }
    }
    //命令接受者，学生
    public class Reciver
    {
        public void Run100Meters()
        {
            Console.WriteLine("跑1000米");
        }
    }

    /// <summary>
    /// 教官，调用命令对象
    /// </summary>
    public class  Police
    {
        public Command _command;

        public Police(Command thecommand)
        {
            _command = thecommand;
        }

        public void ExeceteCommand()
        {
            _command.Action();
        }
    }
}
