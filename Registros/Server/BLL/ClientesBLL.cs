using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Registros.Server.DAL;
using Registros.Shared.Model;
using System.Diagnostics.Contracts;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Registros.Server.BLL
{
    public class ClientesBLL
    {

        private Context _context;

        public ClientesBLL(Context Context)
        {
            _context = Context;
        }

        public bool Existe(int ClienteId)
        {
            return _context.Clientes.Any(s => s.ClienteId == ClienteId);
        }

        private bool Insertar(Clientes cliente)
        {
            _context.Clientes.Add(cliente);
            int verificar = _context.SaveChanges();
            return verificar > 0;
        }

        public bool Modificar(Clientes cliente)
        {
            _context.Update(cliente);
            int verificar = _context.SaveChanges();
            return verificar > 0;
        }

        public bool Guardar(Clientes cliente)
        {
            if (!Existe(cliente.ClienteId))
                return Insertar(cliente);
            else
                return Modificar(cliente);
        }

        public bool Eliminar(Clientes cliente)
        {
            _context.Clientes.Remove(cliente);
            int verificar = _context.SaveChanges();
            return verificar > 0;
        }

        public Clientes? Buscar(int ClienteId)
        {
            return _context.Clientes
                .AsNoTracking()
                .FirstOrDefault(s => s.ClienteId == ClienteId);
        }

        public List<Clientes> GetList(Expression<Func<Clientes, bool>> Criterio)
        {
            return _context.Clientes
                .Where(Criterio)
                .AsNoTracking()
                .ToList();
        }

        public bool Validar(string nombre, string Rnc)
        {

            bool confirmar = false;
           
            confirmar = _context.Clientes.Any(e => e.Nombre.ToLower() == nombre.ToLower() || e.Rnc == Rnc);
            return confirmar;
        }
    }
}