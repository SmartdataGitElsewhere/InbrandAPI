using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inbrand.App_Start
{
    [System.AttributeUsage(System.AttributeTargets.Class | System.AttributeTargets.Struct)]
    public class TransientLifetimeAttribute : System.Attribute
    {
        public double version;

        public TransientLifetimeAttribute()
        {
            version = 1.0;
        }
    }
}