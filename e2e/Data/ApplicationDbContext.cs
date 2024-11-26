using e2e.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace e2e.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public virtual DbSet<Area> Areas { get; set; }
        public virtual DbSet<Campaign> Campaigns { get; set; }

        public virtual DbSet<CampaignStatus> CampaignStatuses { get; set; }

        public virtual DbSet<CampaignType> CampaignTypes { get; set; }

        public virtual DbSet<MasterDocument> MasterDocuments { get; set; }

        public virtual DbSet<ParticipantDetail> ParticipantDetails { get; set; }

        public virtual DbSet<ProductsService> ProductsServices { get; set; }

        public virtual DbSet<Profile> Profiles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<Area>(entity =>
            {
                entity.HasKey(e => e.AreaId).HasName("PK__Areas__70B82028B6F45229");

                entity.HasIndex(e => e.AreaName, "UQ__Areas__8EB6AF57CB0732C7").IsUnique();

                entity.Property(e => e.AreaId)
                    .ValueGeneratedNever()
                    .HasColumnName("AreaID");
                entity.Property(e => e.AreaDescription)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.AreaName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            builder.Entity<Campaign>(entity =>
            {
                entity.HasKey(e => e.CampaignId).HasName("PK__Campaign__3F5E8D7944FFED52");

                entity.ToTable(tb => tb.HasTrigger("TRG_UpdateTimestamp_On_Campaigns"));

                entity.Property(e => e.CampaignId)
                    .ValueGeneratedNever()
                    .HasColumnName("CampaignID");
                entity.Property(e => e.CampaignTypeId).HasColumnName("CampaignTypeID");
                entity.Property(e => e.ClientName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
                entity.Property(e => e.ProductServiceId).HasColumnName("ProductServiceID");
                entity.Property(e => e.StatusId).HasColumnName("StatusID");
                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.CampaignType).WithMany(p => p.Campaigns)
                    .HasForeignKey(d => d.CampaignTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Campaigns__Campa__59FA5E80");

                entity.HasOne(d => d.ProductService).WithMany(p => p.Campaigns)
                    .HasForeignKey(d => d.ProductServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Campaigns__Produ__5AEE82B9");

                entity.HasOne(d => d.Status).WithMany(p => p.Campaigns)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Campaigns__Statu__5BE2A6F2");
            });

            builder.Entity<CampaignStatus>(entity =>
            {
                entity.HasKey(e => e.CampaignStatusId).HasName("PK__Campaign__165A0AB352BAC524");

                entity.Property(e => e.CampaignStatusId)
                    .ValueGeneratedNever()
                    .HasColumnName("CampaignStatusID");
                entity.Property(e => e.CampaignStatusDescription)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.CampaignStatusName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            builder.Entity<CampaignType>(entity =>
            {
                entity.HasKey(e => e.CampaignTypeId).HasName("PK__Campaign__68FE2790011D084F");

                entity.Property(e => e.CampaignTypeId)
                    .ValueGeneratedNever()
                    .HasColumnName("CampaignTypeID");
                entity.Property(e => e.CampaignTypeDescription)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.CampaignTypeName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            builder.Entity<MasterDocument>(entity =>
            {
                entity.HasKey(e => e.CampaignId).HasName("PK__MasterDo__3F5E8D79CDA3F592");

                entity.ToTable("MasterDocument");

                entity.Property(e => e.CampaignId)
                    .ValueGeneratedNever()
                    .HasColumnName("CampaignID");
                entity.Property(e => e.DocumentStatus)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Campaign).WithOne(p => p.MasterDocument)
                    .HasForeignKey<MasterDocument>(d => d.CampaignId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MasterDoc__Campa__08B54D69");
            });

            builder.Entity<ParticipantDetail>(entity =>
            {
                entity.HasKey(e => e.DetailId).HasName("PK__Particip__135C316D9A2DF9D8");

                entity.Property(e => e.DetailId).HasDefaultValueSql("(newsequentialid())");
                entity.Property(e => e.AreaName)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(e => e.CampaignId).HasColumnName("CampaignID");
                entity.Property(e => e.FieldType)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(e => e.ParticipantName)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(e => e.ParticipantSectionName)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(e => e.TitleName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Campaign).WithMany(p => p.ParticipantDetails)
                    .HasForeignKey(d => d.CampaignId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Participa__Campa__2A164134");
            });

            builder.Entity<ProductsService>(entity =>
            {
                entity.HasKey(e => e.ProductServiceId).HasName("PK__Products__A4EAC406D795E2E3");

                entity.Property(e => e.ProductServiceId)
                    .ValueGeneratedNever()
                    .HasColumnName("ProductServiceID");
                entity.Property(e => e.ProductServiceDescription)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.ProductServiceName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            builder.Entity<Profile>(entity =>
            {
                entity.HasKey(e => e.ProfileId).HasName("PK__Profiles__290C8884B2E42582");

                entity.HasIndex(e => e.ProfileName, "UQ__Profiles__A8A4D470F56649AE").IsUnique();

                entity.Property(e => e.ProfileId)
                    .ValueGeneratedNever()
                    .HasColumnName("ProfileID");
                entity.Property(e => e.ProfileDescription)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.ProfileName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            builder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCACD3D55106");

                entity.ToTable(tb => tb.HasTrigger("TRG_UpdateTimestamp"));

                entity.HasIndex(e => e.EmployeeNumber, "UQ__Users__8D663598E3C4AFE5").IsUnique();

                entity.Property(e => e.UserId)
                    .ValueGeneratedNever()
                    .HasColumnName("UserID");
                entity.Property(e => e.AreaId).HasColumnName("AreaID");
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.EmployeeNumber)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.FailedAttemps).HasDefaultValue(0);
                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength();
                entity.Property(e => e.LastPasswordUpdated).HasDefaultValueSql("(getdate())");
                entity.Property(e => e.PasswordHash)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
                entity.Property(e => e.ProfileId).HasColumnName("ProfileID");
                entity.Property(e => e.Status).HasDefaultValue(true);
                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");
            });
        }
    }
}
