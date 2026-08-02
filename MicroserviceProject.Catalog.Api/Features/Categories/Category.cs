using MicroserviceProject.Catalog.Api.Features.Courses;

namespace MicroserviceProject.Catalog.Api.Features.Categories
{
    public class Category: BaseEntity
    {
        public string Name { get; set; } = default!;
        public List<Course>? Courses{ get; set; }
    }
}
