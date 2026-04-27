using System.Collections.Generic;
using AWAQTrainingGrounds.Models;

namespace AWAQTrainingGrounds.ViewModels
{
    public class TiendaViewModel
    {
        public Player CurrentPlayer { get; set; }
        public List<Cosmetic> StoreItems { get; set; }
        public List<Cosmetic> InventoryItems { get; set; }
        public Cosmetic EquippedItem { get; set; }
        
        // Constructor para inicializar las listas y evitar null references
        public TiendaViewModel()
        {
            StoreItems = new List<Cosmetic>();
            InventoryItems = new List<Cosmetic>();
        }
    }
}