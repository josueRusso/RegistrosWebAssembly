using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Registros.Server.DAL;
using Registros.Shared.Model;
using System.Diagnostics.Contracts;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace RRegistros.Server.BLL
{
    public class PrioridadBLL
    {
        private Context _context;
        public PrioridadBLL(Context Context) { 
            _context = Context; 
        }
        public bool Existe(int PrioridadId)
        {
            return _context.Prioridades.Any(s => s.PrioridadId == PrioridadId);
        }
        private bool Insertar(Prioridades prioridad)
        {
            _context.Prioridades.Add(prioridad);
            int verificar = _context.SaveChanges();
            return verificar > 0;
        }

        public bool Modificar(Prioridades prioridad)
        {
            _context.Update(prioridad);
            int verificar = _context.SaveChanges();
            return verificar > 0;
        }
        public bool Guardar(Prioridades prioridad)
        {
            if (!Existe(prioridad.PrioridadId))
                return Insertar(prioridad);
            else 
                return Modificar(prioridad);
        }
        public bool Eliminar(Prioridades prioridad)
        {
            _context.Prioridades.Remove(prioridad);
            int verificar = _context.SaveChanges();
            return verificar > 0;    
        }
        public Prioridades? Buscar(int PrioridadId)
        {
            return _context.Prioridades
                .AsNoTracking()
                .FirstOrDefault(s => s.PrioridadId == PrioridadId);
        }
        public List<Prioridades> GetList(Expression<Func<Prioridades, bool >> Criterio)
        {
            return _context.Prioridades
                .Where(Criterio)
                .AsNoTracking()
                .ToList();
        }
        public bool Validar(string descripcion)
        {
            bool confirmar = false;
            try
            {
                confirmar = _context.Prioridades.Any(e => e.Descripcion == descripcion);
            }
            catch (Exception)
            {
                throw;
            }

            return confirmar;
        }

    }
}
