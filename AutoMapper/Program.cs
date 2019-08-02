using AutoMapper;
using AutoMapper.Dto;
using AutoMapper.Models;
using AutoMapper.Profiles;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper
{
    class Program
    {
        

        static void Main(string[] args)
        {
            ApplicationDBContext db = new ApplicationDBContext();

            var lv_config = new MapperConfiguration(cfg => {
                cfg.CreateMap<AuthorModel, AuthorDTO>();
            });


            IMapper iMapper = lv_config.CreateMapper();
            var source = new AuthorModel();
            source.Id = 1;
            source.FirstName = "Eduardo";
            source.LastName = "Linares";
            source.Address = "Santiago";
            var destination = iMapper.Map<AuthorModel, AuthorDTO>(source);
            Console.WriteLine("Author Name: " + destination.FirstName + " " + destination.LastName);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<JObject, CorporateRatesInfo>();
                cfg.AddProfile<CorporateRatesProfile>();
            });

            //config.AssertConfigurationIsValid();
            var mapper = config.CreateMapper();

            var jsonText = @"
                            {
                                ""conum"" : 1001,
                                ""name"" : ""CLN Industries Corporation"",
                                ""agencyName"" : ""Murphy, Holmes & Associates, LLC"",
                                ""sAA"" : [{
                                        ""code"" : 247,
                                        ""description"" : ""Mechanic\u0027s lien - Bond to Discharge - Fixed penalty - where principal has posted Performance and Pa""
                                    }, {
                                        ""code"" : 277,
                                        ""description"" : ""Mechanic\u0027s lien - Bond to Discharge - Open Penalty - where principal has posted Performance and Paym""
                                    }, {
                                        ""code"" : 505,
                                        ""description"" : ""Indemnity Bonds - Contractor\u0027s Indemnity Against Damages where there is a performance bond and addit""
                                    }
                                ]
                            }
                        ";

            var jsonoObj = JObject.Parse(jsonText);

            CorporateRatesInfo dto = mapper.Map<CorporateRatesInfo>(jsonoObj);

            try
            {
                db.CorporateRatesInfo.Add(dto);
                db.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
                        
            Console.ReadKey();
        }
    }
}
