using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_sandbox
{
    public class USNationalParksAPIResponseBody
    {
    }

    public class USNationalParksAPIResponseBodyActivity
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class USNationalParksAPIResponseBodyAddress
    {
        public string line1 { get; set; }
        public string line2 { get; set; }
        public string line3 { get; set; }
        public string city { get; set; }
        public string stateCode { get; set; }
        public string countryCode { get; set; }
        public string provinceTerritoryCode { get; set; }
        public string postalCode { get; set; }
        public string type { get; set; }
    }

    public class USNationalParksAPIResponseBodyContact
    {
        public List<USNationalParksAPIResponseBodyPhoneNumber> phoneNumbers { get; set; }
        public List<USNationalParksAPIResponseBodyEmailAddress> emailAddresses { get; set; }
    }

    public class USNationalParksAPIResponseBodyDatum
    {
        public List<USNationalParksAPIResponseBodyActivity> activities { get; set; }
        public List<USNationalParksAPIResponseBodyAddress> addresses { get; set; }
        public List<USNationalParksAPIResponseBodyContact> contacts { get; set; }
        public string description { get; set; }
        public string designation { get; set; }
        public string directionsInfo { get; set; }
        public string directionsUrl { get; set; }
        public List<USNationalParksAPIResponseBodyEntranceFee> entranceFees { get; set; }
        public List<USNationalParksAPIResponseBodyEntrancePass> entrancePasses { get; set; }
        public string fullName { get; set; }
        public string id { get; set; }
        public List<USNationalParksAPIResponseBodyImage> images { get; set; }
        public string latLong { get; set; }
        public string name { get; set; }
        public List<USNationalParksAPIResponseBodyOperatingHour> operatingHours { get; set; }
        public string parkCode { get; set; }
        public int relevanceScore { get; set; }
        public string states { get; set; }
        public List<USNationalParksAPIResponseBodyTopic> topics { get; set; }
        public string url { get; set; }
        public string weatherInfo { get; set; }
    }

    public class USNationalParksAPIResponseBodyEmailAddress
    {
        public string emailAddress { get; set; }
        public string description { get; set; }
    }

    public class USNationalParksAPIResponseBodyEntranceFee
    {
        public int cost { get; set; }
        public string description { get; set; }
        public string title { get; set; }
    }

    public class USNationalParksAPIResponseBodyEntrancePass
    {
        public int cost { get; set; }
        public string description { get; set; }
        public string title { get; set; }
    }

    public class USNationalParksAPIResponseBodyException
    {
        public string name { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public List<USNationalParksAPIResponseBodyExceptionHour> exceptionHours { get; set; }
    }

    public class USNationalParksAPIResponseBodyExceptionHour
    {
        public string sunday { get; set; }
        public string monday { get; set; }
        public string tuesday { get; set; }
        public string wednesday { get; set; }
        public string thursday { get; set; }
        public string friday { get; set; }
        public string saturday { get; set; }
    }

    public class USNationalParksAPIResponseBodyImage
    {
        public string credit { get; set; }
        public string altText { get; set; }
        public string title { get; set; }
        public int id { get; set; }
        public string caption { get; set; }
        public string url { get; set; }
    }

    public class USNationalParksAPIResponseBodyOperatingHour
    {
        public string name { get; set; }
        public string description { get; set; }
        public List<StandardHour> standardHours { get; set; }
        public List<Exception> exceptions { get; set; }
    }

    public class USNationalParksAPIResponseBodyPhoneNumber
    {
        public string phoneNumber { get; set; }
        public string description { get; set; }
        public string extension { get; set; }
        public string type { get; set; }
    }

    public class USNationalParksAPIResponseBodyRoot
    {
        public string total { get; set; }
        public List<USNationalParksAPIResponseBodyDatum> data { get; set; }
        public string limit { get; set; }
        public string start { get; set; }
    }

    public class StandardHour
    {
        public string sunday { get; set; }
        public string monday { get; set; }
        public string tuesday { get; set; }
        public string wednesday { get; set; }
        public string thursday { get; set; }
        public string friday { get; set; }
        public string saturday { get; set; }
    }

    public class USNationalParksAPIResponseBodyTopic
    {
        public string id { get; set; }
        public string name { get; set; }
    }
}