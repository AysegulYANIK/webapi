using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientAPI
{
    public class Plant
    {
        int id;
        string genus;
        string species;
        string cultuvar;
        string common;

        public int Id { get => id; set => id = value; }
        public string Genus { get => genus; set => genus = value; }
        public string Species { get => species; set => species = value; }
        public string Cultuvar { get => cultuvar; set => cultuvar = value; }
        public string Common { get => common; set => common = value; }
    }
}