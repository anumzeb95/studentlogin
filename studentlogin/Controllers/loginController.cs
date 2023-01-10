using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using studentlogin.Models;
using System.Data.SqlClient;
using System.Configuration;
using user.Services;

namespace studentlogin.Controllers
{
    public class loginController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;

        string constring = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;

        // GET: login

        [HttpGet]
        public ActionResult Login()
        {
            return View(loginService.GetAll());
        }

        public ActionResult verify(login login)
        {
                   
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from login where Name= '"+login.Username+"' and password= '"+login.Password+"'";

            dr = com.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                return View("Create");
            }
            else
            {
                con.Close();
                return View("Error");
            }

        }

        [HttpPost]
        public ActionResult Add(login model)
        {
            loginService.Add(model);
            return View(loginService.GetAll());
        }



    }
}