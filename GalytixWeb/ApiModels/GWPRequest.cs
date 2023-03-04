using System;
using System.Collections.Generic;

namespace GalytixWeb.ApiModels
{
    public class GWPRequest
    {
        public string Country { get; set; }

        public IEnumerable<string> LOB { get; set; }
    }
}
