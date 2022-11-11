using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace APIWithWeb.Models
{
    public partial class AppNauAnContext : DbContext
    {
        public AppNauAnContext()
        {
        }

        public AppNauAnContext(DbContextOptions<AppNauAnContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Anhmonan> Anhmonans { get; set; } = null!;
        public virtual DbSet<Binhluan> Binhluans { get; set; } = null!;
        public virtual DbSet<Congthucnguyenlieu> Congthucnguyenlieus { get; set; } = null!;
        public virtual DbSet<Loaimon> Loaimons { get; set; } = null!;
        public virtual DbSet<Mon> Mons { get; set; } = null!;
        public virtual DbSet<Nguoidung> Nguoidungs { get; set; } = null!;
        public virtual DbSet<Nguoidungsave> Nguoidungsaves { get; set; } = null!;
        public virtual DbSet<Nguyenlieu> Nguyenlieus { get; set; } = null!;
        public virtual DbSet<Thongbao> Thongbaos { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("duyhieu");

            modelBuilder.Entity<Anhmonan>(entity =>
            {
                entity.HasKey(e => e.IdAma);

                entity.ToTable("ANHMONAN", "dbo");

                entity.Property(e => e.IdAma).HasColumnName("ID_AMA");

                entity.Property(e => e.Anhmon)
                    .HasMaxLength(100)
                    .HasColumnName("anhmon");

                entity.Property(e => e.Mamon)
                    .HasMaxLength(10)
                    .HasColumnName("mamon");

                entity.HasOne(d => d.MamonNavigation)
                    .WithMany(p => p.Anhmonans)
                    .HasForeignKey(d => d.Mamon)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ANHMONAN_MON");
            });

            modelBuilder.Entity<Binhluan>(entity =>
            {
                entity.HasKey(e => e.IdBl);

                entity.ToTable("BINHLUAN", "dbo");

                entity.Property(e => e.IdBl).HasColumnName("ID_BL");

                entity.Property(e => e.Mamon)
                    .HasMaxLength(10)
                    .HasColumnName("mamon");

                entity.Property(e => e.Noidungbl)
                    .HasMaxLength(100)
                    .HasColumnName("noidungbl");

                entity.Property(e => e.Tendangnhap)
                    .HasMaxLength(10)
                    .HasColumnName("tendangnhap");

                entity.HasOne(d => d.MamonNavigation)
                    .WithMany(p => p.Binhluans)
                    .HasForeignKey(d => d.Mamon)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BINHLUAN_MON");

                entity.HasOne(d => d.TendangnhapNavigation)
                    .WithMany(p => p.Binhluans)
                    .HasForeignKey(d => d.Tendangnhap)
                    .HasConstraintName("FK_BINHLUAN_NGUOIDUNG");
            });

            modelBuilder.Entity<Congthucnguyenlieu>(entity =>
            {
                entity.HasKey(e => e.Ctnlid)
                    .HasName("PK__CONGTHUC__7634B334DEA652C8");

                entity.ToTable("CONGTHUCNGUYENLIEU", "dbo");

                entity.Property(e => e.Ctnlid).HasColumnName("ctnlid");

                entity.Property(e => e.Khoiluong)
                    .HasMaxLength(30)
                    .HasColumnName("khoiluong");

                entity.Property(e => e.Mamon)
                    .HasMaxLength(10)
                    .HasColumnName("mamon");

                entity.Property(e => e.Manguyenlieu)
                    .HasMaxLength(20)
                    .HasColumnName("manguyenlieu");

                entity.HasOne(d => d.MamonNavigation)
                    .WithMany(p => p.Congthucnguyenlieus)
                    .HasForeignKey(d => d.Mamon)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CONGTHUCNGUYENLIEU_MON");

                entity.HasOne(d => d.ManguyenlieuNavigation)
                    .WithMany(p => p.Congthucnguyenlieus)
                    .HasForeignKey(d => d.Manguyenlieu)
                    .HasConstraintName("FK_CONGTHUCNGUYENLIEU_NGUYENLIEU");
            });

            modelBuilder.Entity<Loaimon>(entity =>
            {
                entity.HasKey(e => e.Maloai)
                    .HasName("PK__LOAIMON__734B3AEAD0F646F5");

                entity.ToTable("LOAIMON", "dbo");

                entity.Property(e => e.Maloai)
                    .HasMaxLength(20)
                    .HasColumnName("maloai");

                entity.Property(e => e.Tenloai)
                    .HasMaxLength(30)
                    .HasColumnName("tenloai");
            });

            modelBuilder.Entity<Mon>(entity =>
            {
                entity.HasKey(e => e.Mamon);

                entity.ToTable("MON", "dbo");

                entity.Property(e => e.Mamon)
                    .HasMaxLength(10)
                    .HasColumnName("mamon");

                entity.Property(e => e.Congthuclam)
                    .HasMaxLength(100)
                    .HasColumnName("congthuclam");

                entity.Property(e => e.Maloai)
                    .HasMaxLength(20)
                    .HasColumnName("maloai");

                entity.Property(e => e.Tenmon)
                    .HasMaxLength(30)
                    .HasColumnName("tenmon");

                entity.HasOne(d => d.MaloaiNavigation)
                    .WithMany(p => p.Mons)
                    .HasForeignKey(d => d.Maloai)
                    .HasConstraintName("FK_MON_LOAIMON");
            });

            modelBuilder.Entity<Nguoidung>(entity =>
            {
                entity.HasKey(e => e.Tendangnhap);

                entity.ToTable("NGUOIDUNG", "dbo");

                entity.Property(e => e.Tendangnhap)
                    .HasMaxLength(10)
                    .HasColumnName("tendangnhap");

                entity.Property(e => e.Matkhau)
                    .HasMaxLength(10)
                    .HasColumnName("matkhau");
            });

            modelBuilder.Entity<Nguoidungsave>(entity =>
            {
                entity.HasKey(e => e.IdNds);

                entity.ToTable("NGUOIDUNGSAVE", "dbo");

                entity.Property(e => e.IdNds).HasColumnName("ID_NDS");

                entity.Property(e => e.Mamon)
                    .HasMaxLength(10)
                    .HasColumnName("mamon");

                entity.Property(e => e.Tendangnhap)
                    .HasMaxLength(10)
                    .HasColumnName("tendangnhap");

                entity.HasOne(d => d.MamonNavigation)
                    .WithMany(p => p.Nguoidungsaves)
                    .HasForeignKey(d => d.Mamon)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NGUOIDUNGSAVE_MON");

                entity.HasOne(d => d.TendangnhapNavigation)
                    .WithMany(p => p.Nguoidungsaves)
                    .HasForeignKey(d => d.Tendangnhap)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NGUOIDUNGSAVE_NGUOIDUNG");
            });

            modelBuilder.Entity<Nguyenlieu>(entity =>
            {
                entity.HasKey(e => e.Manguyenlieu);

                entity.ToTable("NGUYENLIEU", "dbo");

                entity.Property(e => e.Manguyenlieu)
                    .HasMaxLength(20)
                    .HasColumnName("manguyenlieu");

                entity.Property(e => e.Anhnguyenlieu)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("anhnguyenlieu");

                entity.Property(e => e.Tennguyenlieu)
                    .HasMaxLength(30)
                    .HasColumnName("tennguyenlieu");
            });

            modelBuilder.Entity<Thongbao>(entity =>
            {
                entity.HasKey(e => e.IdTb);

                entity.ToTable("THONGBAO", "dbo");

                entity.Property(e => e.IdTb).HasColumnName("ID_TB");

                entity.Property(e => e.Noidungtb)
                    .HasMaxLength(100)
                    .HasColumnName("noidungtb");

                entity.Property(e => e.Tendangnhap)
                    .HasMaxLength(10)
                    .HasColumnName("tendangnhap");

                entity.HasOne(d => d.TendangnhapNavigation)
                    .WithMany(p => p.Thongbaos)
                    .HasForeignKey(d => d.Tendangnhap)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_THONGBAO_NGUOIDUNG");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
