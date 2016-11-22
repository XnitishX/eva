using eva_em.Helper;
using eva_em.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace eva_em.Controllers
{
    public class FoodController : Controller
    {
        // GET: Food
        public ActionResult FoodMenuAdmin(int locationID, int profileID)
        {
            FoodModel mdl = new FoodModel();
            mdl = FoodHelper.FoodMenuAdmin(locationID, profileID);
            return View("FoodMenuAdmin", mdl);
        }


        public ActionResult viewFoodOrder(int locationID, int profileID)
        {
            FoodModel mdl = new FoodModel();
            mdl = FoodHelper.viewFoodOrder(locationID, profileID);
            return View("viewFoodOrder", mdl);
        }
        public ActionResult saveFoodMenu(FoodModel mdl)
        {
            FoodHelper.saveFoodMenu(mdl);
            return RedirectToAction("viewFoodOrder", new { locationID = mdl.locationID, profileID = mdl.profileID });
        }


        public ActionResult editFoodOrder(int OrderID, int profileID, bool isAdmin)
        {
            FoodModel mdl = new FoodModel();
            mdl = FoodHelper.editFoodOrder(OrderID);
            mdl.profileID = profileID;
            mdl.isAdmin = isAdmin;
            return View("editFoodOrder", mdl);
        }
        public ActionResult addFoodOrder(int locationID, int profileID)
        {
            FoodModel mdl = new FoodModel();
            mdl = FoodHelper.addFoodOrder(locationID, profileID);
            return View("addFoodOrder", mdl);
        }


        public ActionResult saveFoodOrder(FoodModel mdl)
        {
            FoodHelper.saveFoodOrder(mdl);
            return RedirectToAction("viewFoodOrder", new { locationID = mdl.locationID, profileID = mdl.profileID });
        }


        public ActionResult updateFoodOrder(FoodModel mdl, string Save, string Cancel, string Completed, string Reject)
        {

            if (!string.IsNullOrEmpty(Save))
            {
                FoodHelper.updateFoodOrder(mdl);
                mdl.foodOrder.Status = (int)Common.Enums.FoodOrderStatus.Open;
            }
            if (!string.IsNullOrEmpty(Cancel))
            {
                FoodHelper.deleteFoodOrder(mdl.foodOrder.OrderID);
            }
            if (!string.IsNullOrEmpty(Completed))
            {
                mdl.foodOrder.Status = (int)Common.Enums.FoodOrderStatus.Completed;


                FoodHelper.updateFoodOrder(mdl);
            }
            if (!string.IsNullOrEmpty(Reject))
            {
                mdl.foodOrder.Status = (int)Common.Enums.FoodOrderStatus.Rejected;


                FoodHelper.updateFoodOrder(mdl);
            }


            return RedirectToAction("viewFoodOrder", new { locationID = mdl.locationID, profileID = mdl.profileID });
        }


        public ActionResult processFoodOrder(int locationID, int profileID)
        {
            FoodModel mdl = new FoodModel();
            mdl = FoodHelper.GetPendingFoodOrderList(locationID);
            mdl.profileID = profileID;
            return View("processFoodOrder", mdl);
        }
    }
}
