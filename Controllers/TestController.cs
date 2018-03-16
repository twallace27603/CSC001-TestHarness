using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using DataServiceClient.Models;

namespace DataServiceTestClient.Controllers
{
    public class TestController : ApiController
    {
        public async Task<APIDemoData> Get()
        {
            var context = new DemoDataContext();
            return  new APIDemoData(await context.GetList(), System.Environment.MachineName);

        }
    }
    public class APIDemoData
    {
        public List<DemoData> Payload { get; set; }
        public string Server { get; set; }
        public DateTime Created { get; set; }
        public APIDemoData(List<DemoData> payload, string server)
        {
            this.Payload = payload;
            this.Created = DateTime.Now;
            this.Server = server;
        }
    }
}
