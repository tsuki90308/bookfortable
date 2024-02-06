﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace bookfortable.Models;

public partial class FinalContext : DbContext
{
    public FinalContext()
    {
    }

    public FinalContext(DbContextOptions<FinalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<BookTag> BookTags { get; set; }

    public virtual DbSet<DiscountCodeCart> DiscountCodeCarts { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EvenType> EvenTypes { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<Member> Members { get; set; }

    public virtual DbSet<Message> Messages { get; set; }

    public virtual DbSet<MyCoupon> MyCoupons { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<OrderList> OrderLists { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Relation> Relations { get; set; }

    public virtual DbSet<SingUp> SingUps { get; set; }

    public virtual DbSet<TradeList> TradeLists { get; set; }

    public virtual DbSet<WishList> WishLists { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Final;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.Property(e => e.AAddress)
                .HasMaxLength(100)
                .HasColumnName("aAddress");
            entity.Property(e => e.ARegioncode).HasColumnName("aRegioncode");

            entity.HasOne(d => d.Member).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Addresses_Members");
        });

        modelBuilder.Entity<BookTag>(entity =>
        {
            entity.HasKey(e => e.BtagId);

            entity.ToTable("BookTag");

            entity.Property(e => e.BtagName).HasMaxLength(50);
        });

        modelBuilder.Entity<DiscountCodeCart>(entity =>
        {
            entity.HasKey(e => e.DiscountId);

            entity.ToTable("DiscountCodeCart");

            entity.Property(e => e.DiscountId).HasColumnName("DiscountID");
            entity.Property(e => e.DiscountCode).HasMaxLength(50);
            entity.Property(e => e.DiscountEnd).HasColumnType("datetime");
            entity.Property(e => e.DiscountNote).HasMaxLength(100);
            entity.Property(e => e.DiscountPrice).HasColumnType("money");
            entity.Property(e => e.DiscountStart).HasColumnType("datetime");
            entity.Property(e => e.DiscountType).HasMaxLength(10);
            entity.Property(e => e.IsActivate).HasColumnName("isActivate");
            entity.Property(e => e.IsMemberDiscount).HasColumnName("isMemberDiscount");
            entity.Property(e => e.IsPartnerDiscount).HasColumnName("isPartnerDiscount");
            entity.Property(e => e.PartnerManager).HasMaxLength(30);
            entity.Property(e => e.PartnerManagerEmail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PartnerManagerPhone)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.PartnerName).HasMaxLength(30);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.Property(e => e.EName)
                .HasMaxLength(50)
                .HasColumnName("eName");
            entity.Property(e => e.EPassword)
                .HasMaxLength(50)
                .HasColumnName("ePassword");
        });

        modelBuilder.Entity<EvenType>(entity =>
        {
            entity.ToTable("EvenType");

            entity.Property(e => e.EvenTypeId).HasColumnName("EvenTypeID");
            entity.Property(e => e.EvenTypeName).HasMaxLength(40);
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.Property(e => e.EventId).HasColumnName("EventID");
            entity.Property(e => e.EventAddress).HasMaxLength(40);
            entity.Property(e => e.EventDate).HasColumnType("datetime");
            entity.Property(e => e.EventName).HasMaxLength(40);
            entity.Property(e => e.EventTypeId).HasColumnName("EventTypeID");
            entity.Property(e => e.EventhostId).HasColumnName("EventhostID");

            entity.HasOne(d => d.EventType).WithMany(p => p.Events)
                .HasForeignKey(d => d.EventTypeId)
                .HasConstraintName("FK_Events_EvenType");

            entity.HasOne(d => d.Eventhost).WithMany(p => p.Events)
                .HasForeignKey(d => d.EventhostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Events_Employees");
        });

        modelBuilder.Entity<Member>(entity =>
        {
            entity.Property(e => e.MAccount)
                .HasMaxLength(50)
                .HasColumnName("mAccount");
            entity.Property(e => e.MCarrier)
                .HasMaxLength(50)
                .HasColumnName("mCarrier");
            entity.Property(e => e.MFilepic)
                .HasMaxLength(100)
                .HasColumnName("mFilepic");
            entity.Property(e => e.MMail)
                .HasMaxLength(50)
                .HasColumnName("mMail");
            entity.Property(e => e.MName)
                .HasMaxLength(50)
                .HasColumnName("mName");
            entity.Property(e => e.MPassword)
                .HasMaxLength(50)
                .HasColumnName("mPassword");
            entity.Property(e => e.MPoints).HasColumnName("mPoints");
        });

        modelBuilder.Entity<Message>(entity =>
        {
            entity.ToTable("Message");

            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Message1)
                .HasMaxLength(500)
                .HasColumnName("Message");
            entity.Property(e => e.MessageDate).HasColumnType("datetime");

            entity.HasOne(d => d.Member).WithMany(p => p.Messages)
                .HasForeignKey(d => d.MemberId)
                .HasConstraintName("FK_Message_Members");
        });

        modelBuilder.Entity<MyCoupon>(entity =>
        {
            entity.HasKey(e => e.McId);

            entity.HasOne(d => d.Dicount).WithMany(p => p.MyCoupons)
                .HasForeignKey(d => d.DicountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MyCoupons_DiscountCodeCart");

            entity.HasOne(d => d.Member).WithMany(p => p.MyCoupons)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MyCoupons_Members");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.Odid);

            entity.Property(e => e.Odid).HasColumnName("ODID");
            entity.Property(e => e.OrderDetailId)
                .HasMaxLength(40)
                .HasColumnName("OrderDetailID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_OrderDetails_Product");
        });

        modelBuilder.Entity<OrderList>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.ToTable("OrderList");

            entity.Property(e => e.Oid).HasColumnName("OID");
            entity.Property(e => e.Cpinvoice)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("CPinvoice");
            entity.Property(e => e.Cptitle)
                .HasMaxLength(30)
                .HasColumnName("CPtitle");
            entity.Property(e => e.CustomerAdd1).HasMaxLength(5);
            entity.Property(e => e.CustomerAdd2).HasMaxLength(7);
            entity.Property(e => e.CustomerAdd3).HasMaxLength(50);
            entity.Property(e => e.CustomerEmail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CustomerName).HasMaxLength(50);
            entity.Property(e => e.CustomerPhone)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.DiscountCode).HasMaxLength(50);
            entity.Property(e => e.DiscountPrice).HasColumnType("money");
            entity.Property(e => e.Is711Pay).HasColumnName("is711Pay");
            entity.Property(e => e.IsMember).HasColumnName("isMember");
            entity.Property(e => e.IsPayed).HasColumnName("isPayed");
            entity.Property(e => e.MemberId).HasColumnName("MemberID");
            entity.Property(e => e.Oidramd)
                .HasMaxLength(50)
                .HasColumnName("OIDramd");
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.OrderDetailId).HasColumnName("OrderDetailID");
            entity.Property(e => e.OrderListNote).HasMaxLength(50);
            entity.Property(e => e.OrderState).HasMaxLength(20);
            entity.Property(e => e.OrderTotal).HasColumnType("money");
            entity.Property(e => e.PayDate).HasColumnType("datetime");
            entity.Property(e => e.PayMethod).HasMaxLength(5);
            entity.Property(e => e.Phinvoice)
                .HasMaxLength(10)
                .HasColumnName("PHinvoice");
            entity.Property(e => e.ShippingAdd1).HasMaxLength(5);
            entity.Property(e => e.ShippingAdd2).HasMaxLength(7);
            entity.Property(e => e.ShippingAdd3).HasMaxLength(50);
            entity.Property(e => e.ShippingFeed).HasColumnType("money");
            entity.Property(e => e.ShippingMethod).HasMaxLength(50);
            entity.Property(e => e.ShippingName).HasMaxLength(5);
            entity.Property(e => e.ShippingPhone)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.ShippingTimeReq).HasMaxLength(40);
            entity.Property(e => e.Store711).HasMaxLength(50);

            entity.HasOne(d => d.Member).WithMany(p => p.OrderLists)
                .HasForeignKey(d => d.MemberId)
                .HasConstraintName("FK_OrderList_Members");

            entity.HasOne(d => d.OrderDetail).WithMany(p => p.OrderLists)
                .HasForeignKey(d => d.OrderDetailId)
                .HasConstraintName("FK_OrderList_OrderDetails");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.Description).HasMaxLength(400);
            entity.Property(e => e.Isbn)
                .HasMaxLength(50)
                .HasColumnName("ISBN");
            entity.Property(e => e.ProductName).HasMaxLength(50);
            entity.Property(e => e.ProductPhoto).HasMaxLength(50);
            entity.Property(e => e.SellingPrice).HasColumnType("money");
            entity.Property(e => e.SupplierId)
                .HasMaxLength(50)
                .HasColumnName("SupplierID");
            entity.Property(e => e.UnitPrice).HasColumnType("money");
            entity.Property(e => e.VersionInfo).HasMaxLength(50);
        });

        modelBuilder.Entity<Relation>(entity =>
        {
            entity.HasKey(e => e.SortId);

            entity.ToTable("Relation");

            entity.Property(e => e.BookTagId).HasColumnName("BookTag_Id");
            entity.Property(e => e.ProductId).HasColumnName("Product_Id");

            entity.HasOne(d => d.BookTag).WithMany(p => p.Relations)
                .HasForeignKey(d => d.BookTagId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Relation_BookTag");

            entity.HasOne(d => d.Product).WithMany(p => p.Relations)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Relation_Product");
        });

        modelBuilder.Entity<SingUp>(entity =>
        {
            entity.HasKey(e => e.SignUpId);

            entity.Property(e => e.SignUpId).HasColumnName("SignUpID");
            entity.Property(e => e.MemberId).HasColumnName("MemberID");

            entity.HasOne(d => d.Event).WithMany(p => p.SingUps)
                .HasForeignKey(d => d.EventId)
                .HasConstraintName("FK_SingUps_Events");

            entity.HasOne(d => d.Member).WithMany(p => p.SingUps)
                .HasForeignKey(d => d.MemberId)
                .HasConstraintName("FK_SingUps_Members");
        });

        modelBuilder.Entity<TradeList>(entity =>
        {
            entity.ToTable("TradeList");

            entity.Property(e => e.Address).HasMaxLength(50);
            entity.Property(e => e.ProductDescribe).HasMaxLength(500);
            entity.Property(e => e.Remark).HasMaxLength(500);
            entity.Property(e => e.State).HasMaxLength(50);

            entity.HasOne(d => d.Member).WithMany(p => p.TradeLists)
                .HasForeignKey(d => d.MemberId)
                .HasConstraintName("FK_TradeList_Members");

            entity.HasOne(d => d.Product).WithMany(p => p.TradeLists)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_TradeList_Product");
        });

        modelBuilder.Entity<WishList>(entity =>
        {
            entity.ToTable("WishList");

            entity.Property(e => e.Address).HasMaxLength(50);
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.ProductDescribe).HasMaxLength(500);
            entity.Property(e => e.Remark).HasMaxLength(500);
            entity.Property(e => e.WishPrice).HasColumnType("money");

            entity.HasOne(d => d.Member).WithMany(p => p.WishLists)
                .HasForeignKey(d => d.MemberId)
                .HasConstraintName("FK_WishList_Members");

            entity.HasOne(d => d.Product).WithMany(p => p.WishLists)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_WishList_Product");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
