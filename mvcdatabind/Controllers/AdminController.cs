using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace mvcdatabind.Controllers
{
    public class AdminController : Controller
    {
       // private dynamic countrylist;

        // GET: Admin


        public ActionResult Index()
        {
           
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            Getcountry();
            //return View()
            BALuser objuser = new BALuser();
            DataSet ds = new DataSet();
            ds = objuser.displaylist();
            user objUserdetails = new user();
            List<user> ListUserDt1 = new List<user>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                user obju = new user();
                obju.id1 = Convert.ToInt32(ds.Tables[0].Rows[i]["id1"].ToString());
                obju.name1 = ds.Tables[0].Rows[i]["name1"].ToString();
                obju.address1 = ds.Tables[0].Rows[i]["address1"].ToString();
                obju.gender = ds.Tables[0].Rows[i]["gender"].ToString();
                obju.city = Convert.ToInt32(ds.Tables[0].Rows[i]["city"].ToString());
                obju.phoneno = ds.Tables[0].Rows[i]["phoneno"].ToString();
                obju.email = ds.Tables[0].Rows[i]["email"].ToString();
                ListUserDt1.Add(obju);
            }

            objUserdetails.listuser = ListUserDt1;
            return View(objUserdetails);
        }

        [HttpPost]
        public ActionResult Create(user obju)
        {
            BALuser objb = new BALuser();
            objb.savedata(obju.name1, obju.address1,obju.gender,obju.country,obju.state,obju.city,obju.phoneno,obju.email);
            Response.Write("<script>alert('Save successfully....!')</script>");
            
            return RedirectToAction("Create");
        }


        public void Getcountry()
        {
            BALuser objBal = new BALuser();
            DataSet ds = new DataSet();
            ds = objBal.getcountry();
            List<SelectListItem> countrylist = new List<SelectListItem>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                countrylist.Add(new SelectListItem
                {
                    Text = dr["countryname"].ToString(),
                    Value = dr["contryid"].ToString()
                });
                ViewBag.country = countrylist;
               // return Json(countrylist, JsonRequestBehavior.AllowGet);

            }



        }



        public JsonResult Getstate(int countryid)
        {
            BALuser objBal = new BALuser();
            DataSet ds = new DataSet();
            ds = objBal.getstate(countryid);
            List<SelectListItem> countrylist = new List<SelectListItem>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                countrylist.Add(new SelectListItem
                {
                    Text = dr["statename"].ToString(),
                    Value = dr["stateid"].ToString()
                });
            }
                //ViewBag.country = countrylist;
                 return Json(countrylist, JsonRequestBehavior.AllowGet);

        }




        public JsonResult Getcity(int stateid)
        {
            BALuser objBal = new BALuser();
            DataSet ds = new DataSet();
            ds = objBal.getcity(stateid);
            List<SelectListItem> citylist = new List<SelectListItem>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                citylist.Add(new SelectListItem
                {
                    Text = dr["cityname"].ToString(),
                    Value = dr["cityid"].ToString()
                });
            }
           // ViewBag.country = countrylist;
            return Json(citylist, JsonRequestBehavior.AllowGet);

        }


        


        [HttpGet]
        public ActionResult Edit(int id1)
        {
            user obju = new user();
            obju.id1 = id1;
            BALuser objUser = new BALuser();
            SqlDataReader dr;
            dr = objUser.Edit(obju.id1, obju.name1, obju.address1, obju.gender, obju.city, obju.phoneno, obju.email);
            while (dr.Read())
            {
                obju.id1 = Convert.ToInt32(dr["id1"].ToString());
                obju.name1 = (dr["name1"].ToString());
                obju.address1 = (dr["address1"].ToString());
                obju.gender = (dr["gender"].ToString());
                obju.city = Convert.ToInt32(dr["city"].ToString());
                obju.phoneno = (dr["phoneno"].ToString());
                obju.email = (dr["email"].ToString());
            }
            dr.Close();
            return View(obju);


        }
        [HttpPost]
        public ActionResult Edit(user obj)
        {
            BALuser objUser2 = new BALuser();
            objUser2.update1(obj.id1, obj.name1, obj.address1, obj.gender, obj.city, obj.phoneno, obj.email);
            return View();
        }

        

        public ActionResult Details(int id1)
        {
            //Getcountry();
            user obja = new user();
            obja.id1 = id1;
            BALuser objb = new BALuser();
            SqlDataReader dr;
            dr = objb.GetDetail(obja.id1);
            while(dr.Read())
            {
                obja.id1 = Convert.ToInt32(dr["id1"].ToString());
                obja.name1 = dr["name1"].ToString();
                obja.address1 = dr["address1"].ToString();
                obja.gender = dr["gender"].ToString();
                obja.cityname = dr["cityname"].ToString();
                obja.phoneno = dr["phoneno"].ToString();
                obja.email = dr["email"].ToString();



            }
            dr.Close();
            return PartialView(obja);


        }


        public ActionResult deletedata(int id1)
        {
            BALuser objd = new BALuser();
            objd.deletedata(id1);
            return RedirectToAction("create");
        }


    }
}