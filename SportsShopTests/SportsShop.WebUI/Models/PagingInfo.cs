using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using SportsShop.WebUI.Models;
using SportsShop.WebUI.HtmlHelpers;

namespace SportsShop.WebUI.Models
{
    public class PagingInfo
    {
        public int TotalItems { get; set; } 
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get;set; }

        public int TotalPages { 
            get { return (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage); }
        }
    }
}