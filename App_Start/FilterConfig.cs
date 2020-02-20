using System.Web;
using System.Web.Mvc;

namespace net_shop_luismiguel_ortiz
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
