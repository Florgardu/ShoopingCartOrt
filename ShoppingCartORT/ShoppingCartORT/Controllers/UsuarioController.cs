using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingCartORT.Data;
using ShoppingCartORT.Models;
using Microsoft.AspNetCore.Http;

namespace ShoppingCartORT.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly ShoppingCartORTContext _context;
        private Usuario usuarioContext;


        public UsuarioController(ShoppingCartORTContext context)
        {
            _context = context;            
        }

        // GET: Usuario
        public async Task<IActionResult> Index()
        {
            return View(await _context.Usuarios.ToListAsync());
        }

        // GET: Usuario/Login/
        public IActionResult Login()
        {
            return View();
        }

        // GET: Usuario/Logout/
        public RedirectToActionResult Logout()
        {
            HttpContext.Session.SetString("rol", string.Empty);
            HttpContext.Session.SetString("user", string.Empty);
            Console.WriteLine(HttpContext.Session.GetString("user"));
            return RedirectToAction("Index", "Home");
            
        }

        // GET: Usuario/Login
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        public async Task<IActionResult> Login(String mail, String password)
        {
            if (ModelState.IsValid)
            {
                var usuarioFromDB = await _context.Usuarios.FirstOrDefaultAsync(usu => usu.mail == mail && usu.password == password);
                if (usuarioFromDB == null) {
                    ViewBag.Error = "Usuario o clave incorrectos.";
                    return View();
                }
                usuarioContext = usuarioFromDB;
                HttpContext.Session.SetString("user", usuarioFromDB.mail);
                HttpContext.Session.SetString("rol", usuarioFromDB.rol);
                return RedirectToAction("Index", "Producto");
            }
            return View(null);
        }



        // GET: Usuario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.usuarioID == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Usuario/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("usuarioID,nombre,apellido,dni,password,mail")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                usuario.rol = "USER";
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                usuarioContext = usuario;
                return RedirectToAction("Index","Home");
            }
            return View(usuario);
        }

        // GET: Usuario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        // POST: Usuario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("usuarioID,nombre,apellido,dni,password,mail")] Usuario usuario)
        {
            if (id != usuario.usuarioID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.usuarioID))
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
            return View(usuario);
        }

        // GET: Usuario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.usuarioID == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.usuarioID == id);
        }
    }
}
