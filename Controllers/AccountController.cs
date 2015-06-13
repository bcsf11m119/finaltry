//using project.Models;
using EADproject.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace project.Controllers
{
    public class AccountController : Controller
    {
        Database1Entities1 db = new Database1Entities1();

        //int count1 = 0;
        //int count2 = 0;
        IUser i;
        User user=null;
        public AccountController(IUser u)
        {
            i = u;

            //User u = db.Users.Last<User>();
            //count1 = db.Users.Last<User>().Uid;
            //u.Uid;
        }
        //File path;
        public ViewResult Login()
        {
            ///ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //     [AllowAnonymous]
        public ActionResult PlayList(User u1)
        {
            User u = (User)this.Session["sessionString"];
            if (u != null)
            {
                ViewBag.us = u;
                List<Video> vl = u.Videos.ToList();
                ViewBag.list = vl;
            }
            return View("PlayList");
        }

        public ViewResult Upload()
        //public ViewResult Upload(User u)
        {
            //ViewBag.us = this.user;
            //this.user = ViewBag.us;
            //List<Video> vl = u.Videos.ToList();
            //ViewBag.list = vl;

            User u = (User)this.Session["sessionString"];
            if (u != null)
            {
                ViewBag.us = u;
                List<Video> vl = u.Videos.ToList();
                ViewBag.list = vl;
            }
            return View("Upload");
        }

        public ActionResult Register()
        {
            User u = (User)this.Session["sessionString"];
            if (u != null)
            {
                ViewBag.us = u;
                List<Video> vl = u.Videos.ToList();
                ViewBag.list = vl;
            }
            return View();
            //return "";
        }
        [HttpPost]
        //public ViewResult CreateUser(User u)
        public RedirectToRouteResult CreateUser(User u)
        {
            //       db.Users.Attach(u);
            //db.Users.First(u);
            //if (db.Users.First())
            {

            }
            //User s = db.Users.Find(X = u.Uid);
            // u.Uid = ++count1;
            //u.Email = Request["email"];
            if (i.Add(u))
            {
                Playlist p = new Playlist();
                p.Uid = u.Uid;
                p.Name = "Defualt";
                p.UpdationDate = System.DateTime.Now;
                p.CreationDate = System.DateTime.Now;
             //   i.AddPlayList(p);
                //return View();
                user = u;
                this.Session["sessionString"]=u;
                ViewBag.us = u;
                List<Video> vl = u.Videos.ToList();
                ViewBag.list = vl;
                //return RedirectToAction("/Account/PlayList");
                return RedirectToAction("/PlayList");
                
            }
            else
                return RedirectToAction("LoginError");
            //db.Users.Add(u);

            //db.SaveChanges();
        }
        [HttpPost]
        public ViewResult Verify(User u)
        {
            //User s = db.Users.Find(u.Uid);

            User s = db.Users.First(x=>x.Email.Equals(u.Email));
            if (s == null)
            {
                return View("Error");
            }
            if (!s.password.Equals(u.password))
            {
                return View("Error");
            }
            //this.user = s;
            //System.Web.HttpContext.Current.Session["sessionString"] = s;
            this.Session["sessionString"] = s;
            //this.Session = s;
            //Video v = db.Videos.Find(x => x.Uid=u.Uid);
            //Video v = db.Videos.Find(x=> x.Uid= u.Uid);
            //PlayList p = db.PlayLists.Find(u.Uid);
            //List<Playlist> l = db.Playlists.ToList<Playlist>();
            //List<Video> vl= (List<Video>) l[0].Videos;

            List<Video> vl = s.Videos.ToList();//l[0].Videos.ToList();
            //var q = from x in l where x.Uid == u.Uid select x;
            //List<PlayList> c = q.ToList<PlayList>();
            //var q1 = from y in c where y.Vid
            ViewBag.us = this.user;
            ViewBag.list = vl;
            return View("PlayList");


        }

        [HttpPost]
        public ActionResult UploadFile(  HttpPostedFileBase file)
        {

            //User u = ViewBag.u;
            //User u=ViewBag.us;
            User u = (User)this.Session["sessionString"];
            Video v = new Video();
            if (u != null)
            {
                //i.AddVideo
                // Verify that the user selected a file
                if (file != null && file.ContentLength > 0)
                {
                    // extract only the fielname
                    var fileName = Path.GetFileName(file.FileName);
                    v.Name = fileName;
                    v.Description = Request["description"];
                    v.Date = System.DateTime.Now;
                    string ext = Path.GetExtension(file.FileName);
                    if (!ext.Equals(".mp4") && !ext.Equals(".mp3"))
                    {
                        //String err="Please  Upload Valid File";
                        return View("Error");
                    }
                    User s=db.Users.First(x => x.Email.Equals(u.Email));
                    //Playlist p=s.Playlists.First(x=>x.Uid==s.Uid);
                  
                    //Playlist p1 = db.Playlists.First();
                    //Video [] v1 =(Video [] )p1.Videos;
                    //v.Pid = p.Pid;
                    v.Uid = s.Uid;
                    v.ext = ext;
                    i.AddVideo(v);
                    //p.Videos;
                    //Array p=s.Playlists.ToArray();
                   //Playlist l ;
                    


                    // store the file inside ~/App_Data/uploads folder
                    //var path = Path.Combine(Server.MapPath("~/App_Data/upload"), fileName);
                    var path = Path.Combine(Server.MapPath("~/upload"), fileName);
                    file.SaveAs(path);
                    //v.Vid = ++count2;
                    u = db.Users.First(x => x.Email.Equals(u.Email));
                    this.Session["sessionString"] = u;
                    ViewBag.us = u;
                    List<Video> vl = u.Videos.ToList();//l[0].Videos.ToList();
                    //var q = from x in l where x.Uid == u.Uid select x;
                    //List<PlayList> c = q.ToList<PlayList>();
                    //var q1 = from y in c where y.Vid
                    ViewBag.list = vl;
                    return View("PlayList");

                }
            }
            // redirect back to the index action to show the form once again
            //return RedirectToAction("/Home/Index");
            //List<Video> vl = s.Videos.ToList();//l[0].Videos.ToList();
            //var q = from x in l where x.Uid == u.Uid select x;
            //List<PlayList> c = q.ToList<PlayList>();
            //var q1 = from y in c where y.Vid
            //ViewBag.list = vl;
            return View("PlayList");
        }

            public JsonResult uploadGet()
            {
                return this.Json(true,JsonRequestBehavior.AllowGet);
            }
            public JsonResult SubmitGet(string n)
            {
                return this.Json(true, JsonRequestBehavior.AllowGet);
            }
    }
}