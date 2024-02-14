using System;
using System.Collections.Generic;
using LiteDB;

namespace todoApi
{
    public class MemoryCacheService : ICacheService
    {
        private readonly LiteDatabase _db;

        public MemoryCacheService()
        {
            _db = new LiteDatabase("todoApi_db");
        }

        public void Set(int key, TodoModel value)
        {
            var todo = (TodoModel)value;
            _db.GetCollection<TodoModel>("todoApi_db").Insert(todo);
        }

        public TodoModel Get(int key)
        {
            return _db.GetCollection<TodoModel>("todoApi_db").FindById(key);
        }

        public TodoModel UpDate(int key, string Title, bool Completed)
        {
            var result = _db.GetCollection<TodoModel>("todoApi_db").FindById(key);

            if (result != null)
            {
                result.Completed = Completed;
                result.Title = Title;
                _db.GetCollection<TodoModel>("todoApi_db").Update(result);
                return result;
            }

            return new TodoModel();
        }

        public List<TodoModel> GetAll()
        {
            return _db.GetCollection<TodoModel>("todoApi_db").FindAll().ToList();
        }

        public bool ContainsKey(int id)
        {
            return _db.GetCollection<TodoModel>("todoApi_db").FindById(id) != null;
        }
    }

    public interface ICacheService
    {
        // Get all todo items
        List<TodoModel> GetAll();

        // Get todo item by id
        TodoModel Get(int key);

        // Set todo item by id
        void Set(int key, TodoModel value);

        // Update todo item by id
        TodoModel UpDate(int key, string Title, bool Completed);

        // Check if todo item exists
        bool ContainsKey(int id);
    }
}