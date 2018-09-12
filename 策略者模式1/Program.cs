using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 策略者模式1
{
    class Program
    {
        static void Main(string[] args)
        {
            //个人所得税方式
            Operation operationperson = new Operation(new PersonTax());
            Console.WriteLine("个人所得的税是{0}", operationperson.GetTax(5000));

            //企业所得税方式
            Operation operationcompany = new Operation(new CompanyTax());
            Console.WriteLine("企业所得的税是{0}",operationcompany.GetTax(5000));
        }
    }
    /// <summary>
    /// 所得税接口
    /// </summary>
    public interface Itax
    {
        double CalculateTax(double income);
    }
    /// <summary>
    /// 个人所得税
    /// </summary>
    public class PersonTax : Itax
    {
        public double CalculateTax(double income)
        {
            return income * 0.12;
        }
    }
    /// <summary>
    /// 企业所得税
    /// </summary>
    public class CompanyTax : Itax
    {
        public double CalculateTax(double income)
        {
            return (income - 3500) > 0 ?(income-3500)*0.045 : 0.0;
        }
    }

    public class Operation
    {
        private Itax itax;
        public Operation(Itax _itax)
        {
            itax = _itax;
        }
        public double GetTax(double income)
        {
            return itax.CalculateTax(income);
        }
    }

}
