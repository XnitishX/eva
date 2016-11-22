using eva_em.Helper;
using eva_em.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eva_em.Controllers
{
    public class CabController : Controller
	{
    	// GET: Cab
    	public ActionResult viewRoaster(int profileID)
    	{
        	CabModel mdl = new CabModel();
        	mdl.currentRoasterList = CabHelper.getCurrentRoasterList(profileID);
        	return View("viewRoaster", mdl);
    	}


    	public ActionResult addRoaster(int profileID)
    	{
        	CabModel mdl = new CabModel();
        	mdl = CabHelper.addRoaster(profileID);
        	return View("addRoaster",mdl);
    	}


    	public ActionResult editRoaster(int profileID,int RoasterTypeID, int LocationID ,DateTime cabDate,int AddressID,string ShiftStartTime,string ShiftEndTime)
    	{
        	CabModel mdl = new CabModel();
        	mdl.roaster = new Entities.CabBooking();
        	mdl.roaster.ProfileID = profileID;


        	mdl.roaster.RoasterTypeID = RoasterTypeID;


        	mdl.roaster.selectedDatesString = cabDate.ToString("MM/dd/yyyy");


        	mdl.roaster.ShiftStartTime = ShiftStartTime;
        	mdl.roaster.ShiftEndTime = ShiftEndTime;
        	mdl.selectedDates = new List<DateTime>();
        	List<KeyValuePair<string, string>> start = new List<KeyValuePair<string, string>>()
        	{
           	 
            	new KeyValuePair<string, string>("9:00 AM", "9:00 AM"),
            	new KeyValuePair<string, string>("10:00 AM", "10:00 AM"),
            	new KeyValuePair<string, string>("11:00 AM", "11:00 AM"),
        	};
        	List<KeyValuePair<string, string>> end = new List<KeyValuePair<string, string>>()
        	{
            	new KeyValuePair<string, string>("5:00 PM", "5:00 PM"),
            	new KeyValuePair<string, string>("6:00 PM", "6:00 PM"),
            	new KeyValuePair<string, string>("7:00 PM", "7:00 PM"),
        	};
        	mdl.startTimeList = start;
        	mdl.endTimeList = end;
        	return View("editRoaster", mdl);
    	}


    	public ActionResult saveRoaster(CabModel mdl)
    	{
        	CabHelper.saveRoaster(mdl);
        	return RedirectToAction("viewRoaster", new { profileID = mdl.roaster.ProfileID });
    	}
	}
}


