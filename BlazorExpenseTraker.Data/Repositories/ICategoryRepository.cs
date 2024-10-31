using System;
using BlazorExpenseTraker.Model;

namespace BlazorExpenseTraker.Data.Repositories;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetAllCategories();
    Task<Category> GetCategoryDetails(int id);
    Task<bool> InsertCategory(Category category);
    Task<bool> UpdateCategory(Category category);
    Task<bool> DeleteCategory(int id);
}
