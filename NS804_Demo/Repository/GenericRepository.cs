using NS804_Demo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NS804_Demo.Repository
{
    /// <summary>
    /// GenericRepository<T, PK>, as it's name says is a generic
    /// repository for the entities that extends BaseModel.
    /// T refers to the model and PK is the type of the primary
    /// key of this entity. 
    /// </summary>
    public class GenericRepository<T, PK> where T : BaseModel<PK>
    {

        private readonly AppDBContext _ctx;
        private IDbSet<T> _entities;
        public List<string> ErrorMessages = new List<string>();
        public GenericRepository(AppDBContext dbContext) {
            _ctx = dbContext;
        }

        public GenericRepository()
        {
            _ctx = new AppDBContext();
        }

        private IDbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                {
                    _entities = _ctx.Set<T>();
                }
                return _entities;
            }
        }

        public IQueryable<T> Get()
        {
            return  this.Entities
                .Where(itm => itm.IsActive)
                .AsQueryable<T>();
        }

        public T GetById(PK id)
        {
            return this.Entities
                .Where(itm => itm.IsActive)
                .FirstOrDefault(e => e.Id.ToString() == id.ToString() );
        }

        public bool Update(PK id, T entry)
        {

            try
            {
                if (!Exists(id))
                    return false;

                entry.LastUpdate = DateTime.Now;

                _ctx.SaveChanges();
            }
            catch (Exception error)
            {
                this.ErrorMessages.Add(error.Message);
                return false;
            }

            return true;
        }

        public T Save(T entry)
        {

            entry.IsActive = true;
            entry.CreationDate = DateTime.Now;
            entry.LastUpdate = DateTime.Now;

            this.Entities.Add(entry);
            _ctx.SaveChanges();

            return entry;
        }


        public bool Delete(long id)
        {
            try {
                T quote = Entities.Find(id);
                quote.IsActive = false;
                _ctx.SaveChanges();

                return true;

            } catch (Exception error) {
                this.ErrorMessages.Add(error.Message);
                return false;
            }
        }

        public  void Dispose(bool disposing)
        {
            if (disposing)
            {
                _ctx.Dispose();
            }
        }

        public bool Exists(PK id)
        {
            return Entities
                .Where(itm => itm.IsActive)
                .Count(e => e.Id.ToString() == id.ToString())  > 0;
        }
    }
}