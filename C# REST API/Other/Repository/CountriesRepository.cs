using APIContext;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CountryNamespace;
using entityf.Contracts;
using entityf.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace entityf.Repository
{
    public class CountriesRepository : GenericRepository<Country>, ICountriesRepository
    {
        private readonly API context;
        private readonly IMapper mapper;
        public CountriesRepository(API context, IMapper mapper) : base(context, mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<Country> GetDetails(int id)
        {
            var country = await context.Countries
                .Include(q => q.Hotels)
                .ProjectTo<Country>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(q => q.CountryId == id);

            if(country == null)
            {
                throw new NotFoundException(nameof(GetDetails), id);
            }

            return country;
        }
    }
}
