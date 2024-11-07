using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorExpenseTraker.Model;

public class Category
{
    public int Id { get; set; }
    
    [Required(AllowEmptyStrings = false,
            ErrorMessage = "El nombre de la categoría es requerido")]
    public string Name { get; set; }
}
