using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleAPI.Models
{
    public class MetaTransform
    {
        public XYZ position = new XYZ(0, 0, 0);
        public XYZ rotation = new XYZ(0, 0, 0);
        public XYZ scale = new XYZ(0, 0, 0);

        public MetaTransform()
        {

        }

        public MetaTransform(XYZ position, XYZ rotation, XYZ scale)
        {
            this.position = position;
            this.rotation = rotation;
            this.scale = scale;
        }

        public override string ToString()
        {
            return $"Pos: ({position.x}, {position.y}, {position.z})\tRot: ({rotation.x}, {rotation.y}, {rotation.z})\tScale: ({scale.x}, {scale.y}, {scale.z})";
        }
    }

}