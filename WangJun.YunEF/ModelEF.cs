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

        public virtual DbSet<YunComment> YunComment { get; set; }
        public virtual DbSet<YunDocument> YunDocument { get; set; }
        public virtual DbSet<YunForm> YunForm { get; set; }
        public virtual DbSet<YunQueue> YunQueue { get; set; }
        public virtual DbSet<YunService> YunService { get; set; }
        public virtual DbSet<YunCategory> YunCategory { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<YunForm>()
                .Property(e => e.PermissionGroupName)
                .IsFixedLength();

            modelBuilder.Entity<YunForm>()
                .Property(e => e.ValueC01)
                .HasPrecision(18, 0);

            modelBuilder.Entity<YunForm>()
                .Property(e => e.ValueC02)
                .HasPrecision(18, 0);

            modelBuilder.Entity<YunForm>()
                .Property(e => e.ValueC03)
                .HasPrecision(18, 0);

            modelBuilder.Entity<YunForm>()
                .Property(e => e.ValueC04)
                .HasPrecision(18, 0);

            modelBuilder.Entity<YunForm>()
                .Property(e => e.ValueC05)
                .HasPrecision(18, 0);

            modelBuilder.Entity<YunForm>()
                .Property(e => e.ValueC06)
                .HasPrecision(18, 0);

            modelBuilder.Entity<YunForm>()
                .Property(e => e.ValueC07)
                .HasPrecision(18, 0);

            modelBuilder.Entity<YunForm>()
                .Property(e => e.ValueC08)
                .HasPrecision(18, 0);

            modelBuilder.Entity<YunForm>()
                .Property(e => e.ValueC09)
                .HasPrecision(18, 0);

            modelBuilder.Entity<YunForm>()
                .Property(e => e.ValueC10)
                .HasPrecision(18, 0);

            modelBuilder.Entity<YunForm>()
                .Property(e => e.ValueC11)
                .HasPrecision(18, 0);

            modelBuilder.Entity<YunForm>()
                .Property(e => e.ValueC12)
                .HasPrecision(18, 0);

            modelBuilder.Entity<YunForm>()
                .Property(e => e.ValueC13)
                .HasPrecision(18, 0);

            modelBuilder.Entity<YunForm>()
                .Property(e => e.ValueC14)
                .HasPrecision(18, 0);

            modelBuilder.Entity<YunForm>()
                .Property(e => e.ValueC15)
                .HasPrecision(18, 0);

            modelBuilder.Entity<YunForm>()
                .Property(e => e.ValueC16)
                .HasPrecision(18, 0);

            modelBuilder.Entity<YunForm>()
                .Property(e => e.ValueC17)
                .HasPrecision(18, 0);

            modelBuilder.Entity<YunForm>()
                .Property(e => e.ValueC18)
                .HasPrecision(18, 0);

            modelBuilder.Entity<YunForm>()
                .Property(e => e.ValueC19)
                .HasPrecision(18, 0);

            modelBuilder.Entity<YunForm>()
                .Property(e => e.ValueC20)
                .HasPrecision(18, 0);

            modelBuilder.Entity<YunForm>()
                .Property(e => e.ValueC21)
                .HasPrecision(18, 0);

            modelBuilder.Entity<YunForm>()
                .Property(e => e.ValueC22)
                .HasPrecision(18, 0);

            modelBuilder.Entity<YunForm>()
                .Property(e => e.ValueC23)
                .HasPrecision(18, 0);

            modelBuilder.Entity<YunForm>()
                .Property(e => e.ValueC24)
                .HasPrecision(18, 0);

            modelBuilder.Entity<YunForm>()
                .Property(e => e.ValueC25)
                .HasPrecision(18, 0);

            modelBuilder.Entity<YunForm>()
                .Property(e => e.ValueC26)
                .HasPrecision(18, 0);

            modelBuilder.Entity<YunForm>()
                .Property(e => e.ValueC27)
                .HasPrecision(18, 0);

            modelBuilder.Entity<YunForm>()
                .Property(e => e.ValueC28)
                .HasPrecision(18, 0);

            modelBuilder.Entity<YunForm>()
                .Property(e => e.ValueC29)
                .HasPrecision(18, 0);

            modelBuilder.Entity<YunForm>()
                .Property(e => e.ValueC30)
                .HasPrecision(18, 0);

            modelBuilder.Entity<YunService>()
                .Property(e => e.ServiceName)
                .IsFixedLength();
        }
    }
}
