using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooApp.Models;
using ZooApp.Models.Migrations;
using AnimalFood = ZooApp.Models.AnimalFood;

namespace ZooApp.ViewModel
{
    public class ViewFoodTotal
    {
        public ViewFoodTotal(AnimalFood animalFood)
        {
            FoodName = animalFood.Food.Name;
            FoodPrice = animalFood.Food.Price;
            TotalQuantity = animalFood.Animal.Quantity*animalFood.Quantity;
            TotalPrice = animalFood.Food.Price*TotalQuantity;
        }
        public string FoodName { set; get; }
        public double FoodPrice { set; get; }
        public double TotalQuantity { set; get; }
        public double TotalPrice { set; get; }
    }
}
