using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 备忘录模式1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ContactPerson> persons = new List<ContactPerson>()
            {
               new ContactPerson() { Name= "Learning Hard", Mobile = "123445"},
                new ContactPerson() { Name = "Tony", Mobile = "234565"},
                new ContactPerson() { Name = "Jock", Mobile = "231455"}
            };
            MobileOwner mobileOwner = new MobileOwner(persons);

            mobileOwner.Show();

            //创建备忘录并保存备忘录对象 
            Caretaker caretaker = new Caretaker();
            caretaker.ContactM = mobileOwner.CreateMemento();

            //更改发起人的联系人列表
            Console.WriteLine("------移除一个联系人--------------");
            mobileOwner.contactPeoples.RemoveAt(2);
            mobileOwner.Show();

            //恢复原始状态
            Console.WriteLine("恢复联系人列表");
            mobileOwner.RestoreMemento(caretaker.ContactM);
            mobileOwner.Show();

        }
    }
    /// <summary>
    /// 联系人
    /// </summary>
    public class ContactPerson
    {
        public string Name { get; set; }
        public string Mobile { get; set; }
    }

    /// <summary>
    /// 发起人
    /// </summary>
    public class MobileOwner
    {
        //发起人需要保存的状态
        public List<ContactPerson> contactPeoples { get; set; }

        public MobileOwner(List<ContactPerson> persons)
        {
            contactPeoples = persons;
        }

        //创建备忘录，将当期要保存的联系人列表保存导入到备忘录中
        public ContactMemento CreateMemento()
        {
            return new ContactMemento(new List<ContactPerson>(this.contactPeoples));
        }
        
        //将备忘录中的数据 导入到联系人列表中 
        public void RestoreMemento(ContactMemento memento)
        {
            this.contactPeoples = memento.contactPeopleBack;
        }

        public void Show()
        {
            Console.WriteLine("联系人列表有 {0}个人 他们是:", contactPeoples.Count);

            foreach(ContactPerson p in contactPeoples)
            {
                Console.WriteLine("姓名{0} ,号码{1}",p.Name,p.Mobile);
            }
        }
    }

    /// <summary>
    /// 备忘录类
    /// </summary>
    public class ContactMemento
    {
        public List<ContactPerson> contactPeopleBack { get; set; }

        public ContactMemento(List<ContactPerson> persons)
        {
            contactPeopleBack = persons;
        }
    }
    /// <summary>
    /// 管理角色
    /// </summary>
    public class Caretaker
    {
       public ContactMemento ContactM { get; set; }
    } 
}
