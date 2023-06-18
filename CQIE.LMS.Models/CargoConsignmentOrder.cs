using CQIE.LMS.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQIE.LMS.Models
{
    /// <summary>
    /// 货物托运订单
    /// </summary>
    [Table("Tb_CargoConsignmentOrder")]
    public class CargoConsignmentOrder
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 托运单号
        /// </summary>
        [MaxLength(50)]
        public string ConsignmentNumber { get; set; }

        /// <summary>
        /// 发货地址
        /// </summary>
        [MaxLength(200)]
        public string ShippingLocation { get; set; }

        /// <summary>
        /// 收货地址
        /// </summary>
        [MaxLength(200)]
        public string ReceivingLocation { get; set; }
        
        /// <summary>
        /// 总计金额
        /// </summary>
        public float TotalAmount { get; set; }

        /// <summary>
        /// 托运日期
        /// </summary>
        public DateTime DateOfShipment { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// 状态，1表示已调度，2表示没有调度
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 承运单位
        /// </summary>
        [MaxLength(50)]
        public string Carrier { get; set; }

        /// <summary>
        /// 承办单位电话号码
        /// </summary>
        [MaxLength(30)]
        public string Telephone { get; set; }

        /// <summary>
        /// 业务人员Id
        /// </summary>
        public int BP_Id { get; set; }

        /// <summary>
        /// 业务人员，角色为业务人员的账户
        /// </summary>
        public SysUser BusinessPersonnel { get; set; }

        /// <summary>
        /// 支付方式
        /// </summary>
        [MaxLength(20)]
        public string PaymentMethod { get; set; }

        /// <summary>
        /// 提货方式
        /// </summary>
        [MaxLength(20)]
        public string ReceivingMethod { get; set; }

        public ICollection<Freight> Freights { get; set; } = new HashSet<Freight>();

        public FreightDispatchOrder FreightDispatOrder { get; set; }  

        #region 寄件人信息
        /// <summary>
        /// 寄货人姓名
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string SenderName { get; set; }

        /// <summary>
        /// 寄货人联系电话
        /// </summary>
        [Required]
        [MaxLength(30)]
        public string SenderTelephone { get; set; }

        /// <summary>
        /// 寄货人电子邮箱
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string SenderEmail { get; set; }

        /// <summary>
        /// 寄件人地址
        /// </summary>
        [Required]
        [MaxLength(200)]
        public string SenderAddress { get; set; }
        #endregion

        #region 收货人信息
        /// <summary>
        /// 收货人姓名
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string ConsigneeName { get; set; }

        /// <summary>
        /// 收货人联系电话
        /// </summary>
        [Required]
        [MaxLength(30)]
        public string ConsigneeTelephone { get; set; }

        /// <summary>
        /// 收货人电子邮箱
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string ConsigneeEmail { get; set; }

        /// <summary>
        /// 收货人地址
        /// </summary>
        [Required]
        [MaxLength(200)]
        public string ConsigneeAddress { get; set; }
        #endregion
    }
}
