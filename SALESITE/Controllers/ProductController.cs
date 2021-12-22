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
    public class ProductController : ApiController
    {
        [HttpGet]
        [Route("api/products")]
        public List<Product> laydanhsach()
        {
            List<Product> products = new Product_DAO().laytatca();
            return products;
        }
        [HttpGet]
        [Route("api/products/{id}")]
        public Product Getdetails(int id)
        {
            Product product = new Product_DAO().Selectbycode(id);
            return product;
        }
        [HttpGet]
        [Route("api/products/search/{keyword}")]
        public List<Product> Search(String keyword)
        {
            List<Product> products = new Product_DAO().Selectbyword(keyword);
            return products;
        }
        [HttpPost]
        [Route("api/products")]
        public bool Addnew(Product newproduct)
        {
            bool result = new Product_DAO().Insert(newproduct);
            return result;
        }


        [HttpDelete]
        [Route("api/products/{id}")]
        public bool Delete(int id)
        {
            bool result = new Product_DAO().Delete(id);
            return result;
        }


        [HttpPut]
        [Route("api/products/{id}")]
        public bool Update(Product newproduct)
        {
            bool result = new Product_DAO().Update(newproduct);
            return result;
        }
    }
}