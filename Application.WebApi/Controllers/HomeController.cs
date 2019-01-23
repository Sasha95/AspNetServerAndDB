using Application.Data;
using Application.Service.Service;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace Application.WebApi.Controllers
{
    public class HomeController : ApiController
    {
        private IInformationServicecs informationServicecs = new InformationService();
        public async Task<IQueryable<testInformation>> Get()
        {
            return await informationServicecs.GetInformations();
        }
        public async Task<IHttpActionResult> Get(int id)
        {
            var info = await informationServicecs.GetInformation(id);
            if (info == null)
                return NotFound();
            return Ok(info);
        }
        [Route("api/home/condition")]
        public async Task<IEnumerable<testInformation>> GetWithConditions()
        {
            return await informationServicecs.GetInformationsConditions();
        }
        [HttpPost]
        public async Task CreateInfo([FromBody]testInformation info)
        {
            await informationServicecs.AddInfoAsync(info);
        }
    }
}
