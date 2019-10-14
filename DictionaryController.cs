using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMenus.Controllers
{
    public class DictionaryController : Controller
    {
        static Dictionary<string, int> myNary = new Dictionary<string, int>();
        public int count = myNary.Count;
        public string found;
        public int num = myNary.Count + 1;
        public string cant = "";
        

        // GET: Dictionary
        public ActionResult Index()
        {
            
            ViewBag.MyNary = myNary;

            return View();
        }

        //add an entry to the dictionary by add: "new entry + count
        //from the amount of entries + 1. 0 entries outputs "New entry 1"
        //Then we take that stack and add it to our viewbag
        public ActionResult AddOne()
        { 
           
            //int count = myNary.Count;
    
                    myNary.Add(("New entry " + num), myNary.Count + 1);
           

            ++num;
            ViewBag.MyNary = myNary;
            return View("Index");
        }

        public ActionResult AddHugeList()
        {
            num = 1;
            myNary.Clear();
            ViewBag.MyNary = myNary;
                for (int i = 0; i < 2001; i++)
                {
                myNary.Add(("New entry " + num), myNary.Count + 1);
                ++num;
            }

                return View("Index");
        }
    
        public ActionResult Search()
        {

            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

            sw.Start();

            if (myNary.ContainsKey("New entry 1"))
            {
                Console.WriteLine("Key is present");
                found = "You found it";
                

            }

            else
            {
                Console.WriteLine("Key not present");
                found = "Key not present";
            }

            sw.Stop();

            TimeSpan ts = sw.Elapsed;
            ViewBag.Found = found;

            ViewBag.StopWatch = ts;
            return View("Foundit");

            

               
        }

        public ActionResult Displayit()
        {

            ViewBag.MyNary = myNary;
            return View("Displayit");
            /* Display ... - display the contents of the data structure. You must use the foreach loop when displaying the data. Handle any errors and inform the user. 
             * NOTE: You can send it back to the Index view or make another view
            
             */

        }

       public ActionResult Removeit()
        {
            if (myNary.Remove("New entry 1") == true)
            {
                myNary.Remove("New entry 1");
            }
            else
            {
                cant = "Can't be deleted";
                return View("Index");
            }
            ViewBag.Cant = cant;
            return View("Removeit");
        }

        public ActionResult Clearit()
        {

        // myNary.Remove("New Entry " + myNary.Count + 1, myNary.Count + 1);

        myNary.Clear();
        ViewBag.MyNary = myNary;
        return View("Index");
        }

        public ActionResult Redirection()
        {
            //return this.RedirectToAction<H>(m => m.LogIn());
            return RedirectToAction("Index", "Home");
           // return RedirectToAction("Index");
            //return RedirectToAction("Index",); does that method
            // return RedirectToAction("Index", "HomeController");
            // Response.Redirect(Url.Action("Index()", "HomeController"));
            //return RedirectToAction("Index()", "HomeController");
        }

    }
}