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
    public class AccountController : ApiController
    {
        [HttpGet]
        [Route("api/accounts")]
        public List<Account> laydanhsach()
        {
            List<Account> accounts = new Account_DAO().laytatca();
            return accounts;
        }
        [HttpGet]
        [Route("api/accounts/{id}")]
        public Account Getdetails(int id)
        {
            Account account = new Account_DAO().Selectbycode(id);
            return account;

        }
        [HttpGet]
        [Route("api/accounts/get/{username}")]
        public Account Getuser(string username)
        {
            Account usernames = new Account_DAO().Selectbyusername(username);
            return usernames;
        }
        [HttpGet]
        [Route("api/accounts/take/{password}")]
        public Account Getpass(string password)
        {
            Account passwords = new Account_DAO().Selectbypass(password);
            return passwords;
        }
        [HttpGet]
        [Route("api/accounts/search/{keyword}")]
        public List<Account> Search(String keyword)
        {
            List<Account> accounts = new Account_DAO().Selectbyword(keyword);
            return accounts;
        }
        [HttpPost]
        [Route("api/accounts")]
        public bool Addnew(Account newaccount)
        {
            bool result = new Account_DAO().Insert(newaccount);
            return result;
        }

        [HttpDelete]
        [Route("api/accounts/{id}")]
        public bool Delete(int id)
        {
            bool result = new Account_DAO().Delete(id);
            return result;
        }

        [HttpPut]
        [Route("api/accounts/{id}")]
        public bool Update(Account newaccount)
        {
            bool result = new Account_DAO().Update(newaccount);
            return result;
        }

    }
}