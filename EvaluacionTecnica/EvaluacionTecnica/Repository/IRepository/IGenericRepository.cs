using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluacionTecnica.Repository.IRepository
{
    interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(object id);
        dynamic Create(dynamic obj);
        void Update(dynamic obj);
        void Delete(object id);
        void Save();
    }
}
