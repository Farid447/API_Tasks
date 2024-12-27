using AutoMapper;
using Oyun.DataAccess;
using Oyun.DTOs.Game;
using Oyun.Entities;
using Oyun.Services.Abstracts;

namespace Oyun.Services.Implements;

public class GameService(IMapper _mapper, GameDbContext _context) : IGameService
{
    public async Task<Guid> AddAsync(GameCreateDto dto)
    {
        var entity = _mapper.Map<Game>(dto);
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity.Id;
    }

    public Task<Game> GetCurrentStatus(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task StartAsync(Guid id)
    {
        var entity = await _context.Games.FindAsync(id);
        if (entity == null)
        {   
            
        }
        if(entity.Score is not 0)
        {
            throw new Exception();
        }
    }
}
