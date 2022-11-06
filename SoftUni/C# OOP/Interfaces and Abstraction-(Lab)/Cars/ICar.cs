using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public interface ICar
    {
        public string Model { get;}
        public string Color { get;}

        string Start();

        string Stop();
    }
}
