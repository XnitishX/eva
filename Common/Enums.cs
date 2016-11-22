using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Common
{
    public class Enums
    {
        public enum SQLConnectionNames
        {
            [Description("MasterConnectionString")]
            Master = 0,


            [Description("EMDBConnectionString")]
            EMDB = 1,
        }




        public enum GuestHouseStatus
        {
            Open = 1,
            Cancelled = 2,
            Approved = 3,
            Declined = 4
        }


        public enum FoodOrderStatus
        {
            Open = 5,
            Cancelled = 6,
            Accepted = 7,
            Rejected = 8,
            Completed = 9,
            Closed = 10
        }


        public enum EventsStatus
        {
            Scheduled = 11,
            Cancelled = 14,
            Ongoing = 12,
            Completed = 13
        }


    }
}
