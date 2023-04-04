using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Drawing;

namespace DrawingLightning
{
    class LightLine
    {
        public LightLine Next;
        public Point value;

        public LightLine(Point val)
        {
            value = val;
        }
    }
}
