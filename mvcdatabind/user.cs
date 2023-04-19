using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvcdatabind
{
    public class user
    {
        public int id1 { get; set; }
        public string name1 { get; set; }
        public string address1 { get; set; }
        public string gender { get; set; }

        public string country { get; set; }

        public string state { get; set; }  
        
        public int city { get; set; }

        public string phoneno { get; set; }

        public string email { get; set; }

        public int countryid { get; set; }

        public string cityname { get; set; }
        public int stateid { get; set; }


        public List<user> listuser { get; set; }

        ////
        public string name { get; set; }

        public string address { get; set; }
        public string city1 { get; set; }






    }
}