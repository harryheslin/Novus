using System;
using System.Collections.Generic;
using System.Text;

namespace Novus.Models
{
    class Information
    {
        public string[] Lines { get; private set; }

        public Information(string[] Lines)
        {
            this.Lines = Lines;
        }
    }
}
