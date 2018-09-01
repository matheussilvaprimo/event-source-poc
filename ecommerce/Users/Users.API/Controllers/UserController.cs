using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Users.Business;
using Users.Business.Model;

namespace Users.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserBusiness _business;

        public UserController()
        {
            _business = new UserBusiness();
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{document}")]
        public ActionResult<User> Get(string document)
        {
            return _business.GetUser(document);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] User user)
        {
            _business.SaveUser(user);

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
