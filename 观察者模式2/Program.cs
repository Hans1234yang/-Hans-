using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 观察者模式2
{
    class Program
    {
        static void Main(string[] args)
        {
            Account account = new GameAccount("腾讯游戏","王者荣耀更新了");

            //添加订阅者
            account.AddUser(new User("Hans同学"));
            account.AddUser(new User("Hans腾讯") );

            //订阅者 更新
            account.Update();

            Console.WriteLine();

        }
    }
    //改进后的观察者模式 

    //1. 公众号抽象类不依赖用户类，依赖用户接口 
    //2. 用户类不依赖 具体类，依赖抽象类
    //3. 用户接口 不依赖具体类， 依赖抽象类 

    //从 直接依赖，变成了 间接依赖
    //公众号抽象类
    public abstract class Account
    {
        //保存用户列表
        private List<IUser> usersList = new List<IUser>();
        public string accountName;
        public string info;
        public Account(string _accountName,string _info)
        {
            accountName = _accountName;
            info = _info;
        }

        //增加用户列表
        public void AddUser(IUser _user)
        {
            usersList.Add(_user);
        }
        //移除用户列表
        public void RemoveUser(IUser _user)
        {
            usersList.Remove(_user);
        }

        public  void Update()
        {
            ///遍历用户列表进行通知
            foreach(IUser user in usersList)
            {
                if(user !=null)
                {
                    user.ReceiveAndPrint(this);
                }
            }
        }



    }

    public class GameAccount : Account
    {
        public GameAccount(string accountName,string info) : 
            base(accountName,info)
        {

        }
    }


    /// <summary>
    /// 用户接口
    /// </summary>
    public interface IUser
    {
        void ReceiveAndPrint(Account account);
    }

    /// <summary>
    /// 具体的用户类
    /// </summary>
    public class User : IUser
    {
        public string Name { get; set; }
        public User(string _name)
        {
            Name = _name;
        }
        public void ReceiveAndPrint(Account account)
        {
            Console.WriteLine("{0},{1},{2}",Name,account.accountName,account.info);
        }
    }



}
