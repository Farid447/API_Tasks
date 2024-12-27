using Oyun.DTOs.Game;
using Oyun.Entities;

namespace Oyun.Services.Abstracts;  

public interface IGameService
{
    Task<Guid> AddAsync(GameCreateDto dto);
    Task StartAsync(Guid id);
    Task<Game> GetCurrentStatus(Guid id);
}
