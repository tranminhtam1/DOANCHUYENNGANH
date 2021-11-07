using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace webdemoquanlygiay
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
            name: "Dangky",
            url: "dang-ky",
            defaults: new { controller = "Taikhoan", action = "Dangky", id = UrlParameter.Optional }
        );
            routes.MapRoute(
            name: "Condition",
            url: "condition",
            defaults: new { controller = "Gioithieu", action = "Condition", id = UrlParameter.Optional }
        );
            routes.MapRoute(
             name: "Warranty",
             url: "warranty",
             defaults: new { controller = "Gioithieu", action = "Warranty", id = UrlParameter.Optional }
         );
            routes.MapRoute(
        name: "Policy",
        url: "policy",
        defaults: new { controller = "Gioithieu", action = "Policy", id = UrlParameter.Optional }
    );
            routes.MapRoute(
             name: "Blog",
             url: "blog",
             defaults: new { controller = "Blog", action = "Blog", id = UrlParameter.Optional }
         );
            routes.MapRoute(
             name: "KhuyenMai",
             url: "khuyen-mai",
             defaults: new { controller = "Khuyenmai", action = "discountPage", id = UrlParameter.Optional }
         );
            routes.MapRoute(
              name: "GioiThieu",
              url: "gioi-thieu",
              defaults: new { controller = "Gioithieu", action = "About", id = UrlParameter.Optional }
          );
            routes.MapRoute(
           name: "TatCaSanPham",
           url: "tat-ca-san-pham",
           defaults: new { controller = "Site", action = "Product", id = UrlParameter.Optional }
       );
            routes.MapRoute(
              name: "LienHe",
              url: "lien-he",
              defaults: new { controller = "Lienhe", action = "Index", id = UrlParameter.Optional }
          );
            routes.MapRoute(
                name: "GioHang",
                url: "gio-hang",
                defaults: new { controller = "GioHang", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Site", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
