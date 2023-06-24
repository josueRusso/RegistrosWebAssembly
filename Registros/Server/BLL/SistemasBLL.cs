using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Registros.Server.DAL;
using Registros.Shared.Model;
using System.Diagnostics.Contracts;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace Registros.Server.BLL
{
    public class SistemasBLL
    {
        private Context _context;

        public SistemasBLL(Context Context)
        {
            _context = Context;
        }

        public bool Guardar(Sistemas Sistema)
        {
            // busca si el registro existe, si existe lo modifica y si no lo inserta
            if (!Existe(Sistema.SistemaId))
                return Insertar(Sistema);
            else
                return Modificar(Sistema);
        }

        public bool Existe(int SistemaId)
        {
            return _context.Sistemas.Any(s => s.SistemaId == SistemaId);
        }

        private bool Insertar(Sistemas Sistema)
        {
            _context.Sistemas.Add(Sistema);
            int cantidad = _context.SaveChanges();
            return cantidad > 0;
        }

        public bool Modificar(Sistemas Sistema)
        {
            _context.Update(Sistema);
            int cantidad = _context.SaveChanges();
            return cantidad > 0;
        }

        public bool Eliminar(Sistemas Sistema)
        {
            _context.Sistemas.Remove(Sistema);
            int cantidad = _context.SaveChanges();
            return cantidad > 0;
        }

        public Sistemas? Buscar(int SistemaId)
        {
            return _context.Sistemas
                .AsNoTracking()
                .FirstOrDefault(s => s.SistemaId == SistemaId);
        }

        public List<Sistemas> GetList(Expression<Func<Sistemas, bool>> Criterio)
        {
            return _context.Sistemas
                .Where(Criterio)
                .AsNoTracking()
                .ToList();
        }
        public bool Validar(string nombre)
        {

            bool confirmar = false;
            try
            {
                confirmar = _context.Sistemas.Any(e => e.Nombre == nombre);
            }
            catch (Exception)
            {
                throw;
            }
            return confirmar;
        }
    }
}
