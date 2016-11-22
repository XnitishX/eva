using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entities
{
    public class CabBooking
    {
        public int BookingID { get; set; }
        public int ProfileID { get; set; }
        public string cabDate { get; set; }
        public int RoasterTypeID { get; set; }
        public string ShiftStartTime { get; set; }
        public string ShiftEndTime { get; set; }
        public int MonthID { get; set; }
        public int YearID { get; set; }
        public string selectedDatesString { get; set; }
    }
    public class RoasterType
    {
        public int RoasterTypeID { get; set; }
        public string RoasterTypeName { get; set; }
    }


    public class CabDate
    {
        public DateTime cabDate { get; set; }
        public int AddressID { get; set; }
        public string ShiftStartTime { get; set; }
        public string ShiftEndTime { get; set; }
        public int RoasterTypeID { get; set; }
        public int LocationID { get; set; }
    }


    //common
    public class EM_Status
    {
        public int StatusID { get; set; }
        public string StatusName { get; set; }
    }

    //event

    public class EventEntity
    {
        public int EventID { get; set; }
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public System.TimeSpan StartTime { get; set; }
        public System.TimeSpan EndTime { get; set; }
        public string AlertText { get; set; }
        public int Status { get; set; }
    }

    public class FoodEntity
    {
        public int FoodID { get; set; }
        public string FoodName { get; set; }
        public int FoodCategoryID { get; set; }
        public string FoodCategoryName { get; set; }
        public bool Veg { get; set; }
        public System.TimeSpan StartTime { get; set; }
        public System.TimeSpan EndTime { get; set; }
        public bool Active { get; set; }
        public int LocationID { get; set; }
        public int PreparationTime { get; set; }
        public double Price { get; set; }
    }


    public partial class FoodCategoryEntity
    {
        public int FoodCategoryID { get; set; }
        public string FoodCategoryName { get; set; }
    }


    public partial class FoodOrderEntity
    {
        public int OrderID { get; set; }
        public string BatchID { get; set; }
        public int FoodID { get; set; }
        public string FoodName { get; set; }
        public int FoodCategoryID { get; set; }
        public string FoodCategoryName { get; set; }
        public int Quantity { get; set; }
        public System.DateTime RequiredAt { get; set; }
        public System.DateTime RequiredAtTime { get; set; }
        public double Price { get; set; }
        public int ProfileID { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public int LastUpdatedBY { get; set; }
        public System.DateTime LastUpdatedAt { get; set; }
        public string TokenID { get; set; }
        public int Status { get; set; }
    }


    public class GuestHouseEntity
    {
        public int GuestHouseID { get; set; }
        public string GuestHouseName { get; set; }
        public Address Address { get; set; }
    }


    public class GuestHouseBookingEntity
    {
        public int BookingID { get; set; }
        public int StepID { get; set; }
        public int ProfileID { get; set; }
        public int GuestHouseID { get; set; }
        public string GuestHouseName { get; set; }


        public DateTime BookingStartDate { get; set; }


        public DateTime BookingEndDate { get; set; }


        public int numOfGuests { get; set; }
        public DateTime CreatedDate { get; set; }
        public int LastUpdatesBy { get; set; }
        public int StatusID { get; set; }
        public string StatusName { get; set; }
        public string TokenID { get; set; }
        public string Remarks { get; set; }

    }

    public class ProfileEntity
    {
        public int ProfileID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public System.DateTime DOB { get; set; }
        public string EmpID { get; set; }
        public int DepartmentID { get; set; }
        public int BranchID { get; set; }
        public int AddressID1 { get; set; }
        public int AddressID2 { get; set; }
        public int DefaultAddress { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int roleID { get; set; }
        public int supervisorID { get; set; }
        public int locationID { get; set; }
        public string password { get; set; }
        public int CompanyID { get; set; }
        public string roleName { get; set; }
        public string BranchName { get; set; }
        public string locationName { get; set; }
        public string DepartmentName { get; set; }
        public string EmergencyName { get; set; }
        public string EmergencyRelation { get; set; }
        public string EmergencyPhone { get; set; }
        public string EmergencyEmail { get; set; }
        public int AddressID { get; set; }
    }


    public class Address
    {
        public int AddressID { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public int Area { get; set; }
        public int City { get; set; }
        public int State { get; set; }
        public int Country { get; set; }
        public string Pin { get; set; }
    }


    public class Branch
    {
        public int BranchID { get; set; }
        public string BranchName { get; set; }
    }


    public class Company
    {
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public string CompanyDesc { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int AddressID1 { get; set; }
        public int AddressID2 { get; set; }
        public byte[] Logo { get; set; }
    }


    public class Deparment
    {
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
    }


    public class Location
    {
        public int locationID { get; set; }
        public string locationName { get; set; }
        public int AddressID { get; set; }
    }


    public class Roles
    {
        public int roleID { get; set; }
        public string roleName { get; set; }
    }



    public class Areas
    {
        public int AreaID { get; set; }
        public string AreaName { get; set; }
    }
    public class City
    {
        public int CityID { get; set; }
        public string CityName { get; set; }
    }




    public class State
    {
        public int StateID { get; set; }
        public string StateName { get; set; }
    }


    public class Country
    {
        public int CountryID { get; set; }
        public string CountryName { get; set; }
    }


    public class AddressLists
    {
        public List<Areas> areas { get; set; }
        public List<City> cities { get; set; }
        public List<State> states { get; set; }
        public List<Country> countries { get; set; }
    }


    public class PanicEntity
    {
        public int ProfileID { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string text { get; set; }
    }

}
