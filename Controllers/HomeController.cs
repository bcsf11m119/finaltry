using EADproject.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace project.Models
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        Database1Entities1 db = new Database1Entities1();
 //       Database1Entities1 db = new Database1Entities1();
        public ViewResult Index()
        {
            User u = (User)this.Session["sessionString"];
            if (u != null)
            {
                ViewBag.us = u;
                List<Video> vl = u.Videos.ToList();
                ViewBag.list = vl;
            }
            return View();
        }

        public ViewResult About()
        {
            User u = (User)this.Session["sessionString"];
            if (u != null)
            {
                ViewBag.us = u;
                List<Video> vl = u.Videos.ToList();
                ViewBag.list = vl;
            }
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ViewResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        
        //public ViewResult Play(Video v)
        public ViewResult Play(string name)

        {

            Video v = new Video();
            Video v1 = db.Videos.First(x => x.Name.Equals(name));
            v.Name = v1.Name;
            //v.Name = v.Name + v1.ext;


            //v1.Name = name;
            // v.Name;//name;
            //ViewBag.name;
            //System.Console.WriteLine(name);
            //string n = v.Name;
        //    string n = name;

                //Request["videoName"];
                
                //name;
                //"Hands in the Air.mp4";
            
            // name;    //v.Name;
                //ViewBag.name;  //Request["videoName"];
         //   n=n.Insert(n.Length, ".mp4");
          //  n = n + ".mp4";

            //return View(n);
            //v.Name = v.Name + ".mp4";
            //v1.Name = v1.Name + ".mp4";
            //v1.Name = "preview-upbeat-feeling.mp3";
            User u = (User)this.Session["sessionString"];
            if (u != null)
            {
                ViewBag.us = u;

                List<Video> vl = u.Videos.ToList();
                ViewBag.list = vl;
            }
            return View(v);
        }
        
        public ViewResult Search()
        {
            User u = (User)this.Session["sessionString"];
            ViewBag.us = u;
            if (u != null)
            {
                List<Video> vl = u.Videos.ToList();
                ViewBag.list = vl;
            }

            string s1 = Request["search"];
                List<Video> s = new List<Video>();
            if (s1.Equals(""))
            {
                //return View(db.Videos.ToList());
                //return View("/Account/Error");
                //return View(db.Videos.ToList());
                return View(db.Videos.ToList<EADproject.Models.Video>());
                //return View(db.Videos.ToArray());
            }
            else
            {
                //db.Videos.First(x => x.Name.Equals(s1));
                List<Video> l = db.Videos.ToList();
                
                foreach( var i in l)
                {
                    if (i.Name.Contains(s1))
                    //if(i.Name.)
                    {
                        s.Add(i);
                        continue;
                    }
                    string[] items = s1.Split(' ');
                    foreach (var j in items)
                    {
                        if (i.Name.Contains(j))
                        {
                            s.Add(i); break;
                        }
                    }
                }
            }

            //Video  v=db.Videos.Find("name like \'"+s1+"\'");
            //Vide,o [] v =db.Videos.Select<Video,Video[]>("name like \'" + s1 + "\'");
            //Video v = db.Videos.First(23);
            //Video v = db.Videos.SelectMany

            //var q = from x in db where 

            //return View("Search.cshtml");
            return View(s);
            // else return View("string not found");
        }

        public ViewResult falak()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ViewResult Atif()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ViewResult demi()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ViewResult arijit()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ViewResult farhan()
        {
            ViewBag.Message = "Your contact page.";

            return View("farhan");
        }




    }


}