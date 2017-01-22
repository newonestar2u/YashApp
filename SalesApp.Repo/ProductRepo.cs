using SalesApp.Repo.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SalesApp.Model.Model;
using System.Collections.ObjectModel;

namespace SalesApp.Repo
{
    public class ProductRepo : IProductRepo
    {
        private static IList<Product> repo = new List<Product>();
        public ProductRepo()
        {
            repo.Clear();
            //fill db
            Product product = new Product()
            {
                Id = 1,
                ImageUrls = new ObservableCollection<string>()
                {
                    "SalesApp.Images.bf4.bf4cover.png","SalesApp.Images.bf4.bf4golmud.jpg",
                    "SalesApp.Images.bf4.bf4dragonsteeth.jpg", "SalesApp.Images.bf4.bf4baku.jpeg",
                    "SalesApp.Images.bf4.bf4clap.jpg"
                },
                Information = "Battlefield 4 is een first-person shooter, "
                              + "ontwikkeld door DICE en uitgegeven door Electronic Arts."
                              + " Het spel kwam op 29 oktober 2013 uit voor Microsoft Windows,"
                              + " PlayStation 3 en Xbox 360 in Noord-Amerika,"
                              + " op 31 oktober in Japan en op 1 november in Europa. Op 15 en 29 november "
                              + "2013 kwam het spel in Noord-Amerika en Europa uit voor de PlayStation 4."
                              + " De Xbox One-versie kwam ook uit in november van datzelfde jaar.",
                Name = "Battlefield 4",
                Prices = new ObservableCollection<Price>() { new Price() {
                    Quantity = 1.0,
                    Value = 50,
                    Description = "Standard edition",
                    Bought = true
                },new Price() {
                    Quantity = 1.0,
                    Value = 60,
                    Description = "Deluxe edition",
                    Bought = false
                },
                },
                Additions = new ObservableCollection<Price>() { new Price() {
                    Quantity = 1.0,
                    Value = 50,
                    Description = "Premium",
                    Bought = false
                },
                 new Price() {
                    Quantity = 1.0,
                    Value = 20,
                    Description = "Easy Unlock Kit Assault",
                    Bought = false
                },
                 new Price() {
                    Quantity = 1.0,
                    Value = 20,
                    Description = "Easy Unlock Kit Engineer",
                    Bought = false
                },
                 new Price() {
                    Quantity = 1.0,
                    Value = 20,
                    Description = "Easy Unlock Kit Support",
                    Bought = false
                },
                 new Price() {
                    Quantity = 1.0,
                    Value = 20,
                    Description = "Easy Unlock Kit Recon",
                    Bought = false
                }
                }
                
            };
            repo.Add(product);
            product = new Product()
            {
                Id = 2,
                ImageUrls = new ObservableCollection<string>()
                {
                    "SalesApp.Images.bf1.bf12guys.jpg", "SalesApp.Images.bf1.bf1cover.jpeg",
                    "SalesApp.Images.bf1.bf1reveal.jpg","SalesApp.Images.bf1.bf1triple.jpg"
                },
                Information = "Battlefield 1 is een first-person shooter ontwikkeld door EA DICE. Het spel werd uitgegeven door Electronic Arts en kwam op 21 oktober 2016 uit voor PlayStation 4, Windows en Xbox One.[1] Het spel speelt zich af in de Eerste Wereldoorlog. De eerst uitgegeven trailer gebruikte een door The Glitch Mob aangepast nummer van The White Stripes, namelijk Seven Nation Army. [2] De ontvangst van de bekendmaking van het spel was zeer goed. De onthullingstrailer had dan ook het meeste aantal likes op een computerspeltrailer ooit, namelijk 2 miljoen.",
                Name = "Battlefield 1",
                Prices = new ObservableCollection<Price>() { new Price() {
                    Quantity = 1.0,
                    Value = 70,
                    Description = "Standard Edition"
                } },
                Additions = new ObservableCollection<Price>() { new Price() {
                    Quantity = 1.0,
                    Value = 50,
                    Description = "Premium"
                }
                }
            };
            repo.Add(product);
        }
        public IList<Product> All()
        {
            return repo.ToList();
        }

        public Product Get(int id)
        {
            return repo.FirstOrDefault(m => m.Id == id);
        }
    }
}
