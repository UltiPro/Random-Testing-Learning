using APIContext;
using AutoMapper;
using CountryNamespace;
using entityf.Contracts;
using Microsoft.EntityFrameworkCore;

namespace entityf.Repository
{
    public class CountriesRepository : GenericRepository<Country>, ICountriesRepository
    {
        private readonly API context;
        public CountriesRepository(API context, IMapper mapper) : base(context, mapper)
        {
            this.context = context;
        }

        public async Task<Country> GetDetails(int id)
        {
            return await context.Countries.Include(q => q.Hotels).FirstOrDefaultAsync(q => q.CountryId == id);
        }
    }
}
