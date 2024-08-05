using System.IO.Compression;
using Microsoft.AspNetCore.Mvc;

namespace MyFirstNetApiProject.Models.Repositories
{
    public static class ShirtRepository {

        public static List<Shirt> shirts = new List<Shirt>{
            new Shirt{Id = 1,Brand = "brand1", Color = "red", Gender= "men", Price = 10, Size = 6},
            new Shirt{Id = 2,Brand = "brand1", Color = "red", Gender= "men", Price = 10, Size = 6},
            new Shirt{Id = 3,Brand = "brand1", Color = "red", Gender= "men", Price = 10, Size = 6},
            new Shirt{Id = 4,Brand = "brand1", Color = "red", Gender= "men", Price = 10, Size = 6},
            new Shirt{Id = 5,Brand = "brand1", Color = "red", Gender= "men", Price = 10, Size = 6}
        };

        public static List<Shirt> GetShirts(){
            return shirts;
        }

        public static bool  ShirtExits(int id){
            return shirts.Any(x=>x.Id == id);
        }

        public static Shirt? GetShirtById(int id){
            return shirts.FirstOrDefault(x=>x.Id == id);
        }

        public static Shirt? GetShirtByProperties(string? brand, string? color, string? gender, int? size){
            return shirts.FirstOrDefault(x=>
                !String.IsNullOrWhiteSpace(brand) && 
                !String.IsNullOrWhiteSpace(color) && 
                !String.IsNullOrWhiteSpace(gender) && 
                size.HasValue && 
                !String.IsNullOrWhiteSpace(x.Brand)&&
                !String.IsNullOrWhiteSpace(x.Color)&&
                !String.IsNullOrWhiteSpace(x.Gender)&&
                x.Size.HasValue &&
                x.Brand.Equals(brand,StringComparison.OrdinalIgnoreCase) &&
                x.Color.Equals(color,StringComparison.OrdinalIgnoreCase) &&
                x.Gender.Equals(gender,StringComparison.OrdinalIgnoreCase) &&
                size.Value == x.Size.Value);
        }

        public static void AddShirt(Shirt shirt){
            int maxId = shirts.Max(x=>x.Id);
            shirt.Id = maxId+1;
            shirts.Add(shirt);
        }

        public static void UpdateShirt(Shirt shirt){
            var shirtToUpdate = shirts.First(x => x.Id == shirt.Id);
            shirtToUpdate.Brand = shirt.Brand;
            shirtToUpdate.Color = shirt.Color;
            shirtToUpdate.Gender = shirt.Gender;
            shirtToUpdate.Size = shirt.Size;
            shirtToUpdate.Price = shirt.Price;
        }
    }
}   