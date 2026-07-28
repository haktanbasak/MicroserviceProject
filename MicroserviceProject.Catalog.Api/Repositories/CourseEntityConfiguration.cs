using MicroserviceProject.Catalog.Api.Features.Courses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MongoDB.EntityFrameworkCore.Extensions;

namespace MicroserviceProject.Catalog.Api.Repositories
{
    public class CourseEntityConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            //MongoDB'de tablo yerine collection, satır yerine document, sütun yerine field terimleri kullanılır.(NoSQL)
           builder.ToCollection("courses");
           builder.HasKey(x => x.Id);
           builder.Property(x => x.Id).ValueGeneratedNever(); //Kendi id'mizi oluşturacağımız için EF Core'un otomatik id oluşturmasını engelliyoruz.
           builder.Property(x => x.Name).HasElementName("name").HasMaxLength(100);
           builder.Property(x => x.Description).HasElementName("description").HasMaxLength(1000);
           builder.Property(x => x.Created).HasElementName("created");
           builder.Property(x => x.UserId).HasElementName("userId");
           builder.Property(x => x.Picture).HasElementName("picture");
           builder.Property(x => x.Price).HasElementName("price");
           builder.Property(x => x.CategoryId).HasElementName("categoryId");
           builder.Ignore(x => x.Category);

            // Course entity'si Feature değerini kendi içinde tutacak, ayrı bir collection oluşturulmayacak.
           builder.OwnsOne(c => c.Feature, feature =>
            {
                feature.HasElementName("feature");
                feature.Property(f => f.Duration).HasElementName("duration");
                feature.Property(f => f.Rating).HasElementName("rating");
                feature.Property(f => f.EducatorFullName).HasElementName("educatorFullName").HasMaxLength(100);
            });
        }
    }
}
