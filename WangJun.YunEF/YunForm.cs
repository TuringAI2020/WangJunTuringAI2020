namespace WangJun.Yun
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("YunForm")]
    public partial class YunForm
    {
        public Guid ID { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        [StringLength(50)]
        public string ContentType { get; set; }

        public DateTime? CreateTime { get; set; }

        public DateTime? UpdateTime { get; set; }

        public int? Status { get; set; }

        public Guid? CreateorID { get; set; }

        [StringLength(50)]
        public string CreatorName { get; set; }

        public Guid? UpdaterID { get; set; }

        [StringLength(50)]
        public string UpdateName { get; set; }

        [StringLength(50)]
        public string SourceName { get; set; }

        [StringLength(2048)]
        public string Url { get; set; }

        public Guid? ParentID { get; set; }

        [StringLength(50)]
        public string ParentName { get; set; }

        public Guid? RootID { get; set; }

        [StringLength(50)]
        public string RootName { get; set; }

        public int? SortValue1 { get; set; }

        public int? SortValue2 { get; set; }

        public Guid? PermissionGroupID { get; set; }

        [StringLength(10)]
        public string PermissionGroupName { get; set; }

        public int? ServiceType { get; set; }

        [StringLength(50)]
        public string KeyA01 { get; set; }

        public string ValueA01 { get; set; }

        [StringLength(50)]
        public string KeyA02 { get; set; }

        public string ValueA02 { get; set; }

        [StringLength(50)]
        public string KeyA03 { get; set; }

        public string ValueA03 { get; set; }

        [StringLength(50)]
        public string KeyA04 { get; set; }

        public string ValueA04 { get; set; }

        [StringLength(50)]
        public string KeyA05 { get; set; }

        public string ValueA05 { get; set; }

        [StringLength(50)]
        public string KeyA06 { get; set; }

        public string ValueA06 { get; set; }

        [StringLength(50)]
        public string KeyA07 { get; set; }

        public string ValueA07 { get; set; }

        [StringLength(50)]
        public string KeyA08 { get; set; }

        public string ValueA08 { get; set; }

        [StringLength(50)]
        public string KeyA09 { get; set; }

        public string ValueA09 { get; set; }

        [StringLength(50)]
        public string KeyA10 { get; set; }

        public string ValueA10 { get; set; }

        [StringLength(50)]
        public string KeyA11 { get; set; }

        public string ValueA11 { get; set; }

        [StringLength(50)]
        public string KeyA12 { get; set; }

        public string ValueA12 { get; set; }

        [StringLength(50)]
        public string KeyA13 { get; set; }

        public string ValueA13 { get; set; }

        [StringLength(50)]
        public string KeyA14 { get; set; }

        public string ValueA14 { get; set; }

        [StringLength(50)]
        public string KeyA15 { get; set; }

        public string ValueA15 { get; set; }

        [StringLength(50)]
        public string KeyA16 { get; set; }

        public string ValueA16 { get; set; }

        [StringLength(50)]
        public string KeyA17 { get; set; }

        public string ValueA17 { get; set; }

        [StringLength(50)]
        public string KeyA18 { get; set; }

        public string ValueA18 { get; set; }

        [StringLength(50)]
        public string KeyA19 { get; set; }

        public string ValueA19 { get; set; }

        [StringLength(50)]
        public string KeyA20 { get; set; }

        public string ValueA20 { get; set; }

        [StringLength(50)]
        public string KeyA21 { get; set; }

        public string ValueA21 { get; set; }

        [StringLength(50)]
        public string KeyA22 { get; set; }

        public string ValueA22 { get; set; }

        [StringLength(50)]
        public string KeyA23 { get; set; }

        public string ValueA23 { get; set; }

        [StringLength(50)]
        public string KeyA24 { get; set; }

        public string ValueA24 { get; set; }

        [StringLength(50)]
        public string KeyA25 { get; set; }

        public string ValueA25 { get; set; }

        [StringLength(50)]
        public string KeyA26 { get; set; }

        public string ValueA26 { get; set; }

        [StringLength(50)]
        public string KeyA27 { get; set; }

        public string ValueA27 { get; set; }

        [StringLength(50)]
        public string KeyA28 { get; set; }

        public string ValueA28 { get; set; }

        [StringLength(50)]
        public string KeyA29 { get; set; }

        public string ValueA29 { get; set; }

        [StringLength(50)]
        public string KeyA30 { get; set; }

        public string ValueA30 { get; set; }

        [StringLength(50)]
        public string KeyB01 { get; set; }

        public int? ValueB01 { get; set; }

        [StringLength(50)]
        public string KeyB02 { get; set; }

        public int? ValueB02 { get; set; }

        [StringLength(50)]
        public string KeyB03 { get; set; }

        public int? ValueB03 { get; set; }

        [StringLength(50)]
        public string KeyB04 { get; set; }

        public int? ValueB04 { get; set; }

        [StringLength(50)]
        public string KeyB05 { get; set; }

        public int? ValueB05 { get; set; }

        [StringLength(50)]
        public string KeyB06 { get; set; }

        public int? ValueB06 { get; set; }

        [StringLength(50)]
        public string KeyB07 { get; set; }

        public int? ValueB07 { get; set; }

        [StringLength(50)]
        public string KeyB08 { get; set; }

        public int? ValueB08 { get; set; }

        [StringLength(50)]
        public string KeyB09 { get; set; }

        public int? ValueB09 { get; set; }

        [StringLength(50)]
        public string KeyB10 { get; set; }

        public int? ValueB10 { get; set; }

        [StringLength(50)]
        public string KeyB11 { get; set; }

        public int? ValueB11 { get; set; }

        [StringLength(50)]
        public string KeyB12 { get; set; }

        public int? ValueB12 { get; set; }

        [StringLength(50)]
        public string KeyB13 { get; set; }

        public int? ValueB13 { get; set; }

        [StringLength(50)]
        public string KeyB14 { get; set; }

        public int? ValueB14 { get; set; }

        [StringLength(50)]
        public string KeyB15 { get; set; }

        public int? ValueB15 { get; set; }

        [StringLength(50)]
        public string KeyB16 { get; set; }

        public int? ValueB16 { get; set; }

        [StringLength(50)]
        public string KeyB17 { get; set; }

        public int? ValueB17 { get; set; }

        [StringLength(50)]
        public string KeyB18 { get; set; }

        public int? ValueB18 { get; set; }

        [StringLength(50)]
        public string KeyB19 { get; set; }

        public int? ValueB19 { get; set; }

        [StringLength(50)]
        public string KeyB20 { get; set; }

        public int? ValueB20 { get; set; }

        [StringLength(50)]
        public string KeyB21 { get; set; }

        public int? ValueB21 { get; set; }

        [StringLength(50)]
        public string KeyB22 { get; set; }

        public int? ValueB22 { get; set; }

        [StringLength(50)]
        public string KeyB23 { get; set; }

        public int? ValueB23 { get; set; }

        [StringLength(50)]
        public string KeyB24 { get; set; }

        public int? ValueB24 { get; set; }

        [StringLength(50)]
        public string KeyB25 { get; set; }

        public int? ValueB25 { get; set; }

        [StringLength(50)]
        public string KeyB26 { get; set; }

        public int? ValueB26 { get; set; }

        [StringLength(50)]
        public string KeyB27 { get; set; }

        public int? ValueB27 { get; set; }

        [StringLength(50)]
        public string KeyB28 { get; set; }

        public int? ValueB28 { get; set; }

        [StringLength(50)]
        public string KeyB29 { get; set; }

        public int? ValueB29 { get; set; }

        [StringLength(50)]
        public string KeyB30 { get; set; }

        public int? ValueB30 { get; set; }

        [StringLength(50)]
        public string KeyC01 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ValueC01 { get; set; }

        [StringLength(50)]
        public string KeyC02 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ValueC02 { get; set; }

        [StringLength(50)]
        public string KeyC03 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ValueC03 { get; set; }

        [StringLength(50)]
        public string KeyC04 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ValueC04 { get; set; }

        [StringLength(50)]
        public string KeyC05 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ValueC05 { get; set; }

        [StringLength(50)]
        public string KeyC06 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ValueC06 { get; set; }

        [StringLength(50)]
        public string KeyC07 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ValueC07 { get; set; }

        [StringLength(50)]
        public string KeyC08 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ValueC08 { get; set; }

        [StringLength(50)]
        public string KeyC09 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ValueC09 { get; set; }

        [StringLength(50)]
        public string KeyC10 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ValueC10 { get; set; }

        [StringLength(50)]
        public string KeyC11 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ValueC11 { get; set; }

        [StringLength(50)]
        public string KeyC12 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ValueC12 { get; set; }

        [StringLength(50)]
        public string KeyC13 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ValueC13 { get; set; }

        [StringLength(50)]
        public string KeyC14 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ValueC14 { get; set; }

        [StringLength(50)]
        public string KeyC15 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ValueC15 { get; set; }

        [StringLength(50)]
        public string KeyC16 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ValueC16 { get; set; }

        [StringLength(50)]
        public string KeyC17 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ValueC17 { get; set; }

        [StringLength(50)]
        public string KeyC18 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ValueC18 { get; set; }

        [StringLength(50)]
        public string KeyC19 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ValueC19 { get; set; }

        [StringLength(50)]
        public string KeyC20 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ValueC20 { get; set; }

        [StringLength(50)]
        public string KeyC21 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ValueC21 { get; set; }

        [StringLength(50)]
        public string KeyC22 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ValueC22 { get; set; }

        [StringLength(50)]
        public string KeyC23 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ValueC23 { get; set; }

        [StringLength(50)]
        public string KeyC24 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ValueC24 { get; set; }

        [StringLength(50)]
        public string KeyC25 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ValueC25 { get; set; }

        [StringLength(50)]
        public string KeyC26 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ValueC26 { get; set; }

        [StringLength(50)]
        public string KeyC27 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ValueC27 { get; set; }

        [StringLength(50)]
        public string KeyC28 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ValueC28 { get; set; }

        [StringLength(50)]
        public string KeyC29 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ValueC29 { get; set; }

        [StringLength(50)]
        public string KeyC30 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ValueC30 { get; set; }

        [StringLength(50)]
        public string KeyD01 { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ValueD01 { get; set; }

        [StringLength(50)]
        public string KeyD02 { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ValueD02 { get; set; }

        [StringLength(50)]
        public string KeyD03 { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ValueD03 { get; set; }

        [StringLength(50)]
        public string KeyD04 { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ValueD04 { get; set; }

        [StringLength(50)]
        public string KeyD05 { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ValueD05 { get; set; }

        [StringLength(50)]
        public string KeyD06 { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ValueD06 { get; set; }

        [StringLength(50)]
        public string KeyD07 { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ValueD07 { get; set; }

        [StringLength(50)]
        public string KeyD08 { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ValueD08 { get; set; }

        [StringLength(50)]
        public string KeyD09 { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ValueD09 { get; set; }

        [StringLength(50)]
        public string KeyD10 { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ValueD10 { get; set; }

        [StringLength(50)]
        public string KeyD11 { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ValueD11 { get; set; }

        [StringLength(50)]
        public string KeyD12 { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ValueD12 { get; set; }

        [StringLength(50)]
        public string KeyD13 { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ValueD13 { get; set; }

        [StringLength(50)]
        public string KeyD14 { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ValueD14 { get; set; }

        [StringLength(50)]
        public string KeyD15 { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ValueD15 { get; set; }

        [StringLength(50)]
        public string KeyD16 { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ValueD16 { get; set; }

        [StringLength(50)]
        public string KeyD17 { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ValueD17 { get; set; }

        [StringLength(50)]
        public string KeyD18 { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ValueD18 { get; set; }

        [StringLength(50)]
        public string KeyD19 { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ValueD19 { get; set; }

        [StringLength(50)]
        public string KeyD20 { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ValueD20 { get; set; }

        [StringLength(50)]
        public string KeyD21 { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ValueD21 { get; set; }

        [StringLength(50)]
        public string KeyD22 { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ValueD22 { get; set; }

        [StringLength(50)]
        public string KeyD23 { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ValueD23 { get; set; }

        [StringLength(50)]
        public string KeyD24 { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ValueD24 { get; set; }

        [StringLength(50)]
        public string KeyD25 { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ValueD25 { get; set; }

        [StringLength(50)]
        public string KeyD26 { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ValueD26 { get; set; }

        [StringLength(50)]
        public string KeyD27 { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ValueD27 { get; set; }

        [StringLength(50)]
        public string KeyD28 { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ValueD28 { get; set; }

        [StringLength(50)]
        public string KeyD29 { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ValueD29 { get; set; }

        [StringLength(50)]
        public string KeyD30 { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ValueD30 { get; set; }

        public float? KeyE01 { get; set; }

        public string ValueE01 { get; set; }

        public float? KeyE02 { get; set; }

        public string ValueE02 { get; set; }

        public float? KeyE03 { get; set; }

        public string ValueE03 { get; set; }

        public float? KeyE04 { get; set; }

        public string ValueE04 { get; set; }

        public float? KeyE05 { get; set; }

        public string ValueE05 { get; set; }

        public float? KeyE06 { get; set; }

        public string ValueE06 { get; set; }

        public float? KeyE07 { get; set; }

        public string ValueE07 { get; set; }

        public float? KeyE08 { get; set; }

        public string ValueE08 { get; set; }

        public float? KeyE09 { get; set; }

        public string ValueE09 { get; set; }

        public float? KeyE10 { get; set; }

        public string ValueE10 { get; set; }

        public float? KeyE11 { get; set; }

        public string ValueE11 { get; set; }

        public float? KeyE12 { get; set; }

        public string ValueE12 { get; set; }

        public float? KeyE13 { get; set; }

        public string ValueE13 { get; set; }

        public float? KeyE14 { get; set; }

        public string ValueE14 { get; set; }

        public float? KeyE15 { get; set; }

        public string ValueE15 { get; set; }

        public float? KeyE16 { get; set; }

        public string ValueE16 { get; set; }

        public float? KeyE17 { get; set; }

        public string ValueE17 { get; set; }

        public float? KeyE18 { get; set; }

        public string ValueE18 { get; set; }

        public float? KeyE19 { get; set; }

        public string ValueE19 { get; set; }

        public float? KeyE20 { get; set; }

        public string ValueE20 { get; set; }

        public float? KeyE21 { get; set; }

        public string ValueE21 { get; set; }

        public float? KeyE22 { get; set; }

        public string ValueE22 { get; set; }

        public float? KeyE23 { get; set; }

        public string ValueE23 { get; set; }

        public float? KeyE24 { get; set; }

        public string ValueE24 { get; set; }

        public float? KeyE25 { get; set; }

        public string ValueE25 { get; set; }

        public float? KeyE26 { get; set; }

        public string ValueE26 { get; set; }

        public float? KeyE27 { get; set; }

        public string ValueE27 { get; set; }

        public float? KeyE28 { get; set; }

        public string ValueE28 { get; set; }

        public float? KeyE29 { get; set; }

        public string ValueE29 { get; set; }

        public float? KeyE30 { get; set; }

        public string ValueE30 { get; set; }
    }
}
