using System;
using FreeSql.DataAnnotations;

namespace WebApiBase.Models
{
    /// <summary>
    /// 访客信息
    /// </summary>
    [Table(Name = "visitor_user")]
    public class VisitorUserModel
    {
        //唯一ID
        [Column(IsIdentity = true, CanUpdate = false, IsNullable = false)]
        public int KeyId { get; set; }

        //名字
        [Column(DbType = "varchar(255)", IsNullable = false)]
        public string Name { get; set; }

        //单位
        [Column(DbType = "varchar(255)", IsNullable = true)]
        public string Company { get; set; }

        //车牌号
        [Column(DbType = "varchar(255)", IsNullable = false)]
        public string CarNumber { get; set; }

        //有效期开始时间
        [Column(DbType = "datetime", IsNullable = false)]
        public DateTime BeginTime { get; set; }

        //有效期结束时间
        [Column(DbType = "datetime", IsNullable = false)]
        public DateTime EndingTime { get; set; }

        //备注（来访原因）
        [Column(IsNullable = false)] public string Message { get; set; }

        //是否上传至车辆识别设备
        [Column(IsNullable = false)] public bool IsAble { get; set; }

        //有效时间
        [Column(IsNullable = false)] public string EffectiveTime { get; set; }
        
        //创建时间
        [Column(IsNullable = false,ServerTime = DateTimeKind.Local)] public DateTime CreatTime { get; set; }
    }
}