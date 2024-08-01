using System;
using System.Data.Entity;
using System.Linq;

namespace Myweb.Models
{
    public class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<RateAll> RateAll { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RateAll>()
                .HasKey(r => r.Id);

            // 确保没有为 UserId 字段设置外键约束
            modelBuilder.Entity<RateAll>()
                .Property(r => r.UserId)
                .IsRequired();
        }
    }
}
