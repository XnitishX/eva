using Entities;
using eva_em.Helper;
using eva_em.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace eva_em.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        public ActionResult GetData(int profileID)
        {
            ProfileModel mdl = ProfileHelper.GetProfileData(profileID);
            return View("Profile", mdl);
        }


        public ActionResult SaveProfile(ProfileModel mdl)
        {
            ProfileHelper.SaveProfileData(mdl);
            return RedirectToAction("Index", "Home");
        }


        public ActionResult GetAddress(ProfileModel mdl)
        {
            mdl.addressList1 = ProfileHelper.GetAddressData(mdl.address1.Country, mdl.address1.State, mdl.address1.City, mdl.address1.Area);
            mdl.addressList2 = ProfileHelper.GetAddressData(mdl.address2.Country, mdl.address2.State, mdl.address2.City, mdl.address2.Area);
            return View("_Address", mdl.address1);
        }


        public JsonResult StateList(int Id)
        {


            List<State> state = new List<State>();
            state = ProfileHelper.getStateList(Id);


            return Json(new SelectList(state.ToArray(), "StateId", "StateName"), JsonRequestBehavior.AllowGet);


        }


        public JsonResult CityList(int Id)
        {


            List<City> City = new List<City>();
            City = ProfileHelper.getCityList(Id);


            return Json(new SelectList(City.ToArray(), "CityId", "CityName"), JsonRequestBehavior.AllowGet);


        }


        public JsonResult AreaList(int Id)
        {


            List<Areas> Area = new List<Areas>();
            Area = ProfileHelper.getAreaList(Id);


            return Json(new SelectList(Area.ToArray(), "AreaId", "AreaName"), JsonRequestBehavior.AllowGet);


        }




        public ActionResult Panic(int profileID)
        {
            PanicModel mdl = ProfileHelper.GetPanicData(profileID);
            return View("Panic", mdl);
        }



        public ActionResult SavePanic(PanicModel mdl, string Alert, string Save)
        {


            if (!string.IsNullOrEmpty(Save))
            {
                ProfileHelper.SavePanicData(mdl);


            }
            if (!string.IsNullOrEmpty(Alert))
            {
                // send alert
            }


            return View("Panic", mdl);
        }
        //public JsonResult Citylist(int id)
        //{


        //	var city = from c in db.Citys


        //           	where c.StateId == id


        //           	select c;


        //	return Json(new SelectList(city.ToArray(), "CityId", "CityName"), JsonRequestBehavior.AllowGet);


        //}


        //public JsonResult Arealist(int id)
        //{


        //	var city = from c in db.Citys


        //           	where c.StateId == id


        //           	select c;


        //	return Json(new SelectList(city.ToArray(), "CityId", "CityName"), JsonRequestBehavior.AllowGet);


        //}
        //public ActionResult GetAddress()
        //{
        //	AddressModel mdl = ProfileHelper.GetAddressData(2, 1, 1, 1);
        //	return View("_Address", mdl);
        //}
    }
}
