using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Novus.Models
{
    class Unit
    {
        public string Code { get; private set; }
        public string Name {get; private set;}
        public string Information;
        public string Colour { get; private set; }
        public Unit()
        {

        }
    }
}
