using System;
using BlazorExpenseTraker.Model;
using System.Data.SqlClient;
using Dapper;

namespace BlazorExpenseTraker.Data.Repositories;

public class ExpenseRepository : IExpenseRepository
{
    private SqlConfiguration _connectionString;

    public ExpenseRepository(SqlConfiguration connectionString){
        _connectionString = connectionString;
    }

    protected SqlConnection dbConnection(){
        return new SqlConnection(_connectionString.ConnectionString);
    }
    public async Task<bool> DeleteExpense(int id)
    {
        var db = dbConnection();
        var sql = @" DELETE FROM Expenses WHERE id = @Id";

        var resultado = await db.ExecuteAsync(sql, new {id});

        return resultado > 0;
    }

    public async Task<IEnumerable<Expense>> GetAllExpenses()
    {
        var db = dbConnection();
        var sql = @" SELECT e.id, e.amount, e.categoryId, e.expenseType,
                        e.transactionDate, c.id, c.name FROM Expenses e
                    INNER JOIN Categories c ON e.categoryId = c.Id";

        return await db.QueryAsync<Expense, Category, Expense>(sql, 
            (expense, category) =>
            {
                expense.Category = category;
                return expense;
            }, new { }, splitOn:"id"
        );
    }

    public async Task<Expense> GetExpenseDetails(int id)
    {
        var db = dbConnection();
        var sql = @" SELECT e.id, e.amount, e.categoryId, e.expenseType,
                        e.transactionDate FROM Expenses e
                     WHERE e.id = @id";
        return await db.QueryFirstOrDefaultAsync<Expense>(sql, new {id});
    }

    public async Task<bool> InsertExpenseDetails(Expense expense)
    {
        var db = dbConnection();
        var sql = @" INSERT INTO Expenses (amount, categoryId, transactionDate, expenseType) 
                    VALUES (@amount, @categoryId, @transactionDate, @expenseType)";

        var resultado = await db.ExecuteAsync(sql, new {expense.Amount, expense.CategoryId, expense.TransactionDate, expense.ExpenseType});

        return resultado > 0;
    }

    public async Task<bool> UpdateExpense(Expense expense)
    {
        var db = dbConnection();
        var sql = @" UPDATE Expenses SET amount = @amount, categoryId = @categoryId, 
                    transactionDate = @transactionDate, expenseType = @expenseType WHERE id = @Id";

        var resultado = await db.ExecuteAsync(sql, new {expense.Amount, expense.CategoryId, expense.TransactionDate, expense.ExpenseType, expense.Id});

        return resultado > 0;
    }
}
