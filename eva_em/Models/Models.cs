using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eva_em.Models
{
    public class CabModel
    {
        public int profileID { get; set; }
        public CabBooking roaster { get; set; }
        public List<DateTime> selectedDates { get; set; }
        public List<KeyValuePair<string, string>> startTimeList { get; set; }
        public List<KeyValuePair<string, string>> endTimeList { get; set; }
        public List<CabDate> currentRoasterList { get; set; }
    }
    public class EventModel
    {
        public EventEntity evnt { get; set; }
        public List<EventEntity> evntList { get; set; }
        public bool isAdmin { get; set; }
    }
    public class FoodModel
    {
        public List<FoodEntity> foodItemList { get; set; }
        public FoodOrderEntity foodOrder { get; set; }
        public List<FoodCategoryEntity> foodCategoryList { get; set; }
        public List<FoodOrderEntity> foodOrderList { get; set; }
        public int locationID { get; set; }
        public int profileID { get; set; }
        public bool isAdmin { get; set; }
    }
    public class GuestHouseModel
    {
        public List<GuestHouseBookingEntity> currentGuestHouseBookingList { get; set; }
        public GuestHouseBookingEntity GuestHouseBooking { get; set; }
        public List<GuestHouseEntity> GuestHouseList { get; set; }
        public bool isAdmin { get; set; }
    }
    public class ProfileModel
    {
        public ProfileEntity profile { get; set; }
        public Address address1 { get; set; }
        public Address address2 { get; set; }
        public AddressLists addressList1 { get; set; }
        public AddressLists addressList2 { get; set; }
        public List<Branch> BranchList { get; set; }
        public List<Location> LocationList { get; set; }
    }


    public class PanicModel
    {
        public PanicEntity panicDetails { get; set; }
    }

}