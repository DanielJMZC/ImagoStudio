using System.Collections.Generic;
using System.Threading.Tasks;
using AWAQTrainingGrounds.Models;

public interface ITiendaService
{
    Task<Player> GetPlayer(int playerId);
    Task<List<Cosmetic>> GetAllCosmetics();
    Task<List<Cosmetic>> GetInventory(int playerId);
    Task<List<Cosmetic>> GetEquipped(int playerId);
    Task<bool> BuyCosmetic(int playerId, int cosmeticId);
    Task<bool> EquipCosmetic(int playerId, int cosmeticId);
}
