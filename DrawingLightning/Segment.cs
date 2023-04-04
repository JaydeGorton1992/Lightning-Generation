using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DrawingLightning
{
    public class Segment
    {
        System.Drawing.Point start;
        System.Drawing.Point end;

        public Segment(System.Drawing.Point start, System.Drawing.Point end)
        {
            this.start = start;
            this.end = end;
        }

        public  System.Drawing.Point Average()
        {
            int x = (start.X + end.X)/2;
            int y = (start.Y + end.Y)/2;
            return new System.Drawing.Point(x,y);
        }
    }
}
