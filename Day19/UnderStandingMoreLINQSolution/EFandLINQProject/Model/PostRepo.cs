using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFandLINQProject.Model
{
    public class PostRepo:IRepo<Posts>
    {
        private TweetContext _context;
        public PostRepo()
        {

        }
        public PostRepo(TweetContext dbContext)
        {
            _context = dbContext;
        }
        public bool Add(Posts t)
        {
            try
            {
                _context.Posts.Add(t);
                _context.SaveChanges();
                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }

        public Posts Get(int id)
        {
            try
            {
                Posts posts = _context.Posts.FirstOrDefault(cmt => cmt.Id == id);
                return posts;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return null;
            }
        }

        public IList<Posts> GetAll()
        {
            if (_context.Posts.Count() > 0)
                return _context.Posts.ToList();
            return null;
        }

        public bool Update(Posts t)
        {
            try
            {
                _context.Posts.Update(t);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }
    }
}





