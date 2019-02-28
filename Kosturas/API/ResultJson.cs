using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kosturas.API
{
  

    public class ResultJson
    {
        public bool success { get; set; }
        public Data data { get; set; }
    }

    public class Data
    {
        public int id { get; set; }
        public string username { get; set; }
        public string nombre { get; set; }
        public string auth_key { get; set; }
        public string password_hash { get; set; }
        public string password_reset_token { get; set; }
        public string email { get; set; }
        public int status { get; set; }
        public int created_at { get; set; }
        public int updated_at { get; set; }
        public string access_token { get; set; }
    }

}
