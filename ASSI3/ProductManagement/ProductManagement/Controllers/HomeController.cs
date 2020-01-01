using ProductManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;


namespace ProductManagement.Controllers
{
    public class HomeController : Controller
    {
        productmanagementEntities db = new productmanagementEntities();
        [HttpGet]
        public ActionResult register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult register(Tbl_Users reg, HttpPostedFileBase profile)
        {
            Tbl_Users u = new Tbl_Users();
            try
            {
                u.User_Email= reg.User_Email;
                u.User_Password = reg.User_Password;
                u.User_Name = reg.User_Name;
                u.User_Image = uploadprofile(profile); ;
                db.Tbl_Users.Add(u);
                db.SaveChanges();
                TempData["msg"] = "You are Registered Successfully!...";
                TempData.Keep();
                return RedirectToAction("login");
            }
            catch (Exception)
            {
                ViewBag.msg = "Sorry!, Data could not be Inserted...";
            }
            return View();
        }
        public string uploadprofile(HttpPostedFileBase profile)
        {

            String path = "-1";

            Tbl_Products pr = new Tbl_Products();

            if (profile != null && profile.ContentLength > 0)
            {

                string extension = Path.GetExtension(profile.FileName);
                if (extension.ToLower().Equals(".jpg") || extension.ToLower().Equals(".jpeg") || extension.ToLower().Equals(".png"))
                {
                    try
                    {
                        path = Path.Combine(Server.MapPath("~/Content/images"), pr.P_Id.ToString() + Path.GetFileName(profile.FileName));
                        profile.SaveAs(path);
                        path = "~/Content/images/" + pr.P_Id.ToString() + Path.GetFileName(profile.FileName);
                    }
                    catch (Exception)
                    {
                        path = "-1";
                    }
                }
                else
                {
                    Response.Write("<script>alert('Only JPG, JPEG, PNG formates are Acceptable...')</script>");
                }
            }

            return path;
        }

        [HttpGet]
        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login(Tbl_Users u)
        {
            Tbl_Users us = db.Tbl_Users.Where(x => x.User_Email == u.User_Email && x.User_Password == u.User_Password).SingleOrDefault();
            if (us != null)
            {
                Session["User_Id"] = us.User_Id;
                Session["User_Name"] = us.User_Name;
                Session["User_Email"] = us.User_Email;
                Session["User_Image"] = us.User_Image;
                TempData["msg"] =us.User_Name;
                TempData.Keep();
                return RedirectToAction("Dashboard");
            }
            else
            {
                ViewBag.msg = "Invalid Email or Password!,Please Try Again!....";
            }
            return View();
        }
        public ActionResult logout()
        {
            Session.Abandon();
            Session.RemoveAll();
            return RedirectToAction("Index");
        }
        public ActionResult Dashboard()
        {
            if (Session["User_Id"] == null)
            {
                return RedirectToAction("login");
            }
            return View();
        }
        [HttpGet]
        public ActionResult addproduct()
        {
            if (Session["User_Id"] == null)
            {
                return RedirectToAction("login");
            }
            int id = Convert.ToInt32(Session["User_Id"]);
            List<Tbl_Category> li = db.Tbl_Category.Where(x => x.C_Fkey_Uid == id).ToList();
            ViewBag.list = new SelectList(li, "C_Id", "C_Name");
            return View();
        }
        [HttpPost]
        public ActionResult addproduct(Tbl_Products pr, HttpPostedFileBase imgfile, HttpPostedFileBase imgfile1)
        {
            int id = Convert.ToInt32(Session["User_Id"]);
            List<Tbl_Category> li = db.Tbl_Category.Where(x => x.C_Fkey_Uid == id).ToList();
            ViewBag.list = new SelectList(li, "C_Id", "C_Name");
           
            Tbl_Products p = new Tbl_Products();
            try
            {
                p.P_Name = pr.P_Name;
                p.P_Price = pr.P_Price;
                p.P_Qty = pr.P_Qty;
                p.P_Short_Description = pr.P_Short_Description;
                p.P_Long_Description = pr.P_Long_Description;
                if(p.P_Long_Description==null)
                {
                    p.P_Long_Description = "";
                }
                p.P_SImage = uploadimage(imgfile);
                p.P_LImage = uploadimage1(imgfile1);
                p.P_Fkey_Cid = pr.P_Fkey_Cid;
                db.Tbl_Products.Add(p);
                db.SaveChanges();
                TempData["msg"] = "Product Added Successfully!...";
                TempData.Keep();
                return RedirectToAction("Viewproducts");
                
            }
            catch (Exception)
            {
                ViewBag.msg = "Sorry!, Data could not be Inserted...";
            }
            return View();
        }
        public string uploadimage(HttpPostedFileBase imgfile)
        {
           
            String path = "-1";
           
            Tbl_Products pr = new Tbl_Products();
            
            if (imgfile != null && imgfile.ContentLength > 0)
            {

                string extension = Path.GetExtension(imgfile.FileName);
                if (extension.ToLower().Equals(".jpg") || extension.ToLower().Equals(".jpeg") || extension.ToLower().Equals(".png"))
                {
                    try
                    {
                        path = Path.Combine(Server.MapPath("~/Content/images"), pr.P_Id.ToString() + Path.GetFileName(imgfile.FileName));
                        imgfile.SaveAs(path);
                        path = "~/Content/images/" + pr.P_Id.ToString() + Path.GetFileName(imgfile.FileName);
                    }
                    catch (Exception)
                    {
                        path = "-1";
                    }
                }
                else
                {
                    Response.Write("<script>alert('Only JPG, JPEG, PNG formates are Acceptable...')</script>");
                }
            }

            return path;
        }
        public string uploadimage1(HttpPostedFileBase imgfile1)
        {
           
            String path = "-1";

            Tbl_Products pr = new Tbl_Products();
            if (imgfile1 != null && imgfile1.ContentLength > 0)
            {

                string extension = Path.GetExtension(imgfile1.FileName);
                if (extension.ToLower().Equals(".jpg") || extension.ToLower().Equals(".jpeg") || extension.ToLower().Equals(".png"))
                {
                    try
                    {
                        path = Path.Combine(Server.MapPath("~/Content/images"), pr.P_Id.ToString() + Path.GetFileName(imgfile1.FileName));
                        imgfile1.SaveAs(path);
                        path = "~/Content/images/" + pr.P_Id.ToString() + Path.GetFileName(imgfile1.FileName);
                    }
                    catch (Exception)
                    {
                        path = "-1";
                    }
                }
                else
                {
                    Response.Write("<script>alert('Only JPG, JPEG, PNG formates are Acceptable...')</script>");
                }
            }

            return path;
        }
        
        public ActionResult Viewproducts(string sortOrder, string currentFilter, string searchString, int? page)
        {
            if (Session["User_ID"] == null)
            {
                return RedirectToAction("login");
            }

            // return View(db.Tbl_Products.ToList());
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.PriceSortParm = sortOrder == "price" ? "price_desc" : "price";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var products = from s in db.Tbl_Products
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.P_Name.Contains(searchString)
                                       || s.P_Price.Contains(searchString) || s.P_Qty.Contains(searchString)
                                       || s.P_Short_Description.Contains(searchString) || s.Tbl_Category.C_Name.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    products = products.OrderByDescending(s => s.P_Name);
                    break;
                case "price":
                    products = products.OrderBy(s => s.P_Price);
                    break;
                case "price_desc":
                    products = products.OrderByDescending(s => s.P_Price);
                    break;
                default:
                    products = products.OrderBy(s => s.P_Name);
                    break;
            }
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(products.ToPagedList(pageNumber, pageSize));
           // return View(products.ToList());


        }
        [HttpGet]
        public ActionResult Addcat()
        {
            if (Session["User_Id"] == null)
            {
                return RedirectToAction("login");
            }
            int User_Id = Convert.ToInt32(Session["User_Id"].ToString());
            List<Tbl_Category> li = db.Tbl_Category.Where(x => x.C_Fkey_Uid==User_Id).OrderByDescending(x => x.C_Id).ToList();
            ViewData["list"] = li;

            return View();
            
        }
        [HttpPost]
        public ActionResult Addcat(Tbl_Category cat)
        {
           
            List<Tbl_Category> li = db.Tbl_Category.OrderByDescending(x => x.C_Id).ToList();
            ViewData["list"] = li;
            Tbl_Category c = new Tbl_Category();
            c.C_Name = cat.C_Name;
            c.C_Fkey_Uid = Convert.ToInt32(Session["User_Id"].ToString());
            db.Tbl_Category.Add(c);
            db.SaveChanges();
            TempData["msg"] = "Category Added Successfully!...";
            TempData.Keep();
            return RedirectToAction("Addcat");
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            int id1 = Convert.ToInt32(Session["User_Id"]);
            List<Tbl_Category> li = db.Tbl_Category.Where(x => x.C_Fkey_Uid == id1).ToList();
            ViewBag.list = new SelectList(li, "C_Id", "C_Name");
            var p = db.Tbl_Products.Where(x => x.P_Id == id).FirstOrDefault();
           

            return View(p);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include =
        "P_Id,P_Name,P_Price,P_Qty,P_Short_Description,P_Long_Description,P_SImage,P_LImage,P_Fkey_Cid")] Tbl_Products pr, HttpPostedFileBase imgfile, HttpPostedFileBase imgfile1)
        {

            int id = Convert.ToInt32(Session["User_Id"]);
            List<Tbl_Category> li = db.Tbl_Category.Where(x => x.C_Fkey_Uid == id).ToList();
            ViewBag.list = new SelectList(li, "C_Id", "C_Name"); 
            Tbl_Products p = new Tbl_Products();
              try
                {
                    p.P_Name = pr.P_Name;
                    p.P_Price = pr.P_Price;
                    p.P_Qty = pr.P_Qty;
                    p.P_Short_Description = pr.P_Short_Description;
                    p.P_Long_Description = pr.P_Long_Description;
                    if (pr.P_Long_Description == null)
                     {
                         pr.P_Long_Description = "";
                     }
                    p.P_Fkey_Cid = pr.P_Fkey_Cid;
                    pr.P_SImage = uploadimage3(imgfile);
                     if (imgfile == null)
                     {
                        Tbl_Products thisProduct = db.Tbl_Products.Where(x => x.P_Id == pr.P_Id).FirstOrDefault();
                        pr.P_SImage = thisProduct.P_SImage;
                     }
                    pr.P_LImage = uploadimage4(imgfile1);
                     if (imgfile1 == null)
                     {
                         Tbl_Products thisProduct = db.Tbl_Products.Where(x => x.P_Id == pr.P_Id).FirstOrDefault();
                         pr.P_LImage = thisProduct.P_LImage;
                     }
                db.Set<Tbl_Products>().AddOrUpdate(pr);
                  // db.Entry(pr).State = EntityState.Modified;
                    db.SaveChanges();
                    TempData["msg"] = "Product Updated Successfully!...";
                    TempData.Keep();
                    return RedirectToAction("Viewproducts");

                }
                catch (Exception)
            {
                ViewBag.msg = "Sorry!, Data could not be Updated...";
            }
            return View();
        }
        public string uploadimage3(HttpPostedFileBase imgfile)
        {

            String path = "-1";

            Tbl_Products pr = new Tbl_Products();
            if (imgfile != null && imgfile.ContentLength > 0)
            {

                string extension = Path.GetExtension(imgfile.FileName);
                if (extension.ToLower().Equals(".jpg") || extension.ToLower().Equals(".jpeg") || extension.ToLower().Equals(".png"))
                {
                    try
                    {
                        path = Path.Combine(Server.MapPath("~/Content/images"), pr.P_Id.ToString() + Path.GetFileName(imgfile.FileName));
                        imgfile.SaveAs(path);
                        path = "~/Content/images/" + pr.P_Id.ToString() + Path.GetFileName(imgfile.FileName);
                    }
                    catch (Exception)
                    {
                        path = "-1";
                    }
                }
                else
                {
                    Response.Write("<script>alert('Only JPG, JPEG, PNG formates are Acceptable...')</script>");
                }
            }

            return path;
        }

        public string uploadimage4(HttpPostedFileBase imgfile1)
        {

            String path = "-1";

            Tbl_Products pr = new Tbl_Products();
            if (imgfile1 != null && imgfile1.ContentLength > 0)
            {

                string extension = Path.GetExtension(imgfile1.FileName);
                if (extension.ToLower().Equals(".jpg") || extension.ToLower().Equals(".jpeg") || extension.ToLower().Equals(".png"))
                {
                    try
                    {
                        path = Path.Combine(Server.MapPath("~/Content/images"), pr.P_Id.ToString() + Path.GetFileName(imgfile1.FileName));
                        imgfile1.SaveAs(path);
                        path = "~/Content/images/" + pr.P_Id.ToString() + Path.GetFileName(imgfile1.FileName);
                    }
                    catch (Exception)
                    {
                        path = "-1";
                    }
                }
                else
                {
                    Response.Write("<script>alert('Only JPG, JPEG, PNG formates are Acceptable...')</script>");
                }
            }

            return path;
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Tbl_Products product = db.Tbl_Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: PersonalDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tbl_Products product = db.Tbl_Products.Find(id);
            db.Tbl_Products.Remove(product);
            db.SaveChanges();
            TempData["msg"] = "Product Deleted Successfully!...";
            TempData.Keep();
            return RedirectToAction("Viewproducts");
        }
        [HttpGet]
        public ActionResult Editcat(int? id)
        {
            int User_Id = Convert.ToInt32(Session["User_Id"].ToString());
            var cat = db.Tbl_Category.Where(x => x.C_Id == id).FirstOrDefault();

            return View(cat);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editcat([Bind(Include = "C_Id,C_Name")] Tbl_Category cat)
        {
            Tbl_Category c = new Tbl_Category();
            try
            {
                c.C_Name = cat.C_Name;
                if (c.C_Fkey_Uid == null)
                {
                    Tbl_Category thiscat = db.Tbl_Category.Where(x => x.C_Id == cat.C_Id).FirstOrDefault();
                    cat.C_Fkey_Uid = thiscat.C_Fkey_Uid;
                }
                db.Set<Tbl_Category>().AddOrUpdate(cat);
                db.SaveChanges();
                TempData["msg"] = "Category Updated Successfully!...";
                TempData.Keep();
                return RedirectToAction("Addcat");
            }
            catch(Exception)
            {
                ViewBag.msg = "Sorry!, Category could not be Updated...";
            }
            return View();
        }
        public ActionResult Deletecat(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Tbl_Category cat = db.Tbl_Category.Find(id);
            if (cat == null)
            {
                return HttpNotFound();
            }
            return View(cat);
        }

        // POST: PersonalDetails/Delete/5
        [HttpPost, ActionName("Deletecat")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletecatConfirmed(int id)
        {
            try
            {
                Tbl_Category cat = db.Tbl_Category.Find(id);
                db.Tbl_Category.Remove(cat);
                db.SaveChanges();
                TempData["msg"] = "Category Deleted Successfully!...";
                TempData.Keep();
                return RedirectToAction("Addcat");
            }
            catch(Exception)
            {
                TempData["msg1"] = "Sorry! This Category Can not be Deleted!..May Some Product(s) belong to this Category";
                TempData.Keep();
                return RedirectToAction("Addcat");
            }
            //return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {

            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}