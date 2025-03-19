using BlazorExpenseTraker.Data.Repositories;
using BlazorExpenseTraker.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorExpenseTraker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : Controller
    {
        private readonly IExpenseRepository _expenseRepository;

        public ExpenseController(IExpenseRepository expenseRepository){
            _expenseRepository = expenseRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllExpenses(){
            return Ok(await _expenseRepository.GetAllExpenses());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllExpensesDetails(int id){
            return Ok(await _expenseRepository.GetExpenseDetails(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateExpense([FromBody]Expense expense){
            if(expense == null)
                return BadRequest();

            if(expense.Amount < 0)
                ModelState.AddModelError("name", "El valor tiene que ser mayor a cero");
            
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
                
            var created = await _expenseRepository.InsertExpenseDetails(expense);

            return Created("created", created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateExpense([FromBody]Expense expense){
            if(expense == null)
                return BadRequest();

            if(expense.Amount < 0)
                ModelState.AddModelError("name", "El valor tiene que ser mayor a cero");
            
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
                
            await _expenseRepository.UpdateExpense(expense);

            return NoContent(); //success
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExpense(int id){
            if(id == 0)
                return BadRequest();
                
            await _expenseRepository.DeleteExpense(id);

            return NoContent(); //success
        }
    }
}
