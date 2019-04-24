using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsCampusApp.Services.Interface;

namespace WinFormsCampusApp.Services.Implementation
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected ApplicationDBcontext _context { get; set; }

        public Repository(ApplicationDBcontext context) => _context = context;

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            var type = _context.Set<T>().Find(id);

            if (type != null)
            {
                this._context.Set<T>().Remove(type);
             }
           
        }

        public int Save()
        {
            return  _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Attach(entity);
        }
    }
}
