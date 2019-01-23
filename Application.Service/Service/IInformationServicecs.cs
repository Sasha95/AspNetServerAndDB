using Application.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Service
{
    public interface IInformationServicecs
    {
        Task<IQueryable<testInformation>> GetInformations();
        Task<testInformation> GetInformation(int id);
        Task<IEnumerable<testInformation>> GetInformationsConditions();
        Task AddInfoAsync(testInformation info);
    }
}
