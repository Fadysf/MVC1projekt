using Inlamning.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inlamning.Controllers
{

    public class HomeController : Controller
    {
        // första Action som händer när man startar programet 
        public ActionResult Index()
        {
            //kalla på vår data basen
            ApplicationDbContext db = new ApplicationDbContext();
            //viewmoder så användere inte få diret komtakt med database,vi skicker en list till vår view
            StartPageViewModel viewModel = new StartPageViewModel();
            viewModel.Products = db.Produkts.ToList();

            return View(viewModel);
        }



        // produkt och köp hantering 
        // kunden måste loga in innan kunden kan körpa
        [Authorize]
        public ActionResult ProductCart()
        {

            return View();
        }

        // skickar order id till tack view ocg vissar tack medelande till kund 
        public ActionResult Thankyou(int orderId)
        {
            return View(orderId);
        }

        [HttpPost]

        public ActionResult CreateOrder(List<OrderRow> cart)
        {
            ApplicationDbContext db = new ApplicationDbContext();

            string userId = User.Identity.GetUserId();
            // skapa order och lägra info i order tablen
            Orders newOrder = new Orders
            {
                CustomerId = userId,
                Created = DateTime.Now,
                Payed = false,
                Shipping = false,
                Total = 0
            };
            db.Orders.Add(newOrder);
            db.SaveChanges();
            // lopa genom Cart och hämta info som pris id och antal
            int priceHolder = 0;
            foreach (var item in cart)
            {
                // skapa orderrow och ger den order id antal och prdukt 
                OrderRow newOrderRow = new OrderRow
                {
                    OrderId = newOrder.Id,
                    Amount = item.Amount,
                    ProduktId = item.ProduktId,

                };
                db.OrderRow.Add(newOrderRow);
                db.SaveChanges();


                //räkna ut totala priset för all prdukter man köpt
                Produkt currentprodukt = db.Produkts.First(o => o.Id == item.ProduktId);
                priceHolder = currentprodukt.Pris * item.Amount;
                newOrder.Total += priceHolder;
            }


            //hämta info och uppdatera de i tablen
            db.Entry<Orders>(newOrder).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

           // tillback till thankyou kontrolen med order id.
            return PartialView("_Thankyou",  newOrder.Id );
        }
        
        
       
    }
}






