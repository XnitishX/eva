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
    public class FoodHelper
    {
        static FoodRepository repository = new FoodRepository();


        internal static FoodModel FoodMenuAdmin(int locationID, int profileID)
        {
            FoodModel mdl = new FoodModel();
            mdl.foodItemList = repository.getEntireFoodList(locationID);
            mdl.foodCategoryList = repository.getfoodCategoryList();
            mdl.locationID = locationID;
            mdl.profileID = profileID;
            return mdl;
        }


        internal static FoodModel viewFoodOrder(int locationID, int profileID)
        {
            FoodModel mdl = new FoodModel();
            mdl.foodOrderList = repository.getfoodOrderList(profileID);
            mdl.locationID = locationID;
            mdl.profileID = profileID;
            return mdl;
        }


        internal static void saveFoodMenu(FoodModel mdl)
        {
            repository.saveFoodMenu(mdl.foodItemList);
        }


        internal static FoodModel addFoodOrder(int locationID, int profileID)
        {
            FoodModel mdl = new FoodModel();
            mdl.foodItemList = repository.getEntireFoodList(locationID);
            mdl.foodCategoryList = repository.getfoodCategoryList();
            mdl.foodOrderList = new List<FoodOrderEntity>();
            mdl.profileID = profileID;
            mdl.locationID = locationID;
            foreach (FoodEntity e in mdl.foodItemList)
            {
                if (e.Active == true)
                {
                    FoodOrderEntity order = new FoodOrderEntity();
                    order.FoodID = e.FoodID;
                    order.FoodName = e.FoodName;
                    order.FoodCategoryID = e.FoodCategoryID;
                    order.Price = e.Price;
                    mdl.foodOrderList.Add(order);
                }
            }
            return mdl;


        }


        internal static void saveFoodOrder(FoodModel mdl)
        {
            int batchID = repository.GetBatchID();
            foreach (FoodOrderEntity e in mdl.foodOrderList)
            {
                if (e.Quantity > 0)
                {
                    e.RequiredAt = new DateTime(e.RequiredAt.Year, e.RequiredAt.Month, e.RequiredAt.Day, e.RequiredAtTime.Hour, e.RequiredAtTime.Minute, e.RequiredAtTime.Second);
                    e.LastUpdatedBY = mdl.profileID;
                    e.Status = (int)Enums.FoodOrderStatus.Open;
                    e.ProfileID = mdl.profileID;
                    e.BatchID = batchID.ToString();
                    repository.saveFoodOrder(e);
                }
            }
        }


        internal static FoodModel editFoodOrder(int orderID)
        {
            FoodModel mdl = new FoodModel();
            mdl.foodOrder = repository.getfoodOrderByID(orderID);
            mdl.foodOrder.RequiredAtTime = mdl.foodOrder.RequiredAt;
            mdl.foodCategoryList = repository.getfoodCategoryList();

            return mdl;
        }


        internal static void updateFoodOrder(FoodModel mdl)
        {
            FoodOrderEntity e = mdl.foodOrder;
            if (e.Quantity > 0)
            {
                e.RequiredAt = new DateTime(e.RequiredAt.Year, e.RequiredAt.Month, e.RequiredAt.Day, e.RequiredAtTime.Hour, e.RequiredAtTime.Minute, e.RequiredAtTime.Second);
                e.LastUpdatedBY = mdl.profileID;
                e.ProfileID = mdl.profileID;
                repository.updateFoodOrder(e);
            }

        }


        internal static void deleteFoodOrder(int orderID)
        {
            repository.deleteFoodOrder(orderID);
        }


        internal static FoodModel GetPendingFoodOrderList(int locationID)
        {
            FoodModel mdl = new FoodModel();
            mdl.foodOrderList = repository.GetPendingFoodOrderList(locationID);
            mdl.locationID = locationID;
            return mdl;
        }



    }
}
