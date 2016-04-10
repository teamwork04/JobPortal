using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;

namespace WebApplication9.Controllers
{
    public class FileUploadController : Controller
    {
        // GET: Hello
        public ActionResult Index()
        {
            return View();
        }
        //public getdata()
        //{
        //    string str = "UPDATE Table1 SET Username=@u,Password=@pss,Phone=@phone WHERE ID=@id";
        //    SqlConnection sql = new SqlConnection(conn);
        //    SqlCommand cmd = new SqlCommand(str, sql);
        //    cmd.Parameters.AddWithValue("@u", TextBox2.Text);
        //    cmd.Parameters.AddWithValue("@pss", TextBox3.Text);
        //    cmd.Parameters.AddWithValue("@id", TextBox1.Text);
        //    cmd.Parameters.AddWithValue("@phone", TextBox4.Text);
        //    int updated;
        //    try
        //    {
        //        sql.Open();
        //        updated = cmd.ExecuteNonQuery();
        //        Label2.Text = updated.ToString() + " record updated.";
        //        fill();
        //    }
        //    catch (Exception err)
        //    {
        //        Label2.Text = "Error updating Table1. ";
        //        Label2.Text += err.Message;
        //    }
        //    finally
        //    {
        //        sql.Close();
        //    }
        //}
        public ActionResult Load(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
                try
                {
                    string path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/Images"),
                                               Path.GetFileName(file.FileName));
                    file.SaveAs(path);
                    ViewBag.Message = "File uploaded successfully";
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
            else
            {
                ViewBag.Message = "You have not specified a file.";
            }
            return View();
        }
    }
}