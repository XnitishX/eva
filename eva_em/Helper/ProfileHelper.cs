using Entities;
using eva_em.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace eva_em.Helper
{
    public class ProfileHelper
    {
        static ProfileRepository repository = new ProfileRepository();
        internal static ProfileModel GetProfileData(int profileID)
        {
            ProfileModel mdl = new ProfileModel();
            mdl.profile = repository.GetProfileDetails(profileID);

            mdl.address1 = repository.GetAddress(mdl.profile.AddressID1);
            mdl.address2 = repository.GetAddress(mdl.profile.AddressID2);
            if (mdl.address1 == null) { mdl.address1 = new Address(); }
            if (mdl.address2 == null) { mdl.address2 = new Address(); }
            mdl.addressList1 = repository.GetAddressLists(mdl.address1);
            mdl.addressList2 = repository.GetAddressLists(mdl.address2);
            mdl.BranchList = repository.GetBranchList();
            mdl.LocationList = repository.GetLocationList();
            return mdl;
        }


        internal static void SaveProfileData(ProfileModel mdl)
        {
            //Address address1 = new Address();
            //Address address2 = new Address();
            //repository.SaveAddress(mdl.address1);
            //repository.SaveAddress(mdl.address2);
            repository.SaveProfile(mdl.profile, mdl.address1, mdl.address2);
        }


        internal static AddressLists GetAddressData(int countryID, int stateID, int cityID, int areaID)
        {
            Address adr = new Address();
            adr.Country = countryID;
            adr.State = stateID;
            adr.City = cityID;
            adr.Area = areaID;
            repository.GetAddressLists(adr);
            return repository.GetAddressLists(adr);
        }


        internal static List<State> getStateList(int Id)
        {
            Address adr = new Address();
            adr.Country = Id;
            adr.State = 0;
            adr.City = 0;
            adr.Area = 0;

            AddressLists lists = repository.GetAddressLists(adr);
            return lists.states;
        }


        internal static List<City> getCityList(int Id)
        {
            Address adr = new Address();
            adr.Country = 0;
            adr.State = Id;
            adr.City = 0;
            adr.Area = 0;


            AddressLists lists = repository.GetAddressLists(adr);
            return lists.cities;
        }


        internal static List<Areas> getAreaList(int Id)
        {
            Address adr = new Address();
            adr.Country = 0;
            adr.State = 0;
            adr.City = Id;
            adr.Area = 0;


            AddressLists lists = repository.GetAddressLists(adr);
            return lists.areas;
        }


        internal static PanicModel GetPanicData(int profileID)
        {
            PanicModel mdl = new PanicModel();

            mdl.panicDetails = repository.GetPanicData(profileID);
            if (mdl.panicDetails == null)
            {
                mdl.panicDetails = new PanicEntity();
            }
            mdl.panicDetails.ProfileID = profileID;
            return mdl;
        }


        internal static void SavePanicData(PanicModel mdl)
        {
            repository.SavePanicData(mdl.panicDetails);
        }
    }
}
