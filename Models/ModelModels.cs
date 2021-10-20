using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace carouselCore.Models
{
    public class userData
    {
        public string userid { get; set; }
    }

    public class userModels
    {
        [Required]
        public string newid { get; set; }
        [Required]
        public string status { get; set; }
    }

    public class loginData
    {
        public string userid { get; set; }
        public string password { get; set; }
        public string longitude { get; set; }
        public string latitude { get; set; }
        public string browser { get; set; }
    }

    public class loginModels
    {
        [Required]
        public string newid { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string allname { get; set; }
        [Required]
        public string status { get; set; }
    }

    public class otherData
    {
        public string userid { get; set; }
        public string values { get; set; }
    }

    public class signupData
    {
        public string userid { get; set; }
        public string password { get; set; }
        public string username { get; set; }
        public string birthday { get; set; }
        public string email { get; set; }
    }

    public class itemModels
    {
        [Required]
        public bool itemShow { get; set; }
        [Required]
        public List<object[]> items { get; set; }
    }

    public class iIconData
    {
        public object[][] items { get; set; }
        public object[][] qaitems { get; set; }
        public string newid { get; set; }
    }
    public class sSecuModels
    {
        public List<object[]> deviceitems { get; set; }
        public string status { get; set; }
    }

    public class iSecuData
    {
        public string externip { get; set; }
        public string newid { get; set; }
    }

    public class dFormData
    {
        public string formId { get; set; }
        public string newid { get; set; }
    }

    public class statusModels
    {
        [Required]
        public string status { get; set; }
    }

    public class permissModels
    {
        [Required]
        public bool insert { get; set; }
        [Required]
        public bool update { get; set; }
        [Required]
        public bool delete { get; set; }
        [Required]
        public bool export { get; set; }
    }

    public class sSiteData
    {
        public string formId { get; set; }
        public string value { get; set; }
        public string browser { get; set; }
        public string newid { get; set; }
    }

    public class sSiteModels
    {
        [Required]
        public bool webShow { get; set; }
        [Required]
        public string imagePath { get; set; }
        [Required]
        public string original { get; set; }
        [Required]
        public string encryption { get; set; }
        [Required]
        public string extension { get; set; }
    }

    public class sMainModels
    {
        [Required]
        public List<object[]> items { get; set; }
        [Required]
        public string status { get; set; }
    }
    public class sDefaModels
    {
        [Required]
        public int allCount { get; set; }
        [Required]
        public List<object[]> items { get; set; }
        [Required]
        public string status { get; set; }
    }
}