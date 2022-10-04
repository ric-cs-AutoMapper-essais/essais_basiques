using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    public class Source2
    {
        public int entier;
        public string chaineNumerique;
        public DateTime date;


        public IList<string> someStrings { get; set; }
        public IList<MaClasse> SomeInstances { get; set; }
    }
}
