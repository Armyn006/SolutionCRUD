using ProyectoCrud.DAL.DataContext;
using ProyectoCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCrud.DAL.Repositorio
{
    public class UsuarioRepository : IGenericRepository<Usuario>
    {

        private readonly DbcrudContext _dbContext;
        public UsuarioRepository(DbcrudContext context)
        {
            _dbContext = context;
        }

        public async Task<bool> Actualizar(Usuario modelo)
        {
            _dbContext.Usuarios.Update(modelo);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
           Usuario modelo  = _dbContext.Usuarios.First(c => c.IdUsuario == id);
           _dbContext.Usuarios.Remove(modelo);
            await _dbContext.SaveChangesAsync();
            return true;
        }


        public async Task<bool> Insertar(Usuario modelo)
        {
            _dbContext.Usuarios.Add(modelo);
            await _dbContext.SaveChangesAsync();    
            return true;
        }

        public async Task<Usuario> Obtener(int id)
        {
            return await _dbContext.Usuarios.FindAsync(id);
        }

        public async Task<IQueryable<Usuario>> ObtenerTodos()
        {
            IQueryable<Usuario> queryUsuarioSQL = _dbContext.Usuarios;
            return queryUsuarioSQL;
        }
    }
}
