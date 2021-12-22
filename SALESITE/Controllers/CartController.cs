using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using SALESITE.Models;

namespace SALESITE.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CartController : ApiController
    {
        [HttpGet]
        [Route("api/carts")]
        public List<Cart> laydanhsach()
        {
            List<Cart> carts = new Cart_DAO().laytatca();
            return carts;
        }
        [HttpGet]
        [Route("api/carts/{id}")]
        public Cart Getdetails(int id)
        {
            Cart cart = new Cart_DAO().Selectbycode(id);
            return cart;

        }
        [HttpGet]
        [Route("api/carts/search/{keyword}")]
        public List<Cart> Search(String keyword)
        {
            List<Cart> carts = new Cart_DAO().Selectbyword(keyword);
            return carts;
        }
        [HttpPost]
        [Route("api/carts")]
        public bool Addnew(Cart newcart)
        {
            bool result = new Cart_DAO().Insert(newcart);
            return result;
        }

        [HttpDelete]
        [Route("api/carts/{id}")]
        public bool Delete(int id)
        {
            bool result = new Cart_DAO().Delete(id);
            return result;
        }


        [HttpPut]
        [Route("api/carts/{id}")]
        public bool Update(Cart newcart)
        {
            bool result = new Cart_DAO().Update(newcart);
            return result;
        }
    }
}