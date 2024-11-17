using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace Contact.Repositories
{
    public class ContactRepository : IRepository<Models.Contact>
    {
        private readonly SQLiteAsyncConnection _connection;

        public ContactRepository(string dbPath)
        {
            _connection = new SQLiteAsyncConnection(dbPath);
            _connection.CreateTableAsync<Models.Contact>().Wait();
        }

        public string StatusMessage { get; set; }

        public async Task<bool> Create(Models.Contact entity)
        {
            var result = 0;
            try
            {
                result = await _connection.InsertAsync(entity);

                StatusMessage = $"{result} record(s) added [Name: {entity.FirstName})";

                if (result == 1)
                    return true;
            }
            catch (Exception ex)
            {
                StatusMessage = $"Failed to create {entity.FirstName}. Error: {ex.Message}";
            }

            return false;
        }

        public async Task<bool> Update(Models.Contact entity)
        {
            var result = 0;
            try
            {
                result = await _connection.UpdateAsync(entity);
                StatusMessage = $"{result} record(s) updated [Name: {entity.FirstName})";
                if (result == 1)
                    return true;
            }
            catch (Exception ex)
            {
                StatusMessage = $"Failed to update {entity.FirstName}. Error: {ex.Message}";
            }

            return false;
        }

        public async Task<bool> Delete(int id)
        {
            var result = 0;
            try
            {
                result = await _connection.DeleteAsync<Models.Contact>(id);
                StatusMessage = $"{result} record(s) deleted.";
                if (result == 1)
                    return true;
            }
            catch (Exception ex)
            {
                StatusMessage = $"Failed to delete record. Error: {ex.Message}";
            }

            return false;
        }

        public async Task<Models.Contact> Get(int id)
        {
            try
            {
                return await _connection.Table<Models.Contact>().FirstOrDefaultAsync(t => t.Id == id);
            }
            catch (Exception ex)
            {
                StatusMessage = $"Failed to retrieve record. Error: {ex.Message}";
            }

            return null;
        }

        public async Task<IEnumerable<Models.Contact>> GetAll()
        {
            try
            {
                return await _connection.Table<Models.Contact>().OrderBy(t => t.FirstName).ThenBy(t => t.LastName)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                StatusMessage = $"Failed to retrieve records. Error: {ex.Message}";
            }

            return null;
        }
    }
}