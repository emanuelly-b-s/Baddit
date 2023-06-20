using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Model;

public partial class ProjRedditContext : DbContext
{
    public ProjRedditContext()
    {
    }

    public ProjRedditContext(DbContextOptions<ProjRedditContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Forum> Forums { get; set; }

    public virtual DbSet<ImageDatum> ImageData { get; set; }

    public virtual DbSet<LikeDislaike> LikeDislaikes { get; set; }

    public virtual DbSet<LocationPhoto> LocationPhotos { get; set; }

    public virtual DbSet<ParticipantForum> ParticipantForums { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<UserDittopium> UserDittopia { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=CT-C-0013M\\SQLEXPRESS;Initial Catalog=projReddit;Integrated Security=True;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Comment__3214EC274C8EE629");

            entity.ToTable("Comment");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CommentText).IsUnicode(false);
            entity.Property(e => e.ParticipantComment)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.ParticipantCommentNavigation).WithMany(p => p.Comments)
                .HasForeignKey(d => d.ParticipantComment)
                .HasConstraintName("FK__Comment__Partici__33D4B598");

            entity.HasOne(d => d.PostCommentNavigation).WithMany(p => p.Comments)
                .HasForeignKey(d => d.PostComment)
                .HasConstraintName("FK__Comment__PostCom__34C8D9D1");
        });

        modelBuilder.Entity<Forum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Forum__3214EC27A5993B50");

            entity.ToTable("Forum");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Creator)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DescriptionPost)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ForumName)
                .HasMaxLength(55)
                .IsUnicode(false);

            entity.HasOne(d => d.CreatorNavigation).WithMany(p => p.Forums)
                .HasForeignKey(d => d.Creator)
                .HasConstraintName("FK__Forum__Creator__267ABA7A");
        });

        modelBuilder.Entity<ImageDatum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ImageDat__3214EC2772EC8CBA");

            entity.Property(e => e.Id).HasColumnName("ID");
        });

        modelBuilder.Entity<LikeDislaike>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LikeDisl__3214EC27EF552168");

            entity.ToTable("LikeDislaike");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ParticipantLikeDislaike)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.ParticipantLikeDislaikeNavigation).WithMany(p => p.LikeDislaikes)
                .HasForeignKey(d => d.ParticipantLikeDislaike)
                .HasConstraintName("FK__LikeDisla__Parti__37A5467C");

            entity.HasOne(d => d.PostLikeDislaikeNavigation).WithMany(p => p.LikeDislaikes)
                .HasForeignKey(d => d.PostLikeDislaike)
                .HasConstraintName("FK__LikeDisla__PostL__38996AB5");
        });

        modelBuilder.Entity<LocationPhoto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Location__3214EC27EC5591F0");

            entity.ToTable("LocationPhoto");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Nome)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.PostParticipant)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.PhotoNavigation).WithMany(p => p.LocationPhotos)
                .HasForeignKey(d => d.Photo)
                .HasConstraintName("FK__LocationP__Photo__3D5E1FD2");

            entity.HasOne(d => d.PostParticipantNavigation).WithMany(p => p.LocationPhotos)
                .HasForeignKey(d => d.PostParticipant)
                .HasConstraintName("FK__LocationP__PostP__3E52440B");

            entity.HasOne(d => d.PostPhotoNavigation).WithMany(p => p.LocationPhotos)
                .HasForeignKey(d => d.PostPhoto)
                .HasConstraintName("FK__LocationP__PostP__3F466844");
        });

        modelBuilder.Entity<ParticipantForum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Particip__3214EC276BA4A83D");

            entity.ToTable("ParticipantForum");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ParticipantForum1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ParticipantForum");

            entity.HasOne(d => d.ForumNavigation).WithMany(p => p.ParticipantForums)
                .HasForeignKey(d => d.Forum)
                .HasConstraintName("FK__Participa__Forum__2B3F6F97");

            entity.HasOne(d => d.ParticipantForum1Navigation).WithMany(p => p.ParticipantForums)
                .HasForeignKey(d => d.ParticipantForum1)
                .HasConstraintName("FK__Participa__Parti__2C3393D0");

            entity.HasOne(d => d.PositionParticipantNavigation).WithMany(p => p.ParticipantForums)
                .HasForeignKey(d => d.PositionParticipant)
                .HasConstraintName("FK__Participa__Posit__2D27B809");
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Position__3214EC27E07E78D9");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.PositionName)
                .HasMaxLength(55)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Post__3214EC27AA40E2D1");

            entity.ToTable("Post");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.PostDate).HasColumnType("date");
            entity.Property(e => e.PostParticipant)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PostText)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Tittle)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.ForumNavigation).WithMany(p => p.Posts)
                .HasForeignKey(d => d.Forum)
                .HasConstraintName("FK__Post__Forum__300424B4");

            entity.HasOne(d => d.PostParticipantNavigation).WithMany(p => p.Posts)
                .HasForeignKey(d => d.PostParticipant)
                .HasConstraintName("FK__Post__PostPartic__30F848ED");
        });

        modelBuilder.Entity<UserDittopium>(entity =>
        {
            entity.HasKey(e => e.Email).HasName("PK__User_Dit__A9D1053574AB7A26");

            entity.ToTable("User_Dittopia");

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DateBirth).HasColumnType("date");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.LastName)
                .HasMaxLength(55)
                .IsUnicode(false);
            entity.Property(e => e.NickUser)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.PasswordUser)
                .HasMaxLength(55)
                .IsUnicode(false);
            entity.Property(e => e.SaldPassword).IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(55)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
