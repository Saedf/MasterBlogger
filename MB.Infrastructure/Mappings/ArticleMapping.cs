using MB.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MB.Infrastructure.Mappings
{
    public class ArticleMapping:IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.ToTable("Articles");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).HasMaxLength(350);
            builder.Property(x => x.Content).HasColumnName("Body");
            builder.Property(x => x.Picture).HasMaxLength(300);
            builder.Property(x => x.PictureAlt).HasMaxLength(300);
            builder.Property(x => x.PictureTitle).HasMaxLength(300);
            builder.Property(x => x.ShortDescription).HasMaxLength(1500);
            builder.Property(x => x.CreationDate);
            builder.Property(x => x.IsDeleted);
            builder.HasOne(x => x.ArticleCategory)
                .WithMany(x => x.Articles)
                .HasForeignKey(x => x.ArticleCategoryId);

            builder.HasMany(x => x.Comments)
                .WithOne(x => x.Article)
                .HasForeignKey(x => x.ArticleId);
        }
    }
}
