using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inbrand.App_Start
{
    [System.AttributeUsage(System.AttributeTargets.Class | System.AttributeTargets.Struct)]
    public class ContainerControlledAttribute :Attribute
    {
     
        
            public double version;

            public ContainerControlledAttribute()
            {
                version = 1.0;
            }
        
    }
}