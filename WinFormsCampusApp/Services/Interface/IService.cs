using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsCampusApp.Services.Interface
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);

        void Remove(int id);

        T GetById(int id);

        IEnumerable<T> GetAll();

        int Save();
    }
}
