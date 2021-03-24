using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using Backend.Domain;
using Backend.Foundation;

using Common.Utils.ApiDataContracts;

namespace Backend.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        private readonly IExpenseManagementService _expenseManagementService;


        public ExpensesController(IExpenseManagementService expenseManagementService)
        {
            _expenseManagementService = expenseManagementService;
        }


        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var expenses = await _expenseManagementService.GetAllExpenses();
            var dataResponse = new ApiDataResponse<IReadOnlyCollection<Expense>>(expenses);

            return Ok(dataResponse);
        }

        [HttpGet]
        public async Task<ActionResult> GetByCreditor(Guid creditorId)
        {
            var expenses = await _expenseManagementService.GetExpensesByCreditorAsync(creditorId);
            var dataResponse = new ApiDataResponse<IReadOnlyCollection<Expense>>(expenses);

            return Ok(dataResponse);
        }

        [HttpGet]
        public async Task<ActionResult> GetByCurrency(string currencyCode)
        {
            var expenses = await _expenseManagementService.GetExpensesByCurrencyAsync(currencyCode);
            var dataResponse = new ApiDataResponse<IReadOnlyCollection<Expense>>(expenses);

            return Ok(dataResponse);
        }

        [HttpGet]
        public async Task<ActionResult> Get(Guid id)
        {
            var getExpenseResult = await _expenseManagementService.GetExpense(id);

            if (getExpenseResult.IsSuccessful)
            {
                var successResponse = new ApiDataResponse<Expense>(getExpenseResult.Data);

                return Ok(successResponse);
            }

            var errorResponse = new ApiErrorResponse<GetExpenseErrorType>(getExpenseResult.ErrorType);

            return BadRequest(errorResponse);
        }


        [HttpGet]
        public async Task<ActionResult> Create()
        {
            // TODO: define proper parameters.
            var newExpenseRequest = new AddExpenseRequest(123123, "EUR", new byte[0], Guid.NewGuid());
            var addExpenseResult = await _expenseManagementService.AddExpenseAsync(newExpenseRequest);

            if (addExpenseResult.IsSuccessful)
            {
                var successResponse = new ApiResponse(addExpenseResult.IsSuccessful);

                return Created("HERE LIES THE URI TO THE CREATED EXPENSE - NOT IMPLEMENTED YET :)", successResponse);
            }

            var errorResponse = new ApiErrorResponse<AddExpenseErrorType>(addExpenseResult.ErrorType);

            return BadRequest(errorResponse);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _expenseManagementService.DeleteExpenseAsync(id);

            var successResponse = new ApiResponse(true);

            return NoContent();
        }
    }
}
