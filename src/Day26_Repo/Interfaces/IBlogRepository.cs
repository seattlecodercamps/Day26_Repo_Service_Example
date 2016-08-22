using System.Collections.Generic;
using Day26_Repo.Models;

namespace Day26_Repo.Interfaces
{
    public interface IBlogRepository
    {
        void DeleteBlog(int id);
        Blog GetBlogById(int id);
        List<Blog> GetBlogs();
        void SaveBlog(Blog blog);
    }
}