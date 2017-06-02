using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Treinamento.Angular.Api.Data;
using Treinamento.Angular.Api.Models;
using Treinamento.Angular.Api.Security;
using Microsoft.EntityFrameworkCore;

namespace Treinamento.Angular.Api.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly DataContext _context;

        public AccountController(DataContext context)
        {
            _context = context;
        }


        [HttpPost]
        [Route("v1/accounts")]
        public IActionResult Post([FromBody]Account account)
        {
            account.Date = DateTime.Now;
            _context.Account.Add(account);
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet]
        [Route("v1/accounts")]
        public IActionResult Get()
        {
            return Ok(_context.Account.ToList());
        }

        [HttpPut]
        [Route("v1/accounts/{id}")]
        public IActionResult Put(Guid id, [FromBody]Account account)
        {
            var acc = _context.Account.Find(id);
            acc.Description = account.Description;
            acc.Value = account.Value;

            _context.Entry(acc).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet]
        [Route("v1/accounts/{skip}/{take}")]
        public IActionResult Get(int skip, int take)
        {
            return Ok(_context.Account.Skip(skip).Take(take).ToList());
        }

        [HttpGet]
        [Route("v1/accounts/{id}")]
        public IActionResult Get(Guid id)
        {
            return Ok(_context.Account.FirstOrDefault(c => c.Id == id));
        }

        [HttpDelete]
        [Route("v1/accounts/{id}")]
        public IActionResult Delete(Guid id)
        {
            _context.Account.Remove(_context.Account.Find(id));
            _context.SaveChanges();
            return Ok();
        }

        
    }

}