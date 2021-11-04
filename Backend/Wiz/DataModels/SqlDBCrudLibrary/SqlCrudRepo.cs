using AbstractDataModels.Repo;
using AbstractModels;
using DataModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SqlDBCrudLibrary
{
    public class SqlCrudRepo<T> : ICrudRepo<T> where T : class, IDataClass
    {
        private readonly DbSet<T> DbSet;
        private readonly WizDBContext dBContext;
        public SqlCrudRepo(
            WizDBContext context

            ) {
            DbSet = context.Set<T>();
            dBContext = context;
        }
        public IQueryable<T> QueryAble => DbSet.AsQueryable<T>();

        public void DeleteRecord(T document)
        {
            var deleteddocument = QueryAble.First(a => a.Equals(document)) as T;
            DbSet.Remove(deleteddocument);
            dBContext.SaveChanges();
        }

        public void DeleteRecord(string documentId)
        {
            var deleteddocument = QueryAble.First(a => a.Id == documentId) as T;
            DbSet.Remove(deleteddocument);
            dBContext.SaveChanges();
        }

        public IEnumerable<T> GetAllDocuments(string UserId)
        {
            var documents = QueryAble.Where(a => a.CustomerId == UserId);
            return documents;
        }

        public T GetSpecificRecord(string documentId)
        {
            var document = QueryAble.FirstOrDefault(a => a.Id == documentId);
            return document;
        }

        public T UpsertRecord(T document)
        {
            if (document.Id == null)
            {
                document.Id = Guid.NewGuid().ToString();
                DbSet.Add(document);
            }
            else
            {
                DbSet.Update(document);
            }
            dBContext.SaveChanges();
            return document;
        }
    }

}
