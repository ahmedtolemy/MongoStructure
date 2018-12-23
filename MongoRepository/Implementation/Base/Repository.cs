using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoDomain;
using MongoPresistence;
using MongoRepository.Contract.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MongoRepository.Implementation.Base
{
    public class Repository<T> : IRepository<T>
        where T : class,new()
    {
        protected Repository(MongoContext context)
        {
            Context = context;
        }
        protected MongoContext Context { get; set; }
        public IMongoQueryable<T> Query {
            get
            {
                return Collection.AsQueryable<T>();
            }
            set
            {
                Query = value;
            }
        }
        public IMongoCollection<T> Collection
        {
            get
            {
                return Context.Database.GetCollection<T>(typeof(T).Name);
            }
            set
            {
                Collection = value;
            }
        }

        public T GetOne(Expression<Func<T, bool>> expression)
        {
            return Collection.Find(expression).FirstOrDefault();
        }
        public List<T> Get(FilterDefinition<T> expression,SortDefinition<T> sort)
        {

            return Collection.Find(expression).Sort(sort).ToList();
        }
        public List<T> All()
        {
            return Collection.AsQueryable().ToList();
        }
        public T FindOneAndUpdate(Expression<Func<T, bool>> expression, UpdateDefinition<T> update, FindOneAndUpdateOptions<T> option)
        {
            return Collection.FindOneAndUpdate(expression, update, option);
        }

        public void UpdateOne(FilterDefinition<T> expression, UpdateDefinition<T> update)
        {
            Collection.UpdateOne(expression, update);
        }

        public void DeleteOne(Expression<Func<T, bool>> expression)
        {
            Collection.DeleteOne(expression);
        }

        public void InsertMany(IEnumerable<T> items)
        {
            Collection.InsertMany(items);
        }

        public void InsertOne(T item)
        {
            Collection.InsertOne(item);
        }
      
    }
}
