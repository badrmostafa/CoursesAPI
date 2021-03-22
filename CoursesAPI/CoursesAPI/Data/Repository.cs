using CoursesAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoursesAPI.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public Repository(CourseContext context)
        {
            Context = context;
            Entity = Context.Set<T>();
        }

        public CourseContext Context { get; }
        public DbSet<T> Entity { get; set; }

        public void Add(T t)
        {
            Entity.Add(t);
            Context.SaveChanges();
        }

        public void Delete(int id)
        {
            T t = GetById(id);
            if (t == null)
                throw new NullReferenceException();
            Entity.Remove(t);
            Context.SaveChanges();
        }

        public List<T> GetAll()
        {
            return Entity.ToList();
        }

        public T GetById(int id)
        {
            return Entity.Find(id);
        }

        public void Update(T t)
        {
            Entity.Update(t);
            Context.SaveChanges();
        }
    }
}
