using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 观察者模式3事件委托
{
    class Program
    {
        //委托充当 用户接口

        public delegate void Iuser(object sender);
        //抽象类公众号
        public abstract class Account
        {
            public Iuser userList;
            public string Name;
            public string Info;
            public Account(string _name,string _info)
            {
                Name = _name;
                Info = _info;
            }
            ///对用户的 维护操作，增加和 移除
            public void AddUser(Iuser _user)
            {
                userList += _user;
            }

            public void Remove(Iuser _user)
            {
                userList -= _user;
            }

            public void Update()
            {
                if(userList!=null)
                {
                    userList(this);
                }
            }
        }

        public class GameAccount:Account
        {
            public GameAccount(string _name,string _info)
                :base( _name, _info)
            {

            }
        }

        /// <summary>
        /// 具体用户
        /// </summary>
        /// <param name="args"></param>
        public class User
        {
            public string Name { get; set; }

            public User(string _name)
            {
                Name = _name;
            }
            public void ReceiveAndPrint(Object obj)
            {
                Account account = obj as Account;
                if(account!=null)
                {
                    Console.WriteLine("{0},{1},{2}",Name,account.Name,account.Info);
                }
            }
        }

        static void Main(string[] args)
        {
            Account account = new GameAccount("腾讯游戏","发布了王者荣耀");
            User user1 = new User("用户1号");
            User user2 = new User("用户2号");

            ///添加订阅者
            account.AddUser(new Iuser(user1.ReceiveAndPrint));
            account.AddUser(new Iuser(user2.ReceiveAndPrint));

            account.Update();

            //移除了用户2号 
            account.Remove(new Iuser(user2.ReceiveAndPrint));

            account.Update();
            Console.ReadLine();
        }
    }
}
