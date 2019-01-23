using Application.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Application.Service.Service
{
    public class InformationService : IInformationServicecs
    {
        private InformationDbEntities db = new InformationDbEntities();

        public async Task AddInfoAsync(testInformation info)
        {
            await Task.Run(() => db.testInformation.Add(info));
            await db.SaveChangesAsync();
        }

        public async Task<testInformation> GetInformation(int id)
        {
            return await Task.Run(()=>db.testInformation.Where(x => x.id == id).FirstOrDefault());
        }

        public async Task<IQueryable<testInformation>> GetInformations()
        {
            return await Task.Run(()=>db.testInformation.AsNoTracking());
        }

        public async Task<IEnumerable<testInformation>> GetInformationsConditions()
        {
            return await Task.Run(() => db.testInformation.SqlQuery("exec MyBestProcedurina").AsNoTracking().ToList()); 
        }
    }
}