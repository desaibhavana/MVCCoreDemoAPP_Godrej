using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MVCCoreDemoAPP_Godrej.Models;

public partial class TrainingDbContext : DbContext
{
    public TrainingDbContext()
    {
    }

    public TrainingDbContext(DbContextOptions<TrainingDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Dept> Depts { get; set; }

    public virtual DbSet<Emp> Emps { get; set; }

    public virtual DbSet<Userdatum> Userdata { get; set; }

    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Dept>(entity =>
        {
            entity.HasKey(e => e.Deptno).HasName("DEPT_deptno_pk1");

            entity.ToTable("DEPT");

            entity.HasIndex(e => e.Dname, "DEPT_Dname_UNQ").IsUnique();

            entity.Property(e => e.Deptno)
                .ValueGeneratedNever()
                .HasColumnName("DEPTNO");
            entity.Property(e => e.Dname)
                .HasMaxLength(14)
                .IsUnicode(false)
                .HasColumnName("DNAME");
            entity.Property(e => e.Loc)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("LOC");
        });

        modelBuilder.Entity<Emp>(entity =>
        {
            entity.HasKey(e => e.Empno).HasName("EMP_EMPNO_PK");

            entity.ToTable("EMP");

            entity.Property(e => e.Empno)
                .ValueGeneratedNever()
                .HasColumnName("EMPNO");
            entity.Property(e => e.Comm)
                .HasColumnType("numeric(7, 2)")
                .HasColumnName("COMM");
            entity.Property(e => e.Deptno).HasColumnName("DEPTNO");
            entity.Property(e => e.Ename)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("ENAME");
            entity.Property(e => e.Hiredate)
                .HasColumnType("datetime")
                .HasColumnName("HIREDATE");
            entity.Property(e => e.Job)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("JOB");
            entity.Property(e => e.Mgr).HasColumnName("MGR");
            entity.Property(e => e.Sal)
                .HasColumnType("numeric(7, 2)")
                .HasColumnName("SAL");

            entity.HasOne(d => d.DeptnoNavigation).WithMany(p => p.Emps)
                .HasForeignKey(d => d.Deptno)
                .HasConstraintName("EMP_DEPTNO_FK");

            entity.HasOne(d => d.MgrNavigation).WithMany(p => p.InverseMgrNavigation)
                .HasForeignKey(d => d.Mgr)
                .HasConstraintName("EMP_MGR_SK");
        });

        modelBuilder.Entity<Userdatum>(entity =>
        {
            entity.HasKey(e => e.Username).HasName("PK__USERDATA__B15BE12F34DC26F9");

            entity.ToTable("USERDATA");

            entity.Property(e => e.Username)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("USERNAME");
            entity.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("PASSWORD");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
