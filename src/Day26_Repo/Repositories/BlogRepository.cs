using Day26_Repo.Data;
using Day26_Repo.Interfaces;
using Day26_Repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day26_Repo.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private ApplicationDbContext _db;
        public BlogRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<Blog> GetBlogs()
        {
            return _db.Blogs.ToList();
        }

        public Blog GetBlogById(int id)
        {
            return _db.Blogs.Where(b => b.Id == id).FirstOrDefault();
        }

        public void SaveBlog(Blog blog)
        {
            if(blog.Id == 0)
            {
                _db.Blogs.Add(blog);
                _db.SaveChanges();
            }
            else
            {
                var blogToEdit = _db.Blogs.Where(b => b.Id == blog.Id).FirstOrDefault();
                blogToEdit.Title = blog.Title;
                blogToEdit.Message = blog.Message;
                _db.SaveChanges();
            }
        }

        public void DeleteBlog(int id)
        {
            var blogToDelete = _db.Blogs.Where(b => b.Id == id).FirstOrDefault();
            _db.Blogs.Remove(blogToDelete);
            _db.SaveChanges();
        }
    }
}
