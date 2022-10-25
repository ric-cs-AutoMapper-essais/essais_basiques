using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using Transverse.Common.DebugTools;

namespace ConsolePrj
{

    //*************** >>>>>>>>> ATTENTION : toujours mettre en public property { get; set; } les membres intervenant dans la conversion <<<<<<<<<<< **********
    class Entite
    {
        public int Id { get; set; }
        public string Nom { get; set; }

        public List<SousEntite> SousEntites { get; set; }
    }

    class SousEntite
    {
        public int Id { get; set; }
        public double Poids { get; set; }
    }

    //---------------------------------------------------------

    class EntiteDTO
    {
        public int ID { get; set; }

        public List<SousEntiteDTO> SousEntites { get; set; }
        public int NombreSousEntites { get; set; }
    }

    class SousEntiteDTO
    {
        public int PoidsEnGrammes { get; set; }
    }

    class EntitesDTO
    {
        public List<EntiteDTO> Entites { get; set; }
        public int NombreSousEntites { get; set; }
    }



    //---------------------------------------------------------

    static class Program
    {
        static void Main()
        {
            Tester();

            
            Console.WriteLine("\n\nOk"); Console.ReadKey();
        }

        private static void Tester()
        {
            MapperConfiguration autoMapperConfig = GetAutoMapperConfig();
            IMapper autoMapper = autoMapperConfig.CreateMapper();

            var entites = GetEntites();
            var entitesDTO = autoMapper.Map<List<Entite>, EntitesDTO>(entites);

            Debug.ShowData(entitesDTO);
        }

        private static MapperConfiguration GetAutoMapperConfig()
        {
            MapperConfiguration retour = new MapperConfiguration(
                (IMapperConfigurationExpression configExpr) =>
                {
                    configExpr.CreateMap<Entite, EntiteDTO>()
                        //.ForMember(dto => dto.ID, opt => opt.MapFrom(entite => entite.Id)) //Pas besoin car insensible à la casse
                        .ForMember(dto => dto.NombreSousEntites, opt => opt.MapFrom(entite => entite.SousEntites.Count))
                    ;

                    configExpr.CreateMap<SousEntite, SousEntiteDTO>()
                        .ForMember(dto => dto.PoidsEnGrammes, opt => opt.MapFrom(sousEntite => Convert.ToInt32(sousEntite.Poids * 1000)))
                    ;

                    configExpr.CreateMap<List<Entite>, EntitesDTO>()
                        .ForMember(dto => dto.Entites, opt => opt.MapFrom(entites => entites))
                        .ForMember(dto => dto.NombreSousEntites, opt => opt.MapFrom(entites => entites.Sum(entite => entite.SousEntites.Count)))
                    ;
                }
            );
            return retour;
        }

        private static List<Entite> GetEntites()
        {
            var retours = new List<Entite>
            {
                new Entite
                {
                    Id = 1,
                    Nom = "E1",
                    SousEntites = new List<SousEntite>
                    {
                        new SousEntite
                        {
                            Id = 10,
                            Poids = 100
                        },
                        new SousEntite
                        {
                            Id = 11,
                            Poids = 110
                        },
                        new SousEntite
                        {
                            Id = 12,
                            Poids = 120
                        }

                    }
                },

                new Entite
                {
                    Id = 2,
                    Nom = "E2",
                    SousEntites = new List<SousEntite>
                    {
                        new SousEntite
                        {
                            Id = 20,
                            Poids = 200
                        },
                        new SousEntite
                        {
                            Id = 21,
                            Poids = 210
                        },

                    }
                }
            };
            return retours;
        }

    }
}
