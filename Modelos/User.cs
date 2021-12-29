using System.ComponentModel.DataAnnotations;
using System;
namespace TestHttpClient.Modelos
{
    public class User
    {
        [RequiredAttribute]
        public String provider { get; set; }

        [RequiredAttribute]
        public String username { get; set; }

        [RequiredAttribute]
        public String password { get; set; }
        public String type { get; set; }
    }
}