// 代码生成时间: 2025-08-17 02:34:02
using System;
using Xamarin.Forms;
using SQLite;

namespace AntiSqlInjectionExample
{
    // 数据模型
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }

    public class DatabaseService
    {
        private readonly SQLiteAsyncConnection _database;

        public DatabaseService(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<User>().Wait();
        }

        // 插入用户信息
        public async Task InsertUserAsync(string name, string email)
        {
            try
            {
                // 使用参数化查询防止SQL注入
                var query = _database PrepareStatement("INSERT INTO User (Name, Email) VALUES (@Name, @Email);");
                query.Bind("@Name", name);
                query.Bind("@Email", email);
                await query.StepAsync();
            }
            catch (Exception ex)
            {
                // 错误处理
                Console.WriteLine($"An error occurred while inserting user: {ex.Message}");
            }
        }

        // 查询用户信息
        public async Task<List<User>> GetUsersAsync()
        {
            try
            {
                // 使用参数化查询防止SQL注入
                var users = await _database.QueryAsync<User>("SELECT * FROM User");
                return users;
            }
            catch (Exception ex)
            {
                // 错误处理
                Console.WriteLine($"An error occurred while fetching users: {ex.Message}");
                return null;
            }
        }
    }

    public class MainPage : ContentPage
    {
        public MainPage()
        {
            // 布局和控件
        }
    }
}
