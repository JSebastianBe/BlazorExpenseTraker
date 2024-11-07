using System;
using System.Data.SqlClient;
using System.Windows.Markup;
using BlazorExpenseTraker.Model;
using Dapper;

namespace BlazorExpenseTraker.Data.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private SqlConfiguration _connectionString;

    public CategoryRepository(SqlConfiguration connectionString){
        _connectionString = connectionString;
    }

    protected SqlConnection dbConnection(){
        return new SqlConnection(_connectionString.ConnectionString);
    }
    public async Task<bool> DeleteCategory(int id)
    {
        var db = dbConnection();
        var sql = @" DELETE FROM Categories WHERE id = @Id";

        var resultado = await db.ExecuteAsync(sql, new {id});

        return resultado > 0;
    }

    public async Task<IEnumerable<Category>> GetAllCategories()
    {
        var db = dbConnection();
        var sql = @" SELECT id, name FROM Categories";

        return await db.QueryAsync<Category>(sql, new {});
    }

    public async Task<Category> GetCategoryDetails(int id)
    {
        var db = dbConnection();
        var sql = @" SELECT id, name FROM Categories WHERE id = @id";

        return await db.QueryFirstOrDefaultAsync<Category>(sql, new {id});
    }

    public async Task<bool> InsertCategory(Category category)
    {
        var db = dbConnection();
        var sql = @" INSERT INTO Categories (name) VALUES (@Name)";

        var resultado = await db.ExecuteAsync(sql, new {category.Name});

        return resultado > 0;
    }

    public async Task<bool> UpdateCategory(Category category)
    {
        var db = dbConnection();
        var sql = @" UPDATE Categories SET name = @Name WHERE id = @Id";

        var resultado = await db.ExecuteAsync(sql, new {category.Name, category.Id});

        return resultado > 0;
    }
}
