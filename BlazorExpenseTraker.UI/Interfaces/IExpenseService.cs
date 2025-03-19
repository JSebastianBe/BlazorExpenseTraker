using System;
using BlazorExpenseTraker.Model;

namespace BlazorExpenseTraker.UI.Interfaces;

public interface IExpenseService
{
    Task<IEnumerable<Expense>> GetAllExpenses();
    Task<Expense> GetExpenseDetails(int id);
    Task SaveExpense(Expense expense);
    Task DeleteExpense(int id);
}
