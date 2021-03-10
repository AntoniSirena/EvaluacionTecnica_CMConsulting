using EvaluacionTecnica.DBContext;
using EvaluacionTecnica.Repository.IRepository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EvaluacionTecnica.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        private MyDBcontext _context = null;
        private IDbSet<T> table = null;

        public GenericRepository()
        {
            _context = new MyDBcontext();
            table = _context.Set<T>();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return table.ToList();
        }

        public virtual T GetById(object id)
        {
            return table.Find(id);
        }

        public virtual dynamic Create(dynamic obj)
        {
            obj.CreationTime = DateTime.Now;
            obj.CreatorUserId = 00;
            obj.IsActive = true;
            obj.Fecha_Transacion = DateTime.Now;

            //Convirtiendo el objeto dinamico a la entidad acutal
            T entity = JsonConvert.DeserializeObject<T>(obj.ToString());

            table.Attach(entity);
            dynamic result = table.Add(entity);

            return result;
        }


        public virtual void Update(dynamic obj)
        {
            obj.LastModificationTime = DateTime.Now;
            obj.Fecha_Transacion = DateTime.Now;
            obj.LastModifierUserId = 00;
            obj.IsActive = true;
            obj.IsDeleted = false;

            //Convirtiendo el objeto dinamico a la entidad acutal
            T entity = JsonConvert.DeserializeObject<T>(obj.ToString());

            table.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(object id)
        {
            dynamic entity = table.Find(id);

            entity.DeletionTime = DateTime.Now;
            entity.Fecha_Transacion = DateTime.Now;
            entity.DeleterUserId = 00;
            entity.IsActive = false;
            entity.IsDeleted = true;

            table.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }


        public virtual void Save()
        {
            _context.SaveChanges();
        }
    }
}