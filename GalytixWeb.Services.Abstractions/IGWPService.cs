using System.Collections.Generic;
using System.Threading.Tasks;

namespace GalytixWeb.Services.Abstractions
{
    public interface IGWPService
    {
        Task<Dictionary<string, double>> CalculateForCountryAndLob(string country, IEnumerable<string> lob);
    }
}
