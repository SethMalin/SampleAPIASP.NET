using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleAPI.Models
{
    public static class XYZToString
    {
        static string XYZString ;

        public static string ConvertToString(XYZ _toConvert)
        {
            XYZString = _toConvert.x + "," + _toConvert.y + "," + _toConvert.z;
            return XYZString;
        }
    }
}