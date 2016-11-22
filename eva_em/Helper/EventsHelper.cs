using Entities;
using eva_em.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common;
namespace eva_em.Helper
{
    public class EventHelper
    {
        static EventRepository repository = new EventRepository();




        internal static EventModel getEvents()
        {
            EventModel mdl = new EventModel();
            mdl.evntList = repository.GetEvents();
            return mdl;
        }


        internal static void saveEvent(EventModel mdl)
        {
            mdl.evnt.Status = (int)Enums.EventsStatus.Scheduled;
            repository.saveEvent(mdl.evnt);
        }

        internal static EventEntity getEvent(int eventID)
        {
            return repository.getEvent(eventID);
        }
    }
}