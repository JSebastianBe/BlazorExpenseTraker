using System;
using BlazorExpenseTraker.Model;

namespace BlazorExpenseTraker.UI.Interfaces;

public interface ICategoryService
{
    Task<IEnumerable<Category>> GetAllCategories();
    Task<Category> GetCategoryDetails(int id);
    Task SaveCategory(Category category);
    Task DeleteCategory(int id);

}
