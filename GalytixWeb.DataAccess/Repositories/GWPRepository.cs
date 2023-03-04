using GalytixWeb.DataAccess.Abstractions;
using GalytixWeb.DataAccess.Models;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalytixWeb.DataAccess.Repositories
{
    public class GWPRepository : IGWPRepository
    {
        private readonly InMemoryContext _inMemoryContext;

        public GWPRepository(InMemoryContext inMemoryContext)
        {
            _inMemoryContext = inMemoryContext;
        }

        public async Task<IEnumerable<GWPItem>> GetByCountryAndLob(string country, IEnumerable<string> lob)
        {
            return await _inMemoryContext
                .GWPItems
                .Where(x =>
                x.Country == country
                &&
                lob.Contains(x.LineOfBusiness)).ToListAsync();
        }
    }
}
