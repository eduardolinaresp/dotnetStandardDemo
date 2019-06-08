using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using WinFormsCampusApp.Dto;
using Newtonsoft.Json.Linq;
using WinFormsCampusApp.Infrastructure;

namespace WinFormsCampusApp.Services.Implementation
{
    public class UsuarioService
    {


        public bool Add()
        {
            bool result = false;
            string _url = "http://localhost/api/users";

            try
            {
                using (var httpClient = new HttpClient())
                {



                }
            }


            catch (Exception)
            {

                throw;
            }


            return result;
        }





        public List<user> Get()
        {
            List<user> users = new  List<user>();
            string _url = "http://localhost/api/users";

            try
            {
                using (var httpClient = new HttpClient())
                {


                    var response = httpClient.GetAsync(_url).Result;

                    var responseJsonString = response.Content.ReadAsStringAsync().Result;

                    JsonSerializerSettings js = new Newtonsoft.Json.JsonSerializerSettings();

                    js.Formatting = Newtonsoft.Json.Formatting.Indented;
                    js.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

                    var DTInfo = JsonConvert.DeserializeObject<DataTablesInfo>(responseJsonString, js);

                    var jsonoObj = JObject.Parse(responseJsonString);

                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<JObject, DataTablesInfo>();
                        cfg.AddProfile<MappingProfile>();
                    });

                    var mapper = config.CreateMapper();

                    DataTablesInfo dto = mapper.Map<DataTablesInfo>(jsonoObj);

                    users = DTInfo.data;


                }

              
            }
            catch (Exception ex)
            {
                users = null;
                Console.WriteLine(ex.Message);
            }

            return users;
        }





        public List<user> GetDatabase()
        {

            List<user> usuarios = new List<user>();

            using (ApplicationDBcontext db = new ApplicationDBcontext())
            {
                try
                {

                    //usuarios = db.Users.Where(c => DbFunctions.TruncateTime(c.created_at)
                    //                            == DbFunctions.TruncateTime(DateTime.Now))                                               
                    //                           .ToList();

                    usuarios = db.Users.ToList();

                }
                catch (Exception ex)
                {

                    usuarios = null;


                }


            }

            return usuarios;
        }


    }
}
