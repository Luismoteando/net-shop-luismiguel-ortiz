using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace net_shop_luismiguel_ortiz.Models
{
    public class CarritoModelBinder : IModelBinder
    {

        public static string key_carrito = "KEY_123_CARRITO";

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            Carrito carrito = (Carrito) controllerContext.HttpContext.Session[key_carrito];

            if (carrito == null)
            {
                carrito = new Carrito();
                controllerContext.HttpContext.Session[key_carrito] = new Carrito();
            }

            return carrito;
        }
    }
}