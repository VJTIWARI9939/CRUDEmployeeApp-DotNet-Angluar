using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace crud_dot_net_api.Data
{
  public class EmployeeRespository
  {
    private readonly AppDBContext _appDBContext;
    public EmployeeRespository(AppDBContext appDBContext)
    {
      this._appDBContext = appDBContext;
    }

    //post
    public async Task AddEmployee(Employee employee)
    {
      await _appDBContext.Set<Employee>().AddAsync(employee);
      await _appDBContext.SaveChangesAsync();
    }

    public async Task<List<Employee>>GetAllEmployee()
    {
      return await _appDBContext.Employees.ToListAsync();
    }

    public async Task<Employee> GetEmployeeById(int id)
    {
      return await _appDBContext.Employees.FindAsync(id);
    }

    public async Task UpdateEmployee(int id , Employee model)
    {
      var employee = await _appDBContext.Employees.FindAsync(id);
      if(employee == null)
      {
        throw new Exception("Employee not found");
      }
      employee.Name = model.Name;
      employee.Phone = model.Phone;
      employee.Age = model.Age;
      employee.Salary = model.Salary;
      await _appDBContext.SaveChangesAsync();
    }

    public async Task DeleteEmployee(int id)
    {
      var employee = await _appDBContext.Employees.FindAsync(id);
      if (employee == null)
      {
        throw new Exception("Employee not found");
      }
      _appDBContext.Employees.Remove(employee);
      await _appDBContext.SaveChangesAsync();
    }
  }  
}

