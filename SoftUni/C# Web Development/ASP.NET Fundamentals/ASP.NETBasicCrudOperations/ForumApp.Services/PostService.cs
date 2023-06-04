namespace ForumApp.Services
{
    using Microsoft.EntityFrameworkCore;

    using ForumApp.Services.Contracts;

    using ForumApp.Infrastructure;
    using ForumApp.Infrastructure.Models;

    using ForumApp.ViewModels.Export;
    using ForumApp.ViewModels.Import;


    public class PostService : IPostService
    {
        private readonly ForumAppDbContext context;

        public PostService(ForumAppDbContext _context)
        {
            context = _context;
        }

        public async Task<ICollection<PostViewModel>> AllAsync()
        {
            var posts = await context
                .Posts
                .Select(p => new PostViewModel()
                {
                    Id = p.Id.ToString(),
                    Title = p.Title,
                    Content = p.Content,
                })
                .AsNoTracking()
                .ToListAsync();

            return posts;
        }

        public async Task AddAsync(ImportPostModel model)
        {
            await context.AddAsync(new Post()
            {
                Title = model.Title,
                Content = model.Content,
            });

            await context.SaveChangesAsync();
        }

        public async Task<PostViewModel> GetEditAsync(string id)
        {
            var post = await context
                .Posts
                .FirstAsync(p => p.Id.ToString() == id);

            return new PostViewModel()
            {
                Title = post.Title,
                Content = post.Content,
            };
        }

        public async Task EditAsync(string id, PostViewModel model)
        {
            var post = await context
                .Posts
                .FirstAsync(p => p.Id.ToString() == id);

            post.Title = model.Title;
            post.Content = model.Content;

            await this.context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var post = await this.context
                .Posts
                .FirstAsync(p => p.Id.ToString() == id);

            this.context.Remove(post);
            
            await this.context.SaveChangesAsync();
                
        }
    }
}
