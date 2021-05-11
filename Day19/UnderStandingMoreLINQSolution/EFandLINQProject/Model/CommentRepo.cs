using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFandLINQProject.Model
{
    public class CommentRepo : IRepo<Comments>
    {
        private TweetContext _context;
        public CommentRepo()
        {

        }
        public CommentRepo(TweetContext dbContext)
        {
            _context = dbContext;
        }
        public bool Add(Comments t)
        {
            try
            {
                _context.Comments.Add(t);
                _context.SaveChanges();
                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }
        public Comments Get(int id)
        {
            try
            {
                Comments comment = _context.Comments.FirstOrDefault(cmt => cmt.Id == id);
                return comment;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return null;
            }
        }
        public IList<Comments> GetAll()
        {
            if (_context.Comments.Count() > 0)
                return _context.Comments.ToList();
            return null;
        }

        public bool Update(Comments t)
        {
            throw new NotImplementedException();
        }
    }
}
        

       
   
