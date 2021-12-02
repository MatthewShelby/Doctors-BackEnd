using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Doctors
{

    #region ===== SERDUCT =====

    public class Serduct
    {
        [Key]
        [Required]
        public string id { get; set; }

        [Required]
        public string owner { get; set; }

        [Required]
        public SerductType serductType { get; set; }


        public string title { get; set; }
        public string category { get; set; }
        public string subCategory { get; set; }
        public string shortDescription { get; set; }
        public string longDescription { get; set; }
        public List<SerductImage> images { get; set; }

    }

    public enum SerductType
    {
        Service,
        Product,
    }


    #endregion



    #region  ===== COMPANY =====

    public class Company
    {

        [Key]
        [Required]
        public string id { get; set; }

        [Required]
        public string owner { get; set; }

        [Required]
        public string companyName { get; set; }

        [Required]
        public List<ContactInfo> companyContactInfo { get; set; }




        public string companyTitle;
        public string companyShortBio { get; set; }
        public string companyLongBio { get; set; }
        public SerductImage profileImage { get; set; }
        public SerductImage logoImage { get; set; }
        public List<Serduct> companySerducts { get; set; }
    }

    public class ContactInfo
    {
        [Key]
        [Required]
        public string id { get; set; }
        public ContactInfoType type { get; set; }
        public string value { get; set; }

    }



    public enum ContactInfoType
    {
        country,
        city,
        address,
        phoneNumber,
        cellNumber,
        email,
        website,
        socialNetwork
    }

    #endregion






    #region ===== IMAGE =====


    public class SerductImage
    {

        [Key]
        [Required]
        public string id { get; set; }

        [Required]
        public ImageType imageType { get; set; }

        [Required]
        public string address { get; set; }

        [Required]
        public string altText { get; set; }

    }

    public enum ImageType
    {
        smaillThumbnail,       // 50*50
        largehumbnail,         // 75*75
        card,                  // 255*255  -  220 * 280 would be great
        catalog,               // 640*640
        cover,                 // 400*1400
        full,                  // 700*1400
    }


    #endregion

}
