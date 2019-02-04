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

        public virtual DbSet<YunForm> YunForms { get; set; }
        public virtual DbSet<YunOrder> YunOrders { get; set; }
        public virtual DbSet<YunQRCode> YunQRCodes { get; set; }
        public virtual DbSet<YunRelation> YunRelations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<YunQRCode>()
                .Property(e => e.Status)
                .IsFixedLength();

            modelBuilder.Entity<YunQRCode>()
                .Property(e => e.OrderID)
                .IsFixedLength();

            modelBuilder.Entity<YunQRCode>()
                .Property(e => e.CheckInStartTime)
                .IsFixedLength();

            modelBuilder.Entity<YunQRCode>()
                .Property(e => e.CheckInEndTime)
                .IsFixedLength();

            modelBuilder.Entity<YunQRCode>()
                .Property(e => e.ExpiryTime)
                .IsFixedLength();
        }
    }
}
