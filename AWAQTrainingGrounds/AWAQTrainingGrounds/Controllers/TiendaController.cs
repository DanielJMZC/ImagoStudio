using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using AWAQTrainingGrounds.Models;
using AWAQTrainingGrounds.ViewModels;

public class TiendaController : Controller
{
    private readonly ITiendaService _tiendaService;

    public TiendaController(ITiendaService tiendaService)
    {
        _tiendaService = tiendaService;
    }

    public async Task<IActionResult> Tienda()
    {
        var userId = HttpContext.Session.GetInt32("user_id");
        if (userId == null)
        {
            return RedirectToAction("Login", "Account");
        }

        var playerId = await _tiendaService.GetPlayerIdByUserId(userId.Value);
        if (playerId == null)
        {
            return RedirectToAction("Login", "Account");
        }

        var vm = new TiendaViewModel();

        var playerTask = _tiendaService.GetPlayer(playerId.Value);
        var cosmeticsTask = _tiendaService.GetAllCosmetics();
        var inventoryTask = _tiendaService.GetInventory(playerId.Value);
        var equippedTask = _tiendaService.GetEquipped(playerId.Value);

        await Task.WhenAll(playerTask, cosmeticsTask, inventoryTask, equippedTask);

        vm.CurrentPlayer = await playerTask ?? new Player { name = "Emma", currency = 0 };

        var allCosmetics = await cosmeticsTask;

        var inventory = await inventoryTask;

        var equippedList = await equippedTask;

        vm.EquippedItem = equippedList.FirstOrDefault();

        vm.StoreItems = allCosmetics;

        vm.InventoryItems = inventory;

        return View(vm);
    }

    [HttpPost]
    public async Task<IActionResult> Comprar(int id)
    {
        var userId = HttpContext.Session.GetInt32("user_id");
        if (userId != null)
        {
            var playerId = await _tiendaService.GetPlayerIdByUserId(userId.Value);
            if (playerId != null)
            {
                await _tiendaService.BuyCosmetic(playerId.Value, id);
            }
        }
        return RedirectToAction("Tienda");
    }

    [HttpPost]
    public async Task<IActionResult> Equipar(int id)
    {
        var userId = HttpContext.Session.GetInt32("user_id");
        if (userId != null)
        {
            var playerId = await _tiendaService.GetPlayerIdByUserId(userId.Value);
            if (playerId != null)
            {
                await _tiendaService.EquipCosmetic(playerId.Value, id);
            }
        }
        return RedirectToAction("Tienda");
    }
}