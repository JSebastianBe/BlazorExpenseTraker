using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorExpenseTraker.Model;

public class Category
{
    public int id {get; set;}
    [Required(AllowEmptyStrings = false,
            ErrorMessage = "El nombre de la categoría es requerido")]
    public string name {get; set;}

}
