using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 访问者模式1
{
    class Program
    {
        static void Main(string[] args)
        {
            ObjectStructure objectStructure = new ObjectStructure();
            foreach(Element e in objectStructure.Elements)
            {
                e.Print();
            }
        }
    }
    /// <summary>
    /// 抽象元素角色
    /// </summary>
    public abstract class Element
    {
        public abstract void Print();
    }
    /// <summary>
    /// 我是元素A
    /// </summary>
    public class ElementA : Element
    {
        public override void Print()
        {
            Console.WriteLine("我是元素A");
        }
    }
    /// <summary>
    /// 元素B
    /// </summary>
    public class ElementB : Element
    {
        public override void Print()
        {
            Console.WriteLine("我是元素B");
        }
    }

    public class ObjectStructure
    {
        private ArrayList elements = new ArrayList();

        public ArrayList Elements
        {
            get { return elements; }
        }

        public ObjectStructure()
        {
            Random ran = new Random();
            for (int i = 0; i < 6; i++)
            {
                int ranNum = ran.Next(10);
                if (ranNum > 5)
                {
                    elements.Add(new ElementA());
                }
                else
                {
                    elements.Add(new ElementB());
                }
            }

        }


    }
}
