using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WebTruyenChu.Models
{
    public partial class TruyenChuContext : DbContext
    {
        public TruyenChuContext()
            : base("name=TruyenChuContext")
        {
        }

        public virtual DbSet<chuong> chuongs { get; set; }
        public virtual DbSet<khachhang> khachhangs { get; set; }
        public virtual DbSet<theloai> theloais { get; set; }
        public virtual DbSet<truyen> truyens { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<khachhang>()
                .Property(e => e.tendangnhap)
                .IsUnicode(false);

            modelBuilder.Entity<khachhang>()
                .Property(e => e.matkhau)
                .IsUnicode(false);

            modelBuilder.Entity<khachhang>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<khachhang>()
                .Property(e => e.dienthoai)
                .IsUnicode(false);

            modelBuilder.Entity<theloai>()
                .Property(e => e.tenurl)
                .IsUnicode(false);

            modelBuilder.Entity<truyen>()
                .Property(e => e.hinh)
                .IsUnicode(false);
        }
    }
}
