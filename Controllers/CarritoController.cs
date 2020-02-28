using net_shop_luismiguel_ortiz.Models;
using net_shop_luismiguel_ortiz.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace net_shop_luismiguel_ortiz.Controllers
{
    public class CarritoController : Controller
    {
        private ModeloTiendaContainer db = new ModeloTiendaContainer();

        // GET: Carrito/Add
        public ActionResult Add(Carrito carrito, int id)
        {
            Producto producto = db.Productos.Find(id);
            carrito.Add(producto);

            return View("List", carrito);
        }

        // GET: Carrito/Delete
        public ActionResult Delete(Carrito carrito, int id)
        {
            if (ModelState.IsValid)
            {
                Producto producto = carrito.Find(val => val.Id == id);
                carrito.Remove(producto);
            }

            return View("List", carrito);
        }

        // GET: Carrito/List
        public ActionResult List(Carrito carrito)
        {
            return View(carrito);
        }

        // GET: Carrito/Order
        public ActionResult Order(Carrito carrito)
        {
            Pedido pedido = CreateOrder();

            if (carrito.Count() == 0) return View("Error");
            foreach (Producto producto in carrito)
            {
                Producto p = db.Productos.Find(producto.Id);
                p.Stock.Cantidad--;
                pedido.Productos.Add(p);
                pedido.Factura.Total += p.Precio;
            }
            db.SaveChanges();
            carrito.Clear();

            return View("List", carrito);
        }

        private Pedido CreateOrder()
        {
            Factura factura = new Factura();
            factura.Total = 0;
            db.Facturas.Add(factura);

            Pedido pedido = new Pedido();
            pedido.Nombre = "Pedido para " + User.Identity.Name;
            pedido.Facturas_Id = factura.Id;
            db.Pedidos.Add(pedido);

            db.SaveChanges();

            return pedido;
        }
    }
}
