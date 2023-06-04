namespace ForumApp.Infrastructure.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using ForumApp.Infrastructure.Models;

    public class PostEntityConfig : IEntityTypeConfiguration<Post>
    {
        private readonly PostSeeder seeder;

        public PostEntityConfig()
        {
            seeder = new PostSeeder();
        }
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasData(this.seeder.GeneratePosts());     
        }
    }
}
