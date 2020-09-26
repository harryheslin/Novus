using System;
using System.Collections.Generic;
using System.Text;

namespace Novus.Models
{
    class Information
    {
        public string Line { get; private set; }

        public Information(string Line)
        {
            this.Line = Line;
        }
    }
}
