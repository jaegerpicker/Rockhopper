using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rockhopper.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Rockhopper.Controllers
{
    [Route("api/[controller]")]
    public class LauncherController : Controller
    {
        AppRepository apps = new AppRepository();       
        // GET: api/launcher
        [HttpGet]
        public IEnumerable<Rockhopper.Models.AppModel> Get()
        {
            return apps.GetAll();
        }

        // POST api/launcher
        // Launcher a new application
        [HttpPost]
        public void Post([FromBody]AppModel value)
        {
            apps.Add(value);
        }

        // GET api/launcher/1
        // get app information
        [HttpGet]
        public AppModel Get(String Id)
        {
            return apps.Find(Id);
        }

        // PUT api/values/5
        // Restart application by id
        [HttpPut("{id}")]
        public void Put(string id)
        {
            apps.Update(id);
        }

        // DELETE api/values/5
        // Stop application by id
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            apps.Remove(id);
        }
    }
}
