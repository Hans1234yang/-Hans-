using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 备忘录模式2
{
    /// <summary>
    /// 多个备忘录点
    /// </summary>
    class Program
    {      
        static void Main(string[] args)
        {
            List<ContractPerson> persons = new List<ContractPerson>()
            {
                new ContractPerson() { Name= "Learning Hard", Mobile = "123445"},
                new ContractPerson() { Name = "Tony", Mobile = "234565"},
                new ContractPerson() { Name = "Jock", Mobile = "231455"}
            };

            MobileOwner mobileOwner = new MobileOwner(persons);
            mobileOwner.Show();

            ///创建备忘录并保存备忘录对象 
            CareTaker careTaker = new CareTaker();
            careTaker.ContactMementoDic.Add(DateTime.Now.ToString(),mobileOwner.CreateMemento());

            //更改联系人列表
            Console.WriteLine("移除最后一名联系人");
            mobileOwner.contractPeople.RemoveAt(2);
            mobileOwner.Show();

            //创建第二个备份
            Thread.Sleep(2000);
            careTaker.ContactMementoDic.Add(DateTime.Now.ToString(),mobileOwner.CreateMemento());

            //恢复原始状态
            Console.WriteLine("恢复联系人列表，从以下列表中选择恢复时间");
            var keyCollection = careTaker.ContactMementoDic.Keys;

            foreach(string k in keyCollection)
            {
                Console.WriteLine("Key={0}",k);
            }
            while(true)
            {
                Console.Write("请输入数字，按窗口的关闭键退出");

                int index = -1;
                try
                {
                    index = Int32.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("输入格式有误");
                    continue;
                }
                ContactMemento contactMemento = null;
                if(index<keyCollection.Count&&careTaker.ContactMementoDic.TryGetValue(keyCollection.ElementAt(index),out contactMemento))
                {
                    mobileOwner.RestoreMemento(contactMemento);
                    mobileOwner.Show();

                }
                else
                {
                    Console.WriteLine("输入的索引大于集合长度");
                }
            }
        }
    }
    /// <summary>
    /// 联系人
    /// </summary>
    public class ContractPerson
    {
        public string Name { get; set; }
        public string Mobile { get; set; }
    }
    /// <summary>
    /// 发起人
    /// </summary>
    public class MobileOwner
    {
        public List<ContractPerson> contractPeople;
        public MobileOwner(List<ContractPerson> _contractPeople)
        {
            contractPeople = _contractPeople;
        }
        //创建备忘录，将联系人加入到备忘录中
        public  ContactMemento CreateMemento()
        {
            return new ContactMemento(this.contractPeople);
        }

        //将备忘录的联系人导入到联系人列表中
        public void RestoreMemento(ContactMemento Memento)
        {
            if(Memento != null)
            {
                this.contractPeople = Memento.contractPeopleBack;
            }
        }

        public void  Show()
        {
            Console.WriteLine("联系人列表有{0}个人,他们是", contractPeople.Count);
            foreach(ContractPerson p in contractPeople)
            {
                Console.WriteLine("姓名{0}，号码{1}",p.Name,p.Mobile);
            }
                
        }
    }
    /// <summary>
    /// 备忘录类
    /// </summary>
    public class ContactMemento
    {
        public List<ContractPerson> contractPeopleBack;
        public ContactMemento(List<ContractPerson> _contractPeople)
        {
            contractPeopleBack = _contractPeople;
        }
    }

    public class CareTaker
    {
        ///使用多个备忘录存储多个备份点
        public Dictionary<string,ContactMemento> ContactMementoDic { get; set; }
        public CareTaker()
        {
            ContactMementoDic = new Dictionary<string, ContactMemento>();
        }
    }
}
