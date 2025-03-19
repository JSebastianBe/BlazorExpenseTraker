using System;
using System.ComponentModel.DataAnnotations;
using BlazorExpenseTraker.Model.Validation;

namespace BlazorExpenseTraker.Model;

public class Expense //: IValidatableObject
{
    public int Id { get; set; }
    [Required]
    [Range(1,double.MaxValue, ErrorMessage ="El valor tiene que ser mayor que 0")]
    public decimal Amount { get; set; }
    [Required]
    public string CategoryId { get; set; }
    public Category? Category  { get; set; }
    [Required]
    [ExpenseTransactionDateValidator(DaysInTheFuture = 30)]
    public DateTime TransactionDate { get; set; }
    public ExpenseType ExpenseType { get; set; }

    public event Action OnSelectedExpenseChanged;
    public void SelectedExpenseChanged(Expense expense)
    {
        Id = expense.Id;
        TransactionDate = expense.TransactionDate;
        Amount = expense.Amount;
        ExpenseType = expense.ExpenseType;
        CategoryId = expense.CategoryId;
        NotifySelectedExpenseChanged();
    }
    private void NotifySelectedExpenseChanged()
    {
        OnSelectedExpenseChanged.Invoke();
    }

}
