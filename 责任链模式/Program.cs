using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 责任链模式
{
    class Program
    {
        static void Main(string[] args)
        {
            BuyRequest phone = new BuyRequest(4000.00,"phone");
            BuyRequest software = new BuyRequest(10000.00,"software");
            BuyRequest Computer = new BuyRequest(50000.00,"computer");

            Approver manager = new Manager("Tony");
            Approver VicePresident = new VicePresident("Hans");
            Approver President = new President("携程梁建章");

            //设置责任链
            manager.NextApprover = VicePresident;
            VicePresident.NextApprover = President;

            //处理请求
            manager.ProcessRequest(phone);
            manager.ProcessRequest(software);
            manager.ProcessRequest(Computer);
        }
    }
    /// <summary>
    /// 购买请求
    /// </summary>
    public class BuyRequest
    {
        //金额
        public double Amount { get; set; }
        //产品名称
        public string ProductName { get; set; }
        public BuyRequest(double _Amount, string _ProductName)
        {
            Amount = _Amount;
            ProductName = _ProductName;
        }
    }

    /// <summary>
    /// 审批人抽象类
    /// </summary>
    public abstract class Approver
    {
        public Approver NextApprover { get; set; }
        public string Name { get; set; }
        public Approver(string _Name)
        {
            Name = _Name;
        }
        public abstract void ProcessRequest(BuyRequest request);
    }

    /// <summary>
    /// 管理者
    /// </summary>
    public class Manager:Approver
    {
        public Manager(string name)
            :base(name)
        { }
        public override void ProcessRequest(BuyRequest request)
        {
            if (request.Amount<10000)
            {
                Console.WriteLine("{0},{1}  审核 {2}", this, Name, request.ProductName);
            }
            else if(NextApprover!=null)
            {
                NextApprover.ProcessRequest(request);
            }
        }
    }

    /// <summary>
    /// 副总经理
    /// </summary>
    public class VicePresident:Approver
    {
        public VicePresident(string name)
            :base(name)
        {

        }
        public override void ProcessRequest(BuyRequest request)
        {
            if(request.Amount<25000)
            {
                Console.WriteLine("{0},{1}审批{2}",this,Name,request.ProductName);
            }
            else if(NextApprover!=null)
            {
                NextApprover.ProcessRequest(request);
            }
        }
    }

    public class President : Approver
    {
        public President(string name)
            :base(name)
        { }

        public override void ProcessRequest(BuyRequest request)
        {
            if(request.Amount<100000)
            {
                Console.WriteLine("{0},{1},审批{2}",this,Name,request.ProductName);
            }
            else
            {
                Console.WriteLine("Request需要组织一个会议讨论");
            }
        }
    }



}
