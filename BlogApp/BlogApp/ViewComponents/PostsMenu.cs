using BlogApp.Data.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BlogApp.ViewComponents
{
    public class PostsMenu : ViewComponent
    {
        private IPostRepository _postRepository;

        public PostsMenu(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public  async Task<IViewComponentResult> InvokeAsync()
        {
            return  View( await
                _postRepository
                .Posts
                .OrderByDescending(p => p.PublishedOn)
                .Take(5)
                .ToListAsync()
            );
        }
    }
}