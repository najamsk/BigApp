using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace BigApp.Models
{ 
    public class TagRepository : ITagRepository
    {
        BigAppContext context = new BigAppContext();

        public IQueryable<Tag> All
        {
            get { return context.Tags; }
        }

        public IQueryable<Tag> AllIncluding(params Expression<Func<Tag, object>>[] includeProperties)
        {
            IQueryable<Tag> query = context.Tags;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Tag Find(int id)
        {
            return context.Tags.Find(id);
        }

        public void InsertOrUpdate(Tag tag)
        {
            if (tag.Id == default(int)) {
                // New entity
                context.Tags.Add(tag);
            } else {
                // Existing entity
                context.Entry(tag).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var tag = context.Tags.Find(id);
            context.Tags.Remove(tag);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }

    public interface ITagRepository
    {
        IQueryable<Tag> All { get; }
        IQueryable<Tag> AllIncluding(params Expression<Func<Tag, object>>[] includeProperties);
        Tag Find(int id);
        void InsertOrUpdate(Tag tag);
        void Delete(int id);
        void Save();
    }
}