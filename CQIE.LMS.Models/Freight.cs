using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQIE.LMS.Models
{
    /// <summary>
    /// 货物信息
    /// </summary>
    [Table("Tb_Freight")]
    public class Freight
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 货物名称
        /// </summary>
        public string Name{ get; set; }

        /// <summary>
        /// 商品数量
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// 商品规格
        /// </summary>
        public string GoodsSKU { get; set; }

        /// <summary>
        /// /商品重量
        /// </summary>
        public float GoodsWeight { get; set; }

        /// <summary>
        /// 商品体积
        /// </summary>
        public float Volume { get; set;}

        /// <summary>
        /// 运输单价
        /// </summary>
        public float ShippingUnitPrice { get; set;}

        /// <summary>
        /// 送货费
        /// </summary>
        public float DeliveryExpense{ get; set;}

        /// <summary>
        /// 保险费
        /// </summary>
        public float Premium { get; set;}

        /// <summary>
        /// 总费用
        /// </summary>
        public float TotalCost { get; set; }

        /// <summary>
        /// 货物id
        /// </summary>
        public int Order_Id { get; set; }

        public CargoConsignmentOrder Order { get; set; }
        
    }
}
