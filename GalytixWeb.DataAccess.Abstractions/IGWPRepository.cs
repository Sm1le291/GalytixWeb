using GalytixWeb.DataAccess.Models;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GalytixWeb.DataAccess.Abstractions
{
    public interface IGWPRepository
    {
        public Task<IEnumerable<GWPItem>> GetByCountryAndLob(string country, IEnumerable<string> lob);
    }
}
