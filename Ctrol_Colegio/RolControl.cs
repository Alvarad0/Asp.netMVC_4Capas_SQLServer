using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Per_Colegio;
using Ent_Colegio;

namespace Ctrol_Colegio
{
    public class RolControl
    {
        RolPersistencia persistencia;

        public List<Rol> lista;

        public RolControl()
        {
            persistencia = new RolPersistencia();
        }

        public List<Rol> ObtenerTodos()
        {
            return (List<Rol>)new RolPersistencia().ObtenerTodos();
        }

        public bool Insertar(Rol Entidad)
        {
            return persistencia.Insertar(Entidad);
        }

        public bool Actualizar(Rol Entidad)
        {
            return persistencia.Actualizar(Entidad);
        }

        public Rol Obtener(int id)
        {
            return (Rol) new RolPersistencia().Obtener(id);
        }

        public bool Eliminar(int id) {
            return persistencia.Eliminar(id);
        }

    }
}
