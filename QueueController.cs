using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using queue_version.Models;
using System.Diagnostics;

namespace queue_version.Controllers
{
    public class QueueController : Controller
    {
        static Queue<string> myQue = new Queue<string>();
       





        // GET: Queue
        public ActionResult Index()
        {
            if(myQue.Count==0)
            {
                ViewBag.q = myQue;
                return View("Index");
            }
            else
            {
                ViewBag.q_count = myQue.Count();
                ViewBag.q = myQue;
                return View("Index");
            }
            
        }
        //Adding an element to the Q
        public ActionResult Addone()
        {
            myQue.Enqueue("New entry number " + (myQue.Count + 1)); // concat the count of the adding one so it looks how a normal person will expect it to look
            ViewBag.q = myQue;
            return View("Index");
        }
        public ActionResult Delete_one() //gets rid of the top positon of the Q 
        {
            if (myQue.Count == 0)
            {                
                return Index();
            }
            else
            {
                myQue.Dequeue();
                ViewBag.q = myQue;
                return View("Index");
            }
        }

        public ActionResult Huge_list_add()
        {

            myQue.Clear(); // clears the Q as to ass 2,000 more elements
            
            for(int icount =0; icount < 2000; icount++) // adding elements
            {
                myQue.Enqueue("New entry number " + (icount+1));
            }

            ViewBag.q = myQue;
            return View("Index");
        }

        public ActionResult Clear_Queue() //empty the whole Q
        {
            if (myQue.Count !=0)
            {
                myQue.Clear();
                ViewBag.q = myQue;
                return View("Index");
            }
            else
            {
                return Index();
            }
        }
        public ActionResult Display_Queue() //show the entire Q on a different page
        {
            if (myQue.Count == 0)
            {
                return Index();
            }
            else
            {
                ViewBag.q = myQue;
                return View();
            }
        }

        

        [HttpGet]
        public ViewResult Search_queue()
        {
            return View(); 
        }

        //recieves the data in the search box
        [HttpPost]
        public ActionResult Search_queue(FormCollection find)
        {
            if (myQue.Count == 0)
            {
                return Index();
            }
            else
            {
                Stopwatch w = new Stopwatch(); //make a stop watch object

                w.Start();

                string s_st = find["srch"].ToString();
                for (int icount = 0; icount < myQue.Count; icount++) //look for item in queue in postion 10
                {
                    if (myQue.Peek() == s_st)
                    {
                        icount = myQue.Count;
                    }
                    else
                    {
                        myQue.Dequeue();
                    }

                }
            

            w.Stop();

            TimeSpan ts = w.Elapsed;

            ViewBag.StopWatch = ts;
            }
            ViewBag.q = myQue;
            return Index();

        }


    }
}