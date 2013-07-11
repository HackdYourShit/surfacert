using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Profile;
using System.Web.Security;

namespace MVCSurfaceRTStore.Models
{
    public class StoreProfile : ProfileBase
    {
        public virtual string FirstName
        {
            get { return (string)base["FirstName"]; }
            set { base["FirstName"] = value; }
        }

        public virtual string LastName
        {
            get { return (string)base["LastName"]; }
            set { base["LastName"] = value; }
        }

        public virtual string Email
        {
            get { return (string)base["Email"]; }
            set { base["Email"] = value; }
        }

        public virtual string AddressStreet
        {
            get { return (string)base["AddressStreet"]; }
            set { base["AddressStreet"] = value; }
        }

        public virtual string AddressHouse
        {
            get { return (string)base["AddressHouse"]; }
            set { base["AddressHouse"] = value; }
        }

        public virtual string AddressZip
        {
            get { return (string)base["AddressZip"]; }
            set { base["AddressZip"] = value; }
        }

        public virtual string AddressTown
        {
            get { return (string)base["AddressTown"]; }
            set { base["AddressTown"] = value; }
        }

        public virtual string Phonenumber
        {
            get { return (string)base["Phonenumber"]; }
            set { base["Phonenumber"] = value; }
        }

        public static StoreProfile GetProfile(string username)
        {
            return Create(username) as StoreProfile;
        }

        public static StoreProfile GetProfile()
        {
            var re = Membership.GetUser();
            if (re != null) return Create(re.UserName) as StoreProfile;
            return null;
        }
    }
}