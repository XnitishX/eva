using Common;
using eva_em.Helper;
using eva_em.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace eva_em.Controllers
{
    public class GuestHouseController : Controller
    {
        // GET: GuestHouse
        public ActionResult viewGuestHouseBooking(int profileID)
        {
            GuestHouseModel mdl = new GuestHouseModel();
            mdl = GuestHouseHelper.viewGuestHouseBooking(profileID);
            return View("viewGuestHouseBooking", mdl);
        }
        public ActionResult addGuestHouseBooking(int profileID)
        {
            GuestHouseModel mdl = new GuestHouseModel();
            mdl = GuestHouseHelper.addGuestHouseBooking(profileID, 0);
            return View("addGuestHouseBooking", mdl);
        }
        public ActionResult editGuestHouseBooking(int profileID, int bookingID)
        {
            GuestHouseModel mdl = new GuestHouseModel();
            mdl = GuestHouseHelper.addGuestHouseBooking(profileID, bookingID);
            return View("addGuestHouseBooking", mdl);
        }


        public ActionResult saveGuestHouseBooking(GuestHouseModel mdl)
        {
            GuestHouseHelper.saveGuestHouseBooking(mdl);
            return RedirectToAction("viewGuestHouseBooking", new { profileID = mdl.GuestHouseBooking.ProfileID });
        }


        public ActionResult ApproveGuestHouseBooking(int bookingID, int profileID, string remarks)
        {
            GuestHouseHelper.UpdateGuestHouseBookingStatus(bookingID, (int)Enums.GuestHouseStatus.Approved, remarks);
            return RedirectToAction("viewGuestHouseBooking", new { profileID = profileID });
        }
        public ActionResult RejectGuestHouseBooking(int bookingID, int profileID, string remarks)
        {
            GuestHouseHelper.UpdateGuestHouseBookingStatus(bookingID, (int)Enums.GuestHouseStatus.Declined, remarks);
            return RedirectToAction("viewGuestHouseBooking", new { profileID = profileID });
        }
        public ActionResult DeleteGuestHouseBooking(int bookingID, int profileID)
        {
            GuestHouseHelper.DeleteGuestHouseBooking(bookingID);
            return RedirectToAction("viewGuestHouseBooking", new { profileID = profileID });
        }


    }
}
