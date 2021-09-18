using RepositoryPattern.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryPattern.Infrastructure
{
    public interface IUserDetail
    {
        List<UserDetail> GetAll();

        UserDetail GetById(int Id);

        void Insert(UserDetail userdetail);

        void Update(UserDetail userdetail);

        void Delete(UserDetail userdetail);

        void Save();
    }
}
