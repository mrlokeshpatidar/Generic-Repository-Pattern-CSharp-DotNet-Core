using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RepositoryPattern.Data;
using RepositoryPattern.Infrastructure;
using RepositoryPattern.Infrastructure.Models;


namespace RepositoryPattern.Service
{
    public class UserDetailRepository : IUserDetail
    {
        private UserDetailContext _context;
        public UserDetailRepository(UserDetailContext context)
        {
            _context = context;
        }
        public void Delete(UserDetail userdetail)
        {
            _context.UserDetails.Remove(userdetail);
        }

        public List<UserDetail> GetAll()
        {
            return _context.UserDetails.ToList();
        }

        public UserDetail GetById(int id)
        {
            return _context.UserDetails.Where(x => x.id == id).FirstOrDefault();
        }

        public void Insert(UserDetail userdetail)
        {
            _context.UserDetails.Add(userdetail);
        }

        public void Update(UserDetail userdetail)
        {
            _context.UserDetails.Update(userdetail);
        }

        public void Save()
        {
            _context.SaveChanges();
        }


    }
}
