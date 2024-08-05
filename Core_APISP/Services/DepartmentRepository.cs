using Core_APISP.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

public class DepartmentRepository : IServiceRepository<Department>
{
    private readonly CompanyContext _context;

    public DepartmentRepository(CompanyContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Department>> GetAsync()
    {
        try
        {
            return await _context.Departments.FromSqlRaw("EXEC sp_GetDepartments").ToListAsync();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public async Task<Department> GetAsync(int id)
    {
        try
        {
            var parameter = new SqlParameter("@DeptNo", id);
            return await _context.Departments.FromSqlRaw("EXEC sp_GetDepartmentById @DeptNo", parameter).FirstOrDefaultAsync();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public async Task AddAsync(Department entity)
    {
        try
        {
            var parameters = new[]
           {
            new SqlParameter("@DeptNo", entity.DeptNo),
            new SqlParameter("@DeptName", entity.DeptName),
            new SqlParameter("@Location", entity.Location),
            new SqlParameter("@Capacity", entity.Capacity)
        };
            await _context.Database.ExecuteSqlRawAsync("EXEC sp_CreateDepartment @DeptNo, @DeptName, @Location, @Capacity", parameters);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public async Task UpdateAsync(Department entity)
    {
        try
        {
            var parameters = new[]
            {
            new SqlParameter("@DeptNo", entity.DeptNo),
            new SqlParameter("@DeptName", entity.DeptName),
            new SqlParameter("@Location", entity.Location),
            new SqlParameter("@Capacity", entity.Capacity)
        };
            await _context.Database.ExecuteSqlRawAsync("EXEC sp_UpdateDepartment @DeptNo, @DeptName, @Location, @Capacity", parameters);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public async Task DeleteAsync(int id)
    {
        try
        {
            var parameter = new SqlParameter("@DeptNo", id);
            await _context.Database.ExecuteSqlRawAsync("EXEC sp_DeleteDepartment @DeptNo", parameter);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
