using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleAPI.Models
{
    public class XYZ//Vector3 for all intents and purposes, just can't actually use one outside of unity
    {
        public float x = 0f;
        public float y = 0f;
        public float z = 0f;

        public XYZ(float _x, float _y, float _z)
        {
            x = _x;
            y = _y;
            z = _z;
        }
    }

}