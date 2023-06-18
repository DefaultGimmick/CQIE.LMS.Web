using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CQIE.LMS.Models.Dtos
{
    public class FinancialStatement
    {
        [Description("项目名称")]
        public string ProjectName { get; set; }

        [Description("收入总额")]
        public float TotalAmount { get; set; }

        [Description("报销项目")]
        public string SourceOfExpensesDetails { get; set; }

        [Description("报销费用")]
        public float FeeAmount { get; set; }

        [Description("利润")]
        public float Profit { get; set; }

        [Description("支付方式")]
        public string PaymentMethod { get; set; }
    }
}
