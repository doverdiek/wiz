using AbstractModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractDataModels.Repo
{
    public interface ICrudRepo<T> where T: IDataClass
    { 
        public void DeleteRecord(T document);
        public void DeleteRecord(string documentId);
        public IEnumerable<T> GetAllDocuments(string UserId);
        public T GetSpecificRecord(string documentId);
        public T UpsertRecord(T document);
        public IQueryable<T> QueryAble { get; }

    }
}
