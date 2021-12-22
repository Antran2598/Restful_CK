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
    public class CheckoutController : ApiController
    {
        [HttpGet]
        [Route("api/checkouts")]
        public List<Check_out> laydanhsach()
        {
            List<Check_out> check_outs = new Checkout_DAO().laytatca();
            return check_outs;
        }
        [HttpGet]
        [Route("api/checkouts/{id}")]
        public Check_out Getdetails(int id)
        {
            Check_out check_out = new Checkout_DAO().Selectbycode(id);
            return check_out;

        }
        [HttpGet]
        [Route("api/checkouts/search/{keyword}")]
        public List<Check_out> Search(String keyword)
        {
            List<Check_out> check_outs = new Checkout_DAO().Selectbyword(keyword);
            return check_outs;
        }
        [HttpPost]
        [Route("api/checkouts")]
        public bool Addnew(Check_out newcheckout)
        {
            bool result = new Checkout_DAO().Insert(newcheckout);
            return result;
        }


        [HttpDelete]
        [Route("api/checkouts/{id}")]
        public bool Delete(int id)
        {
            bool result = new Checkout_DAO().Delete(id);
            return result;
        }


        [HttpPut]
        [Route("api/checkouts/{id}")]
        public bool Update(Check_out newcheckout)
        {
            bool result = new Checkout_DAO().Update(newcheckout);
            return result;
        }
    }
}