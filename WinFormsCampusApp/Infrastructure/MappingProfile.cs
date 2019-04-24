using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Newtonsoft.Json.Linq;
using WinFormsCampusApp.Dto;

namespace WinFormsCampusApp.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<JObject, user>()
                .ForMember("id", cfg => { cfg.MapFrom(jo => jo["id"]); })
                .ForMember("name", cfg => { cfg.MapFrom(jo => jo["name"]); })
                .ForMember("email", cfg => { cfg.MapFrom(jo => jo["email"]); })
                .ForMember("email_verified_at", cfg => { cfg.MapFrom(jo => jo["email_verified_at"]); })
                .ForMember("password", cfg => { cfg.MapFrom(jo => jo["password"]); })
                .ForMember("remember_token", cfg => { cfg.MapFrom(jo => jo["remember_token"]); })
                .ForMember("created_at", cfg => { cfg.MapFrom(jo => jo["created_at"]); })
                .ForMember("updated_at", cfg => { cfg.MapFrom(jo => jo["updated_at"]); });


            CreateMap<JObject, DataTablesInfo>()
                .ForMember("data", cfg => { cfg.MapFrom(jo => jo["data"]); })
                .ForMember("draw", cfg => { cfg.MapFrom(jo => jo["draw"]); })
                .ForMember("recordsTotal", cfg => { cfg.MapFrom(jo => jo["recordsTotal"]); })
                .ForMember("recordsFiltered", cfg => { cfg.MapFrom(jo => jo["recordsFiltered"]); });

               //" https://dotnetfiddle.net/eBziC6"


        }
    }
}
