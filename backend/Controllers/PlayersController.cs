//API контроллер
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend;
using Microsoft.AspNetCore.Http.HttpResults;


/*[ApiController]
[Route("[controller]")]
public class PlayersController : ControllerBase
{
    private readonly GameDbContext _context;

    public PlayersController(GameDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetPlayers()
    {
        var players = await _context.Players.ToListAsync();
        return Ok(players);
    }
}*/

[Route("api/[controller]")]
[ApiController]
public class PlayersController : ControllerBase
{
    private readonly GameDbContext _context;

    public PlayersController(GameDbContext context)
    {
        _context = context;
    }

    // Получить список всех игроков
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Player>>> GetPlayers()
    {
        return await _context.Players.ToListAsync();
    }

    // Добавить нового игрока
    [HttpPost]
    public async Task<ActionResult<Player>> PostPlayer(Player player)
    {
        _context.Players.Add(player);
        await _context.SaveChangesAsync();

        return Ok(); //CreatedAtAction("GetPlayer", new { id = player.Id }, player);
    }

    // Получить лучших игроков (топ 5)
    [HttpGet("top")]
    public async Task<ActionResult<IEnumerable<Player>>> GetTopPlayers()
    {
        var topPlayers = await _context.Players
            .OrderBy(p => p.Time)
            .Take(5)
            .ToListAsync();

        return Ok(topPlayers);
    }
}