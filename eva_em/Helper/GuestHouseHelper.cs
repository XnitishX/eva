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
    public class GuestHouseHelper
    {
        static GuestHouseRepository repository = new GuestHouseRepository();
        internal static GuestHouseModel viewGuestHouseBooking(int profileID)
        {
            GuestHouseModel mdl = new GuestHouseModel();
            mdl.currentGuestHouseBookingList = repository.GetCurrentGuestHouseBookingList(profileID, 0);
            return mdl;
        }


        internal static GuestHouseModel addGuestHouseBooking(int profileID, int bookingID)
        {
            GuestHouseModel mdl = new GuestHouseModel();
            mdl.GuestHouseList = repository.GetGuestHouseList(0);
            mdl.GuestHouseBooking = new GuestHouseBookingEntity();
            if (bookingID == 0)
            {
                mdl.GuestHouseBooking.BookingStartDate = DateTime.Now.AddDays(1);
                mdl.GuestHouseBooking.BookingEndDate = DateTime.Now.AddDays(2);
                mdl.GuestHouseBooking.LastUpdatesBy = 1; //from session
                mdl.GuestHouseBooking.StatusID = (int)Enums.GuestHouseStatus.Open;
                mdl.GuestHouseBooking.StepID = 1;
            }
            else
            {
                mdl.GuestHouseBooking = repository.GetCurrentGuestHouseBookingList(profileID, bookingID).FirstOrDefault();
            }

            mdl.GuestHouseBooking.ProfileID = profileID;
            return mdl;


        }


        internal static void saveGuestHouseBooking(GuestHouseModel mdl)
        {
            mdl.GuestHouseBooking.CreatedDate = DateTime.Now;
            Random random = new Random();
            mdl.GuestHouseBooking.TokenID = random.Next(1000, 10000).ToString();
            repository.saveGuestHouseBooking(mdl.GuestHouseBooking);
        }


        internal static void UpdateGuestHouseBookingStatus(int bookingID, int status, string remarks)
        {
            repository.UpdateGuestHouseBookingStatus(bookingID, status, remarks);
        }


        internal static void DeleteGuestHouseBooking(int bookingID)
        {
            repository.DeleteGuestHouseBooking(bookingID);
        }
    }
}
