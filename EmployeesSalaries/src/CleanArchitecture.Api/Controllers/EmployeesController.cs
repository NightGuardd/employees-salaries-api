using CleanArchitecture.Application.UseCases.EmployeeUseCases;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace CleanArchitecture.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IGetEmployeesUseCase _getEmployeesUseCase;
        private readonly IRegisterEmployeeUseCase _registerEmployeeUseCase;
        private readonly IRaiseEmployeeSalaryUseCase _raiseEmployeeSalaryUseCase;

        public EmployeesController(IGetEmployeesUseCase getEmployeesUseCase,
            IRegisterEmployeeUseCase registerEmployeeUseCase,
            IRaiseEmployeeSalaryUseCase raiseEmployeeSalaryUseCase)
        {
            _getEmployeesUseCase = getEmployeesUseCase;
            _registerEmployeeUseCase = registerEmployeeUseCase;
            _raiseEmployeeSalaryUseCase = raiseEmployeeSalaryUseCase;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GetEmployeesUseCaseOutput>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get()
        {
            var output = await _getEmployeesUseCase.ExecuteAsync();
            return Ok(output);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> Post(RegisterEmployeeUseCaseInput input)
        {
            await _registerEmployeeUseCase.ExecuteAsync(input);
            return Ok();
        }

        [HttpPatch("RaiseSalary")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> RaiseSalary(RaiseEmployeeSalaryUseCaseInput input)
        {
            await _raiseEmployeeSalaryUseCase.ExecuteAsync(input);
            return Ok();
        }
    }
}
