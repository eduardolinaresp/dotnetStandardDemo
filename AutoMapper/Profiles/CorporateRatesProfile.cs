using AutoMapper.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper.Profiles
{
    public class CorporateRatesProfile : Profile
    {
        
        public CorporateRatesProfile()
        {

            CreateMap<JObject, SaaCode>()
                .ForMember("Code", cfg => { cfg.MapFrom(jo => jo["code"]); })
                .ForMember("Description", cfg => { cfg.MapFrom(jo => jo["description"]); });

            CreateMap<JObject, CorporateRatesInfo>()
                .ForMember("SaaCodes", cfg => { cfg.MapFrom(jo => jo["sAA"]); })
                .ForMember("Conum", cfg => { cfg.MapFrom(jo => jo["conum"]); })
                .ForMember("Name", cfg => { cfg.MapFrom(jo => jo["name"]); })
                .ForMember("AgencyName", cfg => { cfg.MapFrom(jo => jo["agencyName"]); });

        }        

    }
}
