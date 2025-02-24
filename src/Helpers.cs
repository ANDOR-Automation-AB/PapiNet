using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PapiNet.WoodX.src
{
    public class XHelpers
    {
        public static XElement? GetDate(DateTime? date)
        {
            if (date == null)
                return null;

            string year = date?.ToString("yyyy") ?? string.Empty;
            string month = date?.ToString("MM") ?? string.Empty;
            string day = date?.ToString("dd") ?? string.Empty;

            return new XElement("Date",
                new XElement("Year", year),
                new XElement("Month", month),
                new XElement("Day", day)
            );
        }

        public static DateTime? ParseDate(XElement? dateElement)
        {
            if (dateElement == null)
                return null;

            if (int.TryParse(dateElement.Element("Year")?.Value, out int year) &&
                int.TryParse(dateElement.Element("Month")?.Value, out int month) &&
                int.TryParse(dateElement.Element("Day")?.Value, out int day))
                return new DateTime(year, month, day);
            
            return null;
        }

    }
}
