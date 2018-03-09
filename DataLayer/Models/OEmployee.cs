
using System;
using System.Collections.Generic;
namespace DataLayer.Models
{
    public class OEmployee : PclaAuditObjectBase
    {
        public string EmployeeID { get; set; }
        public string GivenName { get; set; }
        public string Surname { get; set; }
        public string Fullname { get; set; }
        public string PositionTitle { get; set; }
        public string Department { get; set; }
        public string Function { get; set; }

        public string FullnameKhStd
        {
            get { return this.Surname + " " + this.GivenName; }
        }

        public string FullnameIntlStd
        {
            get { return this.GivenName + " " + this.Surname; }
        }

        public OEmployee()
            : base()
        {
            this.EmployeeID = String.Empty;
            this.GivenName = String.Empty;
            this.Surname = String.Empty;
            this.Fullname = String.Empty;
            this.PositionTitle = String.Empty;
            this.Department = String.Empty;
            this.Function = String.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Source: http://www.c-sharpcorner.com/article/explain-combo-box-binding-in-mvvm-wpf/
        /// </remarks>
        public static List<string> GetAllDepts()
        {
            List<string> list = new List<string>();
            list.Add("");
            list.Add("Operations & IT");
            list.Add("Finance");
            list.Add("Sale & Distribution");
            return list;
        }

        public static List<string> GetAllFunctions()
        {
            List<string> list = new List<string>();
            list.Add("");
            list.Add("New Business & Underwriting (NBUW)");
            list.Add("Customer Service & Policy Administration (CSPA)");
            list.Add("IT Business Solution & Project");
            list.Add("IT Application Development & Support");
            list.Add("Finance - Accounting");
            list.Add("Finance - Financial Reporting");
            list.Add("Actuarial");
            return list;
        }
    }
}
