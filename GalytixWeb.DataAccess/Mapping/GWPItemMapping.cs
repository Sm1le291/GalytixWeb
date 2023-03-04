using CsvHelper.Configuration;

using GalytixWeb.DataAccess.Models;

using System;
using System.Collections.Generic;
using System.Text;

namespace GalytixWeb.DataAccess.Mapping
{
    internal class GWPItemMapping : ClassMap<GWPItem>
    {
        public GWPItemMapping() 
        {
            Map(m => m.Country).Name("country");
            Map(m => m.VariableId).Name("variableId");
            Map(m => m.VariableName).Name("variableName");
            Map(m => m.LineOfBusiness).Name("lineOfBusiness");
            Map(m => m.Y2000).Name("Y2000").Default(new Nullable<double>());
            Map(m => m.Y2001).Name("Y2001").Default(new Nullable<double>());
            Map(m => m.Y2002).Name("Y2002").Default(new Nullable<double>());
            Map(m => m.Y2003).Name("Y2003").Default(new Nullable<double>());
            Map(m => m.Y2004).Name("Y2004").Default(new Nullable<double>());
            Map(m => m.Y2005).Name("Y2005").Default(new Nullable<double>());
            Map(m => m.Y2006).Name("Y2006").Default(new Nullable<double>());
            Map(m => m.Y2007).Name("Y2007").Default(new Nullable<double>());
            Map(m => m.Y2008).Name("Y2008").Default(new Nullable<double>());
            Map(m => m.Y2009).Name("Y2009").Default(new Nullable<double>());
            Map(m => m.Y2010).Name("Y2010").Default(new Nullable<double>());
            Map(m => m.Y2011).Name("Y2011").Default(new Nullable<double>());
            Map(m => m.Y2012).Name("Y2012").Default(new Nullable<double>());
            Map(m => m.Y2013).Name("Y2013").Default(new Nullable<double>());
            Map(m => m.Y2014).Name("Y2014").Default(new Nullable<double>());
            Map(m => m.Y2015).Name("Y2015").Default(new Nullable<double>());

        }
    }
}
