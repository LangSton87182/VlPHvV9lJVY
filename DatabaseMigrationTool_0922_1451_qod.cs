// 代码生成时间: 2025-09-22 14:51:33
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Linq;

// DatabaseMigrationTool 负责数据库迁移操作
public class DatabaseMigrationTool
{
    // 迁移上下文
    private readonly MyDbContext _dbContext;

    // 构造函数
    public DatabaseMigrationTool(MyDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    // 执行数据库迁移
    public void MigrateDatabase()
    {
        try
        {
            // 检查数据库是否需要迁移
            if (_dbContext.Database.GetPendingMigrations().Any())
            {
                // 应用所有待处理的迁移
                _dbContext.Database.Migrate();
                Console.WriteLine("数据库迁移完成。");
            }
            else
            {
                Console.WriteLine("数据库已是最新状态，无需迁移。");
            }
        }
        catch (Exception ex)
        {
            // 错误处理
            Console.WriteLine($"数据库迁移过程中发生错误：{ex.Message}");
        }
    }

    // 添加示例迁移操作
    public void AddSampleMigration()
    {
        // 创建一个新的迁移实例
        var migrationBuilder = new MigrationBuilder(1);
        migrationBuilder.CreateTable(
            name: "SampleTable",
            columns: table => new
            {
                Id = table.Column<int>(nullable: false).Annotation("Sqlite:Autoincrement", true),
                Name = table.Column<string>(nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_SampleTable", x => x.Id);
            });

        // 将迁移添加到上下文中
        _dbContext.Database.Migrate(migrationBuilder);
        Console.WriteLine("示例迁移操作完成。");
    }
}

// 示例数据库上下文
public class MyDbContext : DbContext
{
    public DbSet<SampleEntity> SampleEntities { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // 配置数据库连接字符串
        options.UseSqlite("Data Source=mydatabase.db");
    }
}

// 示例实体
public class SampleEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
}
