using Common;
using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Repository
{
    public class CabRepository
    {
        Dictionary<string, object> paramList = new Dictionary<string, object>();
        String spName = string.Empty;
        DBContext db = new DBContext();




        public List<CabBooking> getCurrentRoasterList(int profileID)
        {
            DataTable dt = new DataTable();
            List<CabBooking> entity = new List<CabBooking>();
            try
            {
                paramList.Clear();
                paramList["@ProfileID"] = profileID;
                spName = "spEM_GetCabBooking";
                dt.Load(db.ExecuteQuery(spName, true, Common.Enums.SQLConnectionNames.EMDB, paramList));
                entity = Utility.ConvertFromDataTable<CabBooking>(dt).ToList();
            }
            catch
            {
                throw;
            }


            return entity;
        }


        public CabBooking getRoasterData(int bookingID)
        {
            throw new NotImplementedException();
        }


        public void SaveRoaster(CabBooking cabBooking)
        {
            try
            {
                paramList.Clear();
                //       	@ int,@ProfileID int,@cabDate xml, @RoasterTypeID int, @ShiftStartTime Datetime, @ShiftEndTime Datetime,
                //@MonthID int, @YearID int
                paramList["@BookingID"] = cabBooking.BookingID;
                paramList["@ProfileID"] = cabBooking.ProfileID;
                paramList["@cabDate"] = cabBooking.cabDate;
                //paramList["@RoasterTypeID"] = cabBooking.RoasterTypeID;
                //paramList["@ShiftStartTime"] = cabBooking.ShiftStartTime;
                //paramList["@ShiftEndTime"] = cabBooking.ShiftEndTime;
                paramList["@MonthID"] = cabBooking.MonthID;
                paramList["@YearID"] = cabBooking.YearID;
                spName = "spEM_SaveRoaster";
                db.ExecuteNonQuery(spName, true, Common.Enums.SQLConnectionNames.EMDB, paramList);
            }
            catch
            {
                throw;
            }
        }


        public int getDefaultAddressID(int profileID)
        {
            DataTable dt = new DataTable();
            int AddressID = 0;
            try
            {
                paramList.Clear();
                paramList["@ProfileID"] = profileID;


                spName = "spEM_getDefaultAddressID";
                dt.Load(db.ExecuteQuery(spName, true, Common.Enums.SQLConnectionNames.EMDB, paramList));
                if (dt.Rows.Count > 0)
                {
                    AddressID = int.Parse(dt.Rows[0]["addressID"].ToString());
                }
            }
            catch
            {
                throw;
            }


            return AddressID;
        }


        public CabBooking getRoasterByMonthYear(int profileID, int month, int year)
        {
            DataTable dt = new DataTable();
            CabBooking entity = new CabBooking();
            try
            {
                paramList.Clear();
                paramList["@ProfileID"] = profileID;
                paramList["@month"] = month;
                paramList["@year"] = year;
                spName = "spEM_getRoasterByMonthYear";
                dt.Load(db.ExecuteQuery(spName, true, Common.Enums.SQLConnectionNames.EMDB, paramList));
                entity = Utility.ConvertFromDataTable<CabBooking>(dt).FirstOrDefault();
            }
            catch
            {
                throw;
            }


            return entity;
        }
    }

    public class EventRepository
    {


        Dictionary<string, object> paramList = new Dictionary<string, object>();
        String spName = string.Empty;
        DBContext db = new DBContext();




        public List<EventEntity> GetEvents()
        {
            DataTable dt = new DataTable();
            List<EventEntity> entity = new List<EventEntity>();
            try
            {
                spName = "spEM_GetEvents";
                dt.Load(db.ExecuteQuery(spName, true, Common.Enums.SQLConnectionNames.EMDB, null));
                if (dt.Rows.Count > 0)
                {
                    entity = Utility.ConvertFromDataTable<EventEntity>(dt);
                }
            }
            catch
            {
                throw;
            }


            return entity;
        }






        public void saveEvent(EventEntity eventEntity)
        {
            try
            {
                paramList.Clear();
                paramList["@EventID"] = eventEntity.EventID;
                paramList["@EventName"] = eventEntity.EventName;
                paramList["@EventDescription"] = eventEntity.EventDescription;
                paramList["@StartDate"] = eventEntity.StartDate;
                paramList["@EndDate"] = eventEntity.EndDate;
                paramList["@StartTime"] = eventEntity.StartTime;
                paramList["@EndTime"] = eventEntity.EndTime;
                paramList["@AlertText"] = eventEntity.AlertText;
                paramList["@Status"] = eventEntity.Status;
                spName = "spEM_InsertEvent";
                db.ExecuteNonQuery(spName, true, Common.Enums.SQLConnectionNames.EMDB, paramList);
            }
            catch
            {
                throw;
            }
        }


        public EventEntity getEvent(int eventID)
        {
            DataTable dt = new DataTable();
            EventEntity entity = new EventEntity();
            try
            {
                paramList.Clear();
                paramList["@eventID"] = eventID;
                spName = "spEM_GetEvent";
                dt.Load(db.ExecuteQuery(spName, true, Common.Enums.SQLConnectionNames.EMDB, paramList));
                if (dt.Rows.Count > 0)
                {
                    entity = Utility.ConvertFromDataTable<EventEntity>(dt).FirstOrDefault();
                }
            }
            catch
            {
                throw;
            }


            return entity;
        }
    }


    public class FoodRepository
    {
        Dictionary<string, object> paramList = new Dictionary<string, object>();
        String spName = string.Empty;
        DBContext db = new DBContext();


        public List<FoodEntity> getEntireFoodList(int locationID)
        {
            DataTable dt = new DataTable();
            List<FoodEntity> entity = new List<FoodEntity>();
            try
            {


                paramList.Clear();
                paramList["@locationID"] = locationID;
                spName = "spEM_getEntireFoodList";
                dt.Load(db.ExecuteQuery(spName, true, Common.Enums.SQLConnectionNames.EMDB, paramList));
                if (dt.Rows.Count > 0)
                {
                    entity = Utility.ConvertFromDataTable<FoodEntity>(dt);
                }
            }
            catch
            {
                throw;
            }


            return entity;
        }


        public List<FoodOrderEntity> getfoodOrderList(int profileID)
        {
            DataTable dt = new DataTable();
            List<FoodOrderEntity> entity = new List<FoodOrderEntity>();
            try
            {


                paramList.Clear();
                paramList["@profileID"] = profileID;
                spName = "spEM_GetFoodOrderListByProfileID";
                dt.Load(db.ExecuteQuery(spName, true, Common.Enums.SQLConnectionNames.EMDB, paramList));
                if (dt.Rows.Count > 0)
                {
                    entity = Utility.ConvertFromDataTable<FoodOrderEntity>(dt);
                }
            }
            catch
            {
                throw;
            }
            return entity;
        }


        public FoodOrderEntity getfoodOrderByID(int orderID)
        {
            DataTable dt = new DataTable();
            FoodOrderEntity entity = new FoodOrderEntity();
            try
            {


                paramList.Clear();
                paramList["@OrderID"] = orderID;
                spName = "spEM_GetFoodOrderByOrderID";
                dt.Load(db.ExecuteQuery(spName, true, Common.Enums.SQLConnectionNames.EMDB, paramList));
                if (dt.Rows.Count > 0)
                {
                    entity = Utility.ConvertFromDataTable<FoodOrderEntity>(dt).FirstOrDefault();
                }
            }
            catch
            {
                throw;
            }
            return entity;
        }


        public List<FoodCategoryEntity> getfoodCategoryList()
        {
            DataTable dt = new DataTable();
            List<FoodCategoryEntity> entity = new List<FoodCategoryEntity>();
            try
            {




                spName = "spEM_getfoodCategoryList";
                dt.Load(db.ExecuteQuery(spName, true, Common.Enums.SQLConnectionNames.EMDB, null));
                if (dt.Rows.Count > 0)
                {
                    entity = Utility.ConvertFromDataTable<FoodCategoryEntity>(dt);
                }
            }
            catch
            {
                throw;
            }


            return entity;
        }


        public void saveFoodMenu(List<FoodEntity> list)
        {
            foreach (FoodEntity e in list)
            {
                try
                {
                    paramList.Clear();
                    paramList["@FoodID"] = e.FoodID;
                    paramList["@active"] = e.Active;

                    spName = "spEM_updateFoodStatus";
                    db.ExecuteNonQuery(spName, true, Common.Enums.SQLConnectionNames.EMDB, paramList);
                }
                catch
                {
                    throw;
                }
            }
        }




        public void saveFoodOrder(FoodOrderEntity e)
        {
            try
            {
                paramList.Clear();
                paramList["@FoodID"] = e.FoodID;
                paramList["@BatchID"] = e.BatchID;
                paramList["@Quantity"] = e.Quantity;
                paramList["@RequiredAt"] = e.RequiredAt;
                paramList["@Price"] = e.Price;
                paramList["@ProfileID"] = e.ProfileID;
                paramList["@LastUpdatedBY"] = e.LastUpdatedBY;
                paramList["@TokenID"] = e.BatchID;
                paramList["@Status"] = e.Status;


                spName = "spEM_insertFoodOrder";
                db.ExecuteNonQuery(spName, true, Common.Enums.SQLConnectionNames.EMDB, paramList);
            }
            catch
            {
                throw;
            }
        }

        public void updateFoodOrder(FoodOrderEntity e)
        {
            try
            {
                paramList.Clear();
                paramList["@OrderID"] = e.OrderID;
                paramList["@Quantity"] = e.Quantity;
                paramList["@RequiredAt"] = e.RequiredAt;
                paramList["@LastUpdatedBY"] = e.LastUpdatedBY;
                paramList["@Status"] = e.Status;


                spName = "spEM_UpdateFoodOrder";
                db.ExecuteNonQuery(spName, true, Common.Enums.SQLConnectionNames.EMDB, paramList);
            }
            catch
            {
                throw;
            }
        }
        public int GetBatchID()
        {
            DataTable dt = new DataTable();
            int batchID = 1;
            try
            {
                spName = "spEM_getBatchID";
                dt.Load(db.ExecuteQuery(spName, true, Common.Enums.SQLConnectionNames.EMDB, null));
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["BatchID"] != null && dt.Rows[0]["BatchID"].ToString().Trim() != "")
                    {
                        batchID = int.Parse(dt.Rows[0]["BatchID"].ToString());
                    }
                }
            }
            catch
            {
                throw;
            }
            return batchID;
        }


        public void deleteFoodOrder(int orderID)
        {
            try
            {
                paramList.Clear();
                paramList["@orderID"] = orderID;



                spName = "spEM_DeleteFoodOrder";
                db.ExecuteNonQuery(spName, true, Common.Enums.SQLConnectionNames.EMDB, paramList);
            }
            catch
            {
                throw;
            }
        }


        public List<FoodOrderEntity> GetPendingFoodOrderList(int locationID)
        {
            DataTable dt = new DataTable();
            List<FoodOrderEntity> entity = new List<FoodOrderEntity>();
            try
            {


                paramList.Clear();
                paramList["@locationID"] = locationID;
                spName = "spEM_GetFoodOrderListByLocationID";
                dt.Load(db.ExecuteQuery(spName, true, Common.Enums.SQLConnectionNames.EMDB, paramList));
                if (dt.Rows.Count > 0)
                {
                    entity = Utility.ConvertFromDataTable<FoodOrderEntity>(dt);
                }
            }
            catch
            {
                throw;
            }
            return entity;
        }


        public void UpdateOrderStatus(int status, int orderID)
        {
            try
            {
                paramList.Clear();
                paramList["@orderID"] = orderID;
                spName = "spEM_UpdateOrderStatus";
                db.ExecuteNonQuery(spName, true, Common.Enums.SQLConnectionNames.EMDB, paramList);
            }
            catch
            {
                throw;
            }
        }
    }


    public class GuestHouseRepository
    {


        Dictionary<string, object> paramList = new Dictionary<string, object>();
        String spName = string.Empty;
        DBContext db = new DBContext();




        public List<GuestHouseEntity> GetGuestHouseList(int GuestHouseID)
        {
            DataTable dt = new DataTable();
            List<GuestHouseEntity> entity = new List<GuestHouseEntity>();
            try
            {


                paramList.Clear();
                paramList["@GuestHouseID"] = GuestHouseID;
                spName = "spEM_GetGuestHouseList";
                dt.Load(db.ExecuteQuery(spName, true, Common.Enums.SQLConnectionNames.EMDB, paramList));
                if (dt.Rows.Count > 0)
                {
                    entity = Utility.ConvertFromDataTable<GuestHouseEntity>(dt);
                }
            }
            catch
            {
                throw;
            }


            return entity;
        }


        public void saveGuestHouseBooking(GuestHouseBookingEntity guestHouseBookingEntity)
        {
            try
            {
                paramList.Clear();
                paramList["@BookingID"] = guestHouseBookingEntity.BookingID;
                paramList["@StepID"] = guestHouseBookingEntity.StepID;
                paramList["@ProfileID"] = guestHouseBookingEntity.ProfileID;
                paramList["@GouestHouseID"] = guestHouseBookingEntity.GuestHouseID;
                paramList["@BookingEndDate"] = guestHouseBookingEntity.BookingEndDate;
                paramList["@BookingStartDate"] = guestHouseBookingEntity.BookingStartDate;
                paramList["@numOfGuests"] = guestHouseBookingEntity.numOfGuests;
                paramList["@CreatedDate"] = guestHouseBookingEntity.CreatedDate;
                paramList["@LastUpdatesBy"] = guestHouseBookingEntity.LastUpdatesBy;
                paramList["@StatusID"] = guestHouseBookingEntity.StatusID;
                paramList["@TokenID"] = guestHouseBookingEntity.TokenID;
                spName = "spEM_SaveGuestHouseBooking";
                db.ExecuteNonQuery(spName, true, Common.Enums.SQLConnectionNames.EMDB, paramList);
            }
            catch
            {
                throw;
            }
        }


        public List<GuestHouseBookingEntity> GetCurrentGuestHouseBookingList(int profileID, int bookingID)
        {
            DataTable dt = new DataTable();
            List<GuestHouseBookingEntity> entity = new List<GuestHouseBookingEntity>();
            try
            {


                paramList.Clear();
                paramList["@ProfileID"] = profileID;
                paramList["@BookingID"] = bookingID;
                spName = "spEM_GetCurrentGuestHouseBookingList";
                dt.Load(db.ExecuteQuery(spName, true, Common.Enums.SQLConnectionNames.EMDB, paramList));
                if (dt.Rows.Count > 0)
                {
                    entity = Utility.ConvertFromDataTable<GuestHouseBookingEntity>(dt);
                }
            }
            catch
            {
                throw;
            }


            return entity;
        }


        public void UpdateGuestHouseBookingStatus(int bookingID, int status, string remarks)
        {
            try
            {
                paramList.Clear();
                paramList["@BookingID"] = bookingID;
                paramList["@StatusID"] = status;
                paramList["@remarks"] = remarks;
                spName = "spEM_UpdateGuestHouseBookingStatus";
                db.ExecuteNonQuery(spName, true, Common.Enums.SQLConnectionNames.EMDB, paramList);
            }
            catch
            {
                throw;
            }
        }


        public void DeleteGuestHouseBooking(int bookingID)
        {
            try
            {
                paramList.Clear();
                paramList["@BookingID"] = bookingID;


                spName = "spEM_DeleteGuestHouseBooking";
                db.ExecuteNonQuery(spName, true, Common.Enums.SQLConnectionNames.EMDB, paramList);
            }
            catch
            {
                throw;
            }
        }
    }

    public class ProfileRepository
    {


        Dictionary<string, object> paramList = new Dictionary<string, object>();
        String spName = string.Empty;
        DBContext db = new DBContext();



        public ProfileEntity GetProfileDetails(int profileID)
        {
            DataTable dt = new DataTable();
            ProfileEntity entity = new ProfileEntity();
            try
            {
                paramList.Clear();
                paramList["@ProfileID"] = profileID;


                spName = "spEM_GetProfile";
                dt.Load(db.ExecuteQuery(spName, true, Common.Enums.SQLConnectionNames.EMDB, paramList));
                entity = Utility.ConvertFromDataTable<ProfileEntity>(dt).FirstOrDefault();
            }
            catch
            {
                throw;
            }


            return entity;
        }


        public Address GetAddress(int addressID)
        {
            DataTable dt = new DataTable();
            Address entity = new Address();
            try
            {
                paramList.Clear();
                paramList["@addressID"] = addressID;


                spName = "spEM_GetAddress";
                dt.Load(db.ExecuteQuery(spName, true, Common.Enums.SQLConnectionNames.EMDB, paramList));
                entity = Utility.ConvertFromDataTable<Address>(dt).FirstOrDefault();
            }
            catch
            {
                throw;
            }


            return entity;
        }


        public AddressLists GetAddressLists(Address address)
        {
            DataSet ds = new DataSet();
            AddressLists lists = new AddressLists();
            try
            {
                paramList.Clear();
                paramList["@countryID"] = address.Country;
                paramList["@stateID"] = address.State;
                paramList["@cityID"] = address.City;
                spName = "spEM_GetAddressLists";
                ds = db.ExecuteQueryDataset(spName, true, Common.Enums.SQLConnectionNames.EMDB, paramList);
                lists.countries = Utility.ConvertFromDataTable<Country>(ds.Tables[0]);
                lists.states = Utility.ConvertFromDataTable<State>(ds.Tables[1]);
                lists.cities = Utility.ConvertFromDataTable<City>(ds.Tables[2]);
                lists.areas = Utility.ConvertFromDataTable<Areas>(ds.Tables[3]);
            }
            catch
            {
                throw;
            }


            return lists;
        }


        public int SaveAddress(Address address)
        {
            int returnValue;
            try
            {
                paramList.Clear();
                paramList["@AddressID"] = address.AddressID;
                paramList["@Line1"] = address.Line1;
                paramList["@Line2"] = address.Line2;
                paramList["@Area"] = address.Area;
                paramList["@City"] = address.City;
                paramList["@State"] = address.State;
                paramList["@Country"] = address.Country;
                paramList["@Pin"] = address.Pin;
                paramList["@Latitute"] = DBNull.Value;
                paramList["@Longitude"] = DBNull.Value;
                paramList["@AddressIDOutPut"] = null;
                spName = "spEM_SaveAddress";
                returnValue = db.ExecuteScalarWithOutputParam(spName, Common.Enums.SQLConnectionNames.EMDB, paramList);
            }
            catch
            {
                throw;
            }
            return returnValue;
        }


        public List<Branch> GetBranchList()
        {
            DataTable dt = new DataTable();
            List<Branch> entity = new List<Branch>();
            try
            {



                spName = "spEM_GetBranchList";
                dt.Load(db.ExecuteQuery(spName, true, Common.Enums.SQLConnectionNames.EMDB, null));
                entity = Utility.ConvertFromDataTable<Branch>(dt).ToList();
            }
            catch
            {
                throw;
            }


            return entity;
        }


        public void SaveProfile(ProfileEntity profileEntity, Address address1, Address address2)
        {
            int addressId1 = SaveAddress(address1);
            int addressId2 = SaveAddress(address2);
            try
            {
                paramList.Clear();
                paramList["@ProfileID"] = profileEntity.ProfileID;
                paramList["@FirstName"] = profileEntity.FirstName;
                paramList["@MiddleName"] = profileEntity.MiddleName;
                paramList["@LastName"] = profileEntity.LastName;
                paramList["@DOB"] = profileEntity.DOB;
                paramList["@EmpID"] = profileEntity.EmpID;
                paramList["@DepartmentID"] = profileEntity.DepartmentID == 0 ? (object)DBNull.Value : profileEntity.DepartmentID;
                paramList["@BranchID"] = profileEntity.BranchID == 0 ? (object)DBNull.Value : profileEntity.BranchID;
                paramList["@AddressID1"] = addressId1;
                paramList["@AddressID2"] = addressId2;
                paramList["@DefaultAddress"] = profileEntity.DefaultAddress;
                paramList["@Email"] = profileEntity.Email;
                paramList["@Phone"] = profileEntity.Phone;
                paramList["@roleID"] = profileEntity.roleID == 0 ? (object)DBNull.Value : profileEntity.roleID;
                paramList["@supervisorID"] = profileEntity.supervisorID == 0 ? (object)DBNull.Value : profileEntity.supervisorID;
                paramList["@locationID"] = profileEntity.locationID;
                paramList["@password"] = profileEntity.password;
                paramList["@CompanyID"] = profileEntity.CompanyID;
                paramList["@EmergencyName"] = profileEntity.EmergencyName;
                paramList["@EmergencyRelation"] = profileEntity.EmergencyRelation;
                paramList["@EmergencyPhone"] = profileEntity.EmergencyPhone;
                paramList["@EmergencyEmail"] = profileEntity.EmergencyEmail;

                spName = "spEM_SaveProfile";
                db.ExecuteNonQuery(spName, true, Common.Enums.SQLConnectionNames.EMDB, paramList);
            }
            catch
            {
                throw;
            }


        }


        public List<Location> GetLocationList()
        {
            DataTable dt = new DataTable();
            List<Location> entity = new List<Location>();
            try
            {
                spName = "spEM_getLocationList";
                dt.Load(db.ExecuteQuery(spName, true, Common.Enums.SQLConnectionNames.EMDB, null));
                entity = Utility.ConvertFromDataTable<Location>(dt).ToList();
            }
            catch
            {
                throw;
            }
            return entity;
        }


        public PanicEntity GetPanicData(int profileID)
        {
            DataTable dt = new DataTable();
            PanicEntity entity = new PanicEntity();
            try
            {
                paramList.Clear();
                paramList["@ProfileID"] = profileID;
                spName = "spEM_GetPanicDetails";
                dt.Load(db.ExecuteQuery(spName, true, Common.Enums.SQLConnectionNames.EMDB, paramList));
                entity = Utility.ConvertFromDataTable<PanicEntity>(dt).FirstOrDefault();
            }
            catch
            {
                throw;
            }
            return entity;
        }




        public void SavePanicData(PanicEntity panicEntity)
        {
            try
            {
                paramList.Clear();
                paramList["@ProfileID"] = panicEntity.ProfileID;
                paramList["@name"] = panicEntity.name;
                paramList["@phone"] = panicEntity.phone;
                paramList["@email"] = panicEntity.email;
                paramList["@text"] = panicEntity.text;

                spName = "spEM_SavePanic";
                db.ExecuteNonQuery(spName, true, Common.Enums.SQLConnectionNames.EMDB, paramList);
            }
            catch
            {
                throw;
            }
        }
    }

}

