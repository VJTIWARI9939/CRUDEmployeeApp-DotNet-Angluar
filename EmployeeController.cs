using crud_dot_net_api.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace crud_dot_net_api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class EmployeeController : ControllerBase
  {

    private readonly EmployeeRespository _employeeRespository;
    public EmployeeController(EmployeeRespository employeeRespository) {
      _employeeRespository = employeeRespository; 

    }

    [HttpPost]
    public async Task<ActionResult> AddEmployee([FromBody] Employee model)
    {
      await _employeeRespository.AddEmployee(model);

      return Ok();
    }

    [HttpGet]

    public async Task<ActionResult> GetEmployeeList()
    {
      var employeeList = await _employeeRespository.GetAllEmployee();
      return Ok(employeeList);
    }

    [HttpGet("{id}")]

    public async Task<ActionResult> GetEmployeeById([FromRoute] int id)
    {
      var employee = await _employeeRespository.GetEmployeeById(id);
      return Ok(employee);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateEmployee([FromRoute] int id, [FromBody] Employee model)
    {
      await _employeeRespository.UpdateEmployee(id, model);
      return Ok();
    }

    [HttpDelete("{id}")]

    public async Task<ActionResult> DeleteEmployee([FromRoute] int id)
    {
      await _employeeRespository.DeleteEmployee(id);
      return Ok();
    }
  }
}
