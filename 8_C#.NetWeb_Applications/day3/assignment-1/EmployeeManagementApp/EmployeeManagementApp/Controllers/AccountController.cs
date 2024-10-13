using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // Add this for async operations like FirstOrDefaultAsync
using EmployeeManagementApp.Models;

public class AccountController : Controller
{
    private readonly AppDbContext _context;

    public AccountController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            var employee = await _context.Employees
                .FirstOrDefaultAsync(e => e.Email == model.Email && e.Password == model.Password);

            if (employee != null)
            {
                // Logic for successful login
            }
            else
            {
                ModelState.AddModelError("", "Invalid login attempt.");
            }
        }

        return View(model);
    }
}
