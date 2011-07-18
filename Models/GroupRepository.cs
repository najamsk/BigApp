using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace BigApp.Models
{ 
    public class GroupRepository : IGroupRepository
    {
        BigAppContext context = new BigAppContext();

        public IQueryable<Group> All
        {
            get { return context.Groups; }
        }

        public IQueryable<Group> AllIncluding(params Expression<Func<Group, object>>[] includeProperties)
        {
            IQueryable<Group> query = context.Groups;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Group Find(int id)
        {
            return context.Groups.Find(id);
        }

        public void InsertOrUpdate(Group group)
        {
            if (group.Id == default(int)) {
                // New entity
                context.Groups.Add(group);
            } else {
                // Existing entity
                context.Entry(group).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var group = context.Groups.Find(id);
            context.Groups.Remove(group);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }

    public interface IGroupRepository
    {
        IQueryable<Group> All { get; }
        IQueryable<Group> AllIncluding(params Expression<Func<Group, object>>[] includeProperties);
        Group Find(int id);
        void InsertOrUpdate(Group group);
        void Delete(int id);
        void Save();
    }
}