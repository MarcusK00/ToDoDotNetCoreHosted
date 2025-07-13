using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoDotNetCoreHosted.Shared;

[ApiController]
[Route("api/[controller]")]
public class ToDoController : ControllerBase
{
    private readonly ToDoDbContext _context;

    public ToDoController(ToDoDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IEnumerable<ToDoItem>> Get() =>
        await _context.ToDoItems.ToListAsync();

    [HttpPost]
    public async Task<ActionResult<ToDoItem>> Post(ToDoItem item)
    {
        _context.ToDoItems.Add(item);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = item.Id }, item);
    }

   
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, ToDoItem item)
    {
        if (id != item.Id)
            return BadRequest();

        _context.Entry(item).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.ToDoItems.Any(e => e.Id == id))
                return NotFound();
            else
                throw;
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task <IActionResult> Delete(int id)
    {
        var item = await _context.ToDoItems.FindAsync(id);
        if (item == null)
        {
            return NotFound();
        }

        _context.ToDoItems.Remove(item);
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if(!_context.ToDoItems.Any(e => e.Id == id))
            {

            }
        }
        return NoContent();
    }
}