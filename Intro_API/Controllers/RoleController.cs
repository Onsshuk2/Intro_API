using Intro_API.DAL.Entities;
using Intro_API.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Intro_API.DAL.Entities.Role;

[ApiController]
[Route("api/role")]
public class RoleController : ControllerBase
{
    private readonly AppDbContext _context;

    public RoleController(AppDbContext context)
    {
        _context = context;
    }

    // Method to create a new role (POST)
    [HttpPost]
    public IActionResult RoleCreate([FromBody] AppRole entity)
    {
        if (entity == null)
        {
            return BadRequest("Invalid role data.");
        }

        _context.Roles.Add(entity);
        _context.SaveChanges();
        return Ok("Роль створено");
    }

    // Method to update an existing role (PUT)
    [HttpPut("{id}")]
    public IActionResult RoleUpdate(string id, [FromBody] AppRole entity)
    {
        if (entity == null || id != entity.Id)
        {
            return BadRequest("Invalid role data.");
        }

        var existingRole = _context.Roles.Find(id);
        if (existingRole == null)
        {
            return NotFound("Role not found.");
        }

        existingRole.Name = entity.Name;
        _context.SaveChanges();
        return Ok("Роль оновлено");
    }

    // Method to delete a role (DELETE)
    [HttpDelete("{id}")]
    public IActionResult RoleDelete(string id)
    {
        var role = _context.Roles.Find(id);
        if (role == null)
        {
            return NotFound("Role not found.");
        }

        _context.Roles.Remove(role);
        _context.SaveChanges();
        return Ok("Роль видалено");
    }

    // Method to get all roles (GET)
    [HttpGet]
    public IActionResult GetAllRoles()
    {
        var roles = _context.Roles.ToList();
        return Ok(roles);
    }

    // Method to get a role by its ID (GET)
    [HttpGet("{id}")]
    public IActionResult GetRoleById(string id)
    {
        var role = _context.Roles.Find(id);
        if (role == null)
        {
            return NotFound("Role not found.");
        }

        return Ok(role);
    }
}
