﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Web_CuaHangCafe.Models;

namespace Web_CuaHangCafe.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<TbChiTietHoaDonBan> TbChiTietHoaDonBans { get; set; }

    public DbSet<TbHoaDonBan> TbHoaDonBans { get; set; }

    public DbSet<TbKhachHang> TbKhachHangs { get; set; }

    public DbSet<TbNhomSanPham> TbNhomSanPhams { get; set; }

    public DbSet<TbPhanHoi> TbPhanHois { get; set; }

    public DbSet<TbQuanTriVien> TbQuanTriViens { get; set; }

    public DbSet<TbSanPham> TbSanPhams { get; set; }

    public DbSet<TbTinTuc> TbTinTucs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbChiTietHoaDonBan>(entity =>
        {
            entity.HasKey(e => new { e.MaSanPham, e.MaHoaDon }).HasName("PK__tbChiTie__52F2A93ED9FFE6AD");

            entity.ToTable("tbChiTietHoaDonBan");

            entity.Property(e => e.GiaBan).HasColumnType("money");
            entity.Property(e => e.ThanhTien).HasColumnType("money");

            entity.HasOne(d => d.MaHoaDonNavigation).WithMany(p => p.TbChiTietHoaDonBans)
                .HasForeignKey(d => d.MaHoaDon)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tbChiTiet__MaHoa__440B1D61");

            entity.HasOne(d => d.MaSanPhamNavigation).WithMany(p => p.TbChiTietHoaDonBans)
                .HasForeignKey(d => d.MaSanPham)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tbChiTiet__MaSan__44FF419A");
        });

        modelBuilder.Entity<TbHoaDonBan>(entity =>
        {
            entity.HasKey(e => e.MaHoaDon).HasName("PK__tbHoaDon__835ED13BE78BDB82");

            entity.ToTable("tbHoaDonBan");

            entity.HasIndex(e => e.SoHoaDon, "UQ__tbHoaDon__012E9E53087434A1").IsUnique();

            entity.Property(e => e.MaHoaDon).ValueGeneratedNever();
            entity.Property(e => e.NgayBan).HasColumnType("datetime");
            entity.Property(e => e.SoHoaDon).HasMaxLength(14);
            entity.Property(e => e.TongTien).HasColumnType("money");

            entity.HasOne(d => d.Customer).WithMany(p => p.TbHoaDonBans)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tbHoaDonB__Custo__45F365D3");
        });

        modelBuilder.Entity<TbKhachHang>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tbKhachH__3214EC0779854367");

            entity.ToTable("tbKhachHang");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.SdtkhachHang)
                .HasMaxLength(10)
                .HasColumnName("SDTKhachHang");
            entity.Property(e => e.TenKhachHang).HasMaxLength(50);
        });

        modelBuilder.Entity<TbNhomSanPham>(entity =>
        {
            entity.HasKey(e => e.MaNhomSp).HasName("PK__tbNhomSa__5A1AD2F985F055E7");

            entity.ToTable("tbNhomSanPham");

            entity.Property(e => e.MaNhomSp).HasColumnName("MaNhomSP");
            entity.Property(e => e.TenNhomSp)
                .HasMaxLength(255)
                .HasColumnName("TenNhomSP");
        });

        modelBuilder.Entity<TbPhanHoi>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tbPhanHoi");

            entity.Property(e => e.MaPhanHoi).ValueGeneratedOnAdd();
            entity.Property(e => e.SoDienThoai).HasMaxLength(10);
            entity.Property(e => e.TieuDe).HasMaxLength(50);
        });

        modelBuilder.Entity<TbQuanTriVien>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tbQuanTriVien");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.TenNguoiDung).HasMaxLength(50);
        });

        modelBuilder.Entity<TbSanPham>(entity =>
        {
            entity.HasKey(e => e.MaSanPham).HasName("PK__tbSanPha__FAC7442DA6D9D8DC");

            entity.ToTable("tbSanPham");

            entity.Property(e => e.GiaBan).HasColumnType("money");
            entity.Property(e => e.MaNhomSp).HasColumnName("MaNhomSP");
            entity.Property(e => e.TenSanPham).HasMaxLength(255);

            entity.HasOne(d => d.MaNhomSpNavigation).WithMany(p => p.TbSanPhams)
                .HasForeignKey(d => d.MaNhomSp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tbSanPham__MaNho__46E78A0C");
        });

        modelBuilder.Entity<TbTinTuc>(entity =>
        {
            entity.HasKey(e => e.MaTinTuc).HasName("PK__tbTinTuc__B53648C018B441C9");

            entity.ToTable("tbTinTuc");

            entity.Property(e => e.TieuDe).HasMaxLength(255);
        });
    }
}
