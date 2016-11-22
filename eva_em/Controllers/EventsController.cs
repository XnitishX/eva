using eva_em.Helper;
using eva_em.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace eva_em.Controllers
{
    public class EventsController : Controller
    {
        // GET: Events
        public ActionResult EventList()
        {
            EventModel mdl = new EventModel();
            mdl = EventHelper.getEvents();
            return View("EventList", mdl);
        }


        public ActionResult AddEvent()
        {
            EventModel mdl = new EventModel();
            mdl.isAdmin = false; //get from user session
            return View("AddEvent", mdl);
        }


        public ActionResult editEvent(int eventID)
        {
            EventModel mdl = new EventModel();
            mdl.isAdmin = false; //get from user session
            mdl.evnt = EventHelper.getEvent(eventID);
            return View("AddEvent", mdl);
        }




        public ActionResult saveEvent(EventModel mdl, string Alert, string Save)
        {


            if (!string.IsNullOrEmpty(Save))
            {
                EventHelper.saveEvent(mdl);


            }
            if (!string.IsNullOrEmpty(Alert))
            {
                // send alert
            }

            return RedirectToAction("EventList");
        }


    }
}
