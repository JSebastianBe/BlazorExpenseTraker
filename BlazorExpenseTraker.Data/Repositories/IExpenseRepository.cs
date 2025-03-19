using System;
using BlazorExpenseTraker.Model;

namespace BlazorExpenseTraker.Data.Repositories;

public interface IExpenseRepository
{
    Task<IEnumerable<Expense>> GetAllExpenses();
    Task<Expense> GetExpenseDetails(int id);
    Task<bool> InsertExpenseDetails(Expense expense);
    Task<bool> UpdateExpense(Expense expense);
    Task<bool> DeleteExpense(int id);
}
