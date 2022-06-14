using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebTruyenChu.Models;

namespace WebTruyenChu.Models
{
    public class HomeModel
    {
        public List<truyen> truyens { get; set; }
        public List<theloai> theloais { get; set; }
        public List<chuong> chuongs { get; set; }
    }
}