using Forest.Services.IService;
using Forest.Services.Models;
using Forest.Services.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Forest.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Forest.Data.Models.Domain;
using Humanizer;


namespace Forest.Controllers
{
    public class CartController : ForestController
    {
        List<CartMusic> cart;
        IOrderService orderService;
        IMusicService musicService;
        IUserService userService;
        public CartController()
        {
            orderService = new OrderService();
            musicService = new MusicService();
            userService = new UserService();
        }
        #region(Private Methods)
        bool IsThereAcart()
        {
            if(httpContextAccessor.HttpContext.Session.GetString("cart")!=null)
                return true;
            return false;
        }
        List<CartMusic> GetCart()
        {
            if (!IsThereAcart())
                return null;
            string cartJson = httpContextAccessor.HttpContext.Session.GetString("cart");
            List<CartMusic> cart = JsonConvert.DeserializeObject<List<CartMusic>>(cartJson);
            return cart;

        }
        void PutCartInSession(List<CartMusic> cart)
        {
           if(IsThereAcart())
           {
                string cartJson = JsonConvert.SerializeObject(cart);
                httpContextAccessor.HttpContext.Session.SetString("cart", cartJson);
           }
        
        }
        bool IsItemInCart(int musicId, List<CartMusic> cart)
        {
            foreach(var  cartMusic in cart)
            {
                if (cartMusic.Music.Id == musicId)
                    return true;
            }
            return false;
        }
        #endregion
        #region(Actions)
        public ActionResult AddToCart(int id)
        { 
            List<CartMusic> cart = GetCart();
            if (cart != null)
            {
                if (IsItemInCart(id, cart))
                {
                    var data = new Dictionary<string, string>();
                    data.Add("musicId", id.ToString());
                    data.Add("toDo", "+");
                    return UpdateCart(data);
                }
            }
            else
                cart = new List<CartMusic>();
            CartMusic item = new CartMusic()
            {
                Music = musicService.GetMusic(id),
                Quantity = 1

            };
            cart.Add(item);
            PutCartInSession(cart);
            return RedirectToAction("DisplayCart");
        }
        public ActionResult UpdateCart(Dictionary<string, string> data)
        {
            int musicId = int.Parse(data["musicId"]);
            char toDo = data["toDo"][0];
            switch (toDo)
            {
                case '+':
                    if (IsThereAcart())
                    {
                        cart = GetCart();
                        if (IsItemInCart(musicId, cart))
                            cart.Find(o => o.Music.Id == musicId).Quantity++;
                    }
                    else
                    {
                        cart = new List<CartMusic>();
                        cart.Add(new CartMusic
                        {
                            Music = musicService.GetMusic(musicId),
                            Quantity = 1
                        });
                    }
                    PutCartInSession(cart);
                    return RedirectToAction("DisplayCart");
                    break;
                case '-':
                    if (IsThereAcart())
                    {
                        cart = GetCart();
                        if (IsItemInCart(musicId, cart))
                        {
                            CartMusic item = cart.Find(o => o.Music.Id == musicId);
                            if (item.Quantity > 1)
                                cart.Find(o => o.Music.Id == musicId).Quantity--;
                            else
                                cart.Remove(item);
                            PutCartInSession(cart);
                        }
                    }
                    return RedirectToAction("DisplayCart");
                    break;
                case 'x':
                    if (IsThereAcart())
                    {
                        cart = GetCart();
                        if (IsItemInCart(musicId, cart))
                        {
                            CartMusic item = cart.Find(o => o.Music.Id == musicId);
                            cart.Remove(item);
                            PutCartInSession(cart);
                        }

                    }
                    return RedirectToAction("DisplayCart");
                    break;
                default:
                    break;
            }
            return View();
        }
        public ActionResult DisplayCart()
        {
            List<CartMusic> cart = GetCart();
            if (cart != null)
                return View(cart);
            return View();
        }

        // POST: CartController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CartController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CartController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CartController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CartController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        #endregion
    }
}
