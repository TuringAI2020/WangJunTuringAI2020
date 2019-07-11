namespace WangJun.Yun
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelEF : DbContext
    {
        public ModelEF()
            : base("name=ModelEF")
        {
        }

        public virtual DbSet<YunArticle> YunArticles { get; set; }
        public virtual DbSet<YunForm> YunForms { get; set; }
        public virtual DbSet<YunFormInst> YunFormInsts { get; set; }
        public virtual DbSet<YunFormRow> YunFormRows { get; set; }
        public virtual DbSet<YunFormTemplate> YunFormTemplates { get; set; }
        public virtual DbSet<YunOrder> YunOrders { get; set; }
        public virtual DbSet<YunProperty> YunProperties { get; set; }
        public virtual DbSet<YunQRCode> YunQRCodes { get; set; }
        public virtual DbSet<YunRelation> YunRelations { get; set; }
        public virtual DbSet<YunToken> YunTokens { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<YunRelation>()
                .Property(e => e.PermissionGroupID)
                .IsFixedLength();
        }
    }
}
