using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMenus.Controllers
{
    //This is the Stack Controller
    public class StackController : Controller
    {
        //Declare Variables
        static Stack<string> myStack = new Stack<string>();
        static Stack<string> dStack = new Stack<string>();
        static Stack<string> checkStack = new Stack<string>();
        static string searchValue;
        static int iCount = 0;
        string sFound;



        // GET: Stack
        public ActionResult Index()
        {
            ViewBag.MyStack = myStack;

            return View();
        }

        public ActionResult AddOne()
        {
            dStack.Push("New Entry " + (dStack.Count + 1));

            ViewBag.MyStack = myStack;

            return View("Index");
        }

        public ActionResult HugeList()
        {
            //Clear all the values
            dStack.Clear();

            for (int iCount = 0; iCount <2000; iCount++)
            {
                dStack.Push("New Entry " + (dStack.Count + 1));
            }

            ViewBag.MyStack = myStack;

            return View("Index");
        }

        public ActionResult Display()
        {

            ViewBag.MyStack = dStack;

            return View("Index");
        }

        public ActionResult Delete()
        {

            if(dStack.Count != 0)
            {
                dStack.Pop();
                ViewBag.MyStack = myStack;

                return View("Index");
            }
            else
            {
                //display error message
                ViewBag.Error = "ERROR - Unable to delete - Stack is empty";
                return View("Error");
            }

           
        }

        public ActionResult Clear()
        {
            dStack.Clear();

            ViewBag.MyStack = myStack;

            return View("Index");
        }

        public ActionResult Search()
        {

            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

            sw.Start();

            searchValue = ("New Entry 3");

            while (iCount < dStack.Count + 1)
            {
                if (dStack.Contains(searchValue))
                {
                    //This is if it is in the stack 

                    sFound = "was found";

                    break;
                }
                else
                {
                    //This is if it is false
                    sFound = "was not found";
                }

                if(checkStack.Count != 0)
                {
                    checkStack.Push(dStack.Pop());

                }
                else
                {
                    ViewBag.Error = "ERROR - Stack is empty";
                    return View("Error");
                }
                

                iCount++;
            }

            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            ViewBag.Search = (searchValue + " " + sFound + " Search Time = " + ts);

            return View("Index");
        }

        public ActionResult Return()
        {

            return RedirectToAction("Index", "Home");
        }
    }
}