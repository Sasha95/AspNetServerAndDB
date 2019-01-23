using Application.Data;
using Application.Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Application.WebApi.Controllers
{
    public class InformationController : ApiController
    {
        private IInformationServicecs informationServicecs = new InformationService();
        
        public IEnumerable<testInformation> Get()
        {
            return informationServicecs.GetInformations();
        }
    }
}
