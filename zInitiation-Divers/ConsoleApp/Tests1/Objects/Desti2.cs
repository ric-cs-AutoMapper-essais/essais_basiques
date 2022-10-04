using System.Collections.Generic;

namespace ConsoleApp
{
    public class Desti2
    {
        public string entier; //La conversion int vers string, sera automatique
        public int chaineNumerique; //La conversion chaineNumerique vers nombre, sera automatique

        public string date;

        public IList<string> somestrings { get; set; }

        public IList<MaClasse> SomeInstances { get; set; }
    }
}
