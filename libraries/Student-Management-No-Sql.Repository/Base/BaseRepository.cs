using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Student_Management_No_Sql.Infratructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_No_Sql.Repository.Base
{
    /// <summary>
    /// CN 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="CN">CN is Collection Name</typeparam>
    public class BaseRepository<T, CN> : IBaseRepository<T, CN>
        where T : class
    {
        private readonly IMongoCollection<T> _collection;
        private readonly StudentDbSettings? _studentDbSettings;

        public BaseRepository(IOptions<StudentDbSettings> studentDbSettings, CN collectionName)
        {
            if (collectionName is not string)
                throw new ArgumentNullException("Collection name empty");

            _studentDbSettings = studentDbSettings.Value;

            var mongoClient = new MongoClient(
                _studentDbSettings.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                _studentDbSettings.DatabaseName);

            _collection = mongoDatabase.GetCollection<T>(collectionName.ToString());

        }

        public async Task<List<T>> GetAsync() =>
            await _collection.Find(_ => true).ToListAsync();

        public async Task<T?> GetAsync(string id) =>
            await _collection.Find(id).FirstOrDefaultAsync();

        public async Task CreateAsync(T collection) =>
            await _collection.InsertOneAsync(collection);

        public async Task UpdateAsync(string id, T collection) =>
            await _collection.ReplaceOneAsync(id, collection);

        public async Task RemoveAsync(string id) =>
            await _collection.DeleteOneAsync(id);
    }
}
