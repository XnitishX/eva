using Common;
using Entities;
using eva_em.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
namespace eva_em.Helper
{

    public class CabHelper
    {
        static CabRepository repository = new CabRepository();




        internal static CabModel getRoasterData(int profileID, int bookingID)
        {
            CabModel mdl = new CabModel();
            mdl.roaster = repository.getRoasterData(bookingID);
            return mdl;
            //mdl.
        }


        internal static List<CabDate> getCurrentRoasterList(int profileID)
        {
            List<CabDate> currentRoasterList = new List<CabDate>();
            List<CabBooking> roasterList = new List<CabBooking>();
            roasterList = repository.getCurrentRoasterList(profileID);


            foreach (CabBooking c in roasterList)
            {
                currentRoasterList.AddRange(Utility.Deserialize<List<CabDate>>(c.cabDate));
            }
            return currentRoasterList;
        }


        internal static CabModel addRoaster(int profileID)
        {
            CabModel mdl = new CabModel();
            mdl.roaster = new CabBooking();
            mdl.roaster.ProfileID = profileID;
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
            return mdl;
        }


        internal static void saveRoaster(CabModel mdl)
        {
            CabBooking cabBooking = mdl.roaster;
            int addressID = repository.getDefaultAddressID(cabBooking.ProfileID);
            int locationID = 1;
            string[] selectedDates = cabBooking.selectedDatesString.Split(',');

            foreach (string date in selectedDates)
            {
                CabDate c = new CabDate();
                c.cabDate = DateTime.ParseExact(date, "MM/dd/yyyy", CultureInfo.InvariantCulture); //DateTime.Parse(date);
                c.AddressID = addressID;
                c.ShiftStartTime = cabBooking.ShiftStartTime;
                c.ShiftEndTime = cabBooking.ShiftEndTime;
                c.RoasterTypeID = cabBooking.RoasterTypeID;
                c.LocationID = locationID;
                CabBooking existingRoaster = repository.getRoasterByMonthYear(cabBooking.ProfileID, c.cabDate.Month, c.cabDate.Year);
                if (existingRoaster != null && existingRoaster.BookingID > 0)
                {
                    List<CabDate> existingCabDateList = new List<CabDate>();
                    existingCabDateList = Utility.Deserialize<List<CabDate>>(existingRoaster.cabDate);
                    CabDate duplicate = new CabDate();
                    duplicate = existingCabDateList.FirstOrDefault(m => m.cabDate == c.cabDate);
                    if (duplicate != null && duplicate.cabDate != DateTime.MinValue)
                    {
                        existingCabDateList.Remove(duplicate);
                    }

                    existingCabDateList.Add(c);
                    existingRoaster.cabDate = Utility.Serialize<List<CabDate>>(existingCabDateList);
                    repository.SaveRoaster(existingRoaster);
                }
                else
                {
                    List<CabDate> cabDateList = new List<CabDate>();
                    cabDateList.Add(c);
                    cabBooking.cabDate = Utility.Serialize<List<CabDate>>(cabDateList);
                    cabBooking.MonthID = c.cabDate.Month;
                    cabBooking.YearID = c.cabDate.Year;
                    repository.SaveRoaster(cabBooking);
                }


            }

        }
    }
}
