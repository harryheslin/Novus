using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Novus.Models
{
    public class Information
    {
        public string Line { get; private set; }

        public Information(string line)
        {
            this.Line = line;
        }
    }
}
