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
