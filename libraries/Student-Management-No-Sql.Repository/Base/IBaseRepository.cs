using Student_Management_No_Sql.Entities.Base;
using System.Linq.Expressions;

namespace Student_Management_No_Sql.Repository.Base
{
    public interface IBaseRepository<TDocument>
        where TDocument : BaseDocument
    {
        IQueryable<TDocument> AsQueryable();
        Task<IList<TDocument>> GetsAsync();
        Task<IList<TDocument>> GetsAsync(Expression<Func<TDocument, bool>> filterExpression);
        Task<IList<TProjected>> ProjectToAsync<TProjected>(
            Expression<Func<TDocument, bool>> filterExpression,
            Expression<Func<TDocument, TProjected>> projectionExpression);

        TDocument FindOne(Expression<Func<TDocument, bool>> filterExpression);

        Task<TDocument> FindOneAsync(Expression<Func<TDocument, bool>> filterExpression);

        TDocument FindById(string id); 

        Task<TDocument> FindByIdAsync(string id);

        void InsertOne(TDocument document);

        Task InsertOneAsync(TDocument document);

        void InsertMany(ICollection<TDocument> documents);

        Task InsertManyAsync(ICollection<TDocument> documents);

        void ReplaceOne(TDocument document);

        Task ReplaceOneAsync(TDocument document);

        void DeleteOne(Expression<Func<TDocument, bool>> filterExpression);

        Task DeleteOneAsync(Expression<Func<TDocument, bool>> filterExpression);

        void DeleteById(string id);

        Task DeleteByIdAsync(string id);

        void DeleteMany(Expression<Func<TDocument, bool>> filterExpression);

        Task DeleteManyAsync(Expression<Func<TDocument, bool>> filterExpression);
    }
}
