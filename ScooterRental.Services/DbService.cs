using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ScooterRental.Core;
using ScooterRental.Core.Interfaces;
using ScooterRental.DB;

namespace ScooterRental.Services
{
    public class DbService : IDbService
    {
        protected IScooterDbContext _context;

        public DbService(IScooterDbContext context)
        {
            _context = context;
        }

        public void Create<T>(T entity) where T : Entity
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Delete<T>(T entity) where T : Entity
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public void Update<T>(T entity) where T : Entity
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public List<T> GetAll<T>() where T : Entity
        {
            return _context.Set<T>().ToList();
        }

        public T GetById<T>(int id) where T : Entity
        {
            return _context.Set<T>().SingleOrDefault(x => x.Id == id);
        }
    }
}