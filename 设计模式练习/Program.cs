using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 观察者模式1
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User("Hans");

            Account _account = new Account();
            _account._user = user;
            _account.Info = "王者荣耀";

            _account.Update();
            Console.ReadLine();
        }
    }
    ///订阅者
    public class User
    {
        public string Name { get; set; }
        public User(string _name)
        {
            Name = _name;
        }
        public void ReceiveAndPrintData(Account account)
        {
            Console.WriteLine("{0}你好,{1}来了",Name,account.Info);
        }
           
    }

    /// <summary>
    /// 公众号
    /// </summary>
    public class Account
    {
        //用户
        public User _user { get; set; }

        public string Info { get; set; }

        public void Update() 
        {
            if(_user!=null)
            {
                _user.ReceiveAndPrintData(this);
            }
        }
    }
}
