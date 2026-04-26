using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using AWAQTrainingGrounds.Models;
using AWAQTrainingGrounds.ViewModels;

public class TiendaController : Controller
{
    private readonly ITiendaService _tiendaService;
    
    // Hardcodeamos el player 1 por ahora hasta que el login esté listo
    private readonly int _currentPlayerId = 1;

    public TiendaController(ITiendaService tiendaService)
    {
        _tiendaService = tiendaService;
    }

    public async Task<IActionResult> Tienda()
    {
        var vm = new TiendaViewModel();

        // 1. Obtener info del jugador (Monedas)
        vm.CurrentPlayer = await _tiendaService.GetPlayer(_currentPlayerId) ?? new Player { name = "Emma", currency = 0 };

        // 2. Obtener todos los cosméticos
        var allCosmetics = await _tiendaService.GetAllCosmetics();

        // 3. Obtener el inventario
        var inventory = await _tiendaService.GetInventory(_currentPlayerId);

        // 4. Obtener lo que tiene equipado
        var equippedList = await _tiendaService.GetEquipped(_currentPlayerId);
        vm.EquippedItem = equippedList.FirstOrDefault();

        // 5. Separar los items
        var inventoryIds = inventory.Select(i => i.cosmetic_id).ToList();

        vm.StoreItems = allCosmetics; // Mantener todos los items en la tienda
        vm.InventoryItems = inventory;

        return View(vm);
    }

    [HttpPost]
    public async Task<IActionResult> Comprar(int id)
    {
        await _tiendaService.BuyCosmetic(_currentPlayerId, id);
        return RedirectToAction("Tienda");
    }

    [HttpPost]
    public async Task<IActionResult> Equipar(int id)
    {
        await _tiendaService.EquipCosmetic(_currentPlayerId, id);
        return RedirectToAction("Tienda");
    }
}