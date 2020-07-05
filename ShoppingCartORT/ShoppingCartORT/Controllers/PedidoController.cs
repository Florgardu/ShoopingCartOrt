using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using ShoppingCartORT.Data;
using ShoppingCartORT.Models;
using Microsoft.AspNetCore.Http;

namespace ShoppingCartORT.Controllers
{
    public class PedidoController : Controller
    {
        private readonly ShoppingCartORTContext _context;

        public PedidoController(ShoppingCartORTContext context)
        {
            _context = context;
        }


        // prueba pedidos

       public void VerPedidos()
       {
           var Pedidos = _context.Pedidos.Include("items.producto").Include("usuario")
                        .ToList();

            foreach (Pedido p in Pedidos)
            {

                Console.WriteLine(p.nombre);
                Console.WriteLine(p.usuario.nombre);
                Console.WriteLine(p.ObtenerTotalPedido());
                Console.WriteLine("detalle items");
                foreach (Item item in p.items)
                {
                    Console.WriteLine(item.producto.nombre);
                    Console.WriteLine(item.cantidad);
                    Console.WriteLine(item.ObtenerTotal());
                }
                    

            }


        }



        // GET: Pedido
        public async Task<IActionResult> Index()
        {
            var Pedidos = _context.Pedidos
                .Include("items.producto")
                .Include("usuario")
                .ToList();
            return View(Pedidos);
        }



        // GET: Pedido/Details/5
        public async Task<IActionResult> Details(int id)
        {
            Console.WriteLine("me llego el id" + id);
            var Pedido = _context.Pedidos
                .Where(p => p.pedidoID == id)
                .Include("items.producto")
                .Include("usuario")
                .FirstOrDefault();
            return View(Pedido);
        }


        // GET: Pedido/Details/5
     //   public async Task<IActionResult> Details(int id)
       // {
         //   Console.WriteLine("me llego el id" + id );

//        }

        // GET: Pedido/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pedido/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]        
        public JsonResult Create([FromBody] List<ItemDTO> items)
        {
            var userMail = HttpContext.Session.GetString("user");
            var usuarioFromDB = _context.Usuarios.ToList().Find(u => u.mail == userMail);

            //Creamos el pedido
            var pedido = new Pedido
            {
                nombre = "Nombre del pedido",
                usuario = usuarioFromDB
            };

            _context.Pedidos.Add(pedido);

            _context.SaveChanges();

            int id = pedido.pedidoID;

            foreach (ItemDTO item in items) {
                var productoFromDB = _context.Productos.ToList().Find(p => p.productoID == item.productoID);
                Item i = new Item();
                i.cantidad = item.cantidad;
                i.producto = productoFromDB;
                i.pedido = pedido;
                _context.Items.Add(i);
            }

            _context.SaveChanges();

            Console.WriteLine("******** "+ items);

            return Json(items.Count);
        }


        // GET: Pedido/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }
            return View(pedido);
        }

        // POST: Pedido/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("pedidoID,nombre")] Pedido pedido)
        {
            if (id != pedido.pedidoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pedido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PedidoExists(pedido.pedidoID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pedido);
        }

        // GET: Pedido/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos
                .FirstOrDefaultAsync(m => m.pedidoID == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // POST: Pedido/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);
            _context.Pedidos.Remove(pedido);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PedidoExists(int id)
        {
            return _context.Pedidos.Any(e => e.pedidoID == id);
        }
    }
}
