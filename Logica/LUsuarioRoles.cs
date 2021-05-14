using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logica.Interfaces;
using Entidades;
using Datos;

namespace Logica
{
    public class LUsuarioRoles : ICatalogos
    {
        public void Delete(object clase, ref ETransactionResult result)
        {
            DaUsuariosRoles _daUsuarioRol = new DaUsuariosRoles();
            _daUsuarioRol.UsuariosRoles_Delete((EUsuariosRoles)clase, ref result);
        }

        public List<object> GetAll(ref ETransactionResult result)
        {
            DaUsuariosRoles _daUsuarioRol = new DaUsuariosRoles();
            List<object> _usuarioRol = new List<object>(_daUsuarioRol.UsuariosRoles_GetAll(ref result));
            return _usuarioRol;
        }

        public void Insert(object clase, ref ETransactionResult result)
        {
            DaUsuariosRoles _daUsuarioRol = new DaUsuariosRoles();
            _daUsuarioRol.UsuariosRoles_Insert((EUsuariosRoles)clase, ref result);
        }

        public object select(object clase, ref ETransactionResult result)
        {
            DaUsuariosRoles _daUsuarioRol = new DaUsuariosRoles();
            return _daUsuarioRol.UsuariosRoles_Get((EUsuariosRoles)clase, ref result);
        }

        public void Update(object clase, ref ETransactionResult result)
        {
            DaUsuariosRoles _daUsuarioRol = new DaUsuariosRoles();
            _daUsuarioRol.UsuariosRoles_Update((EUsuariosRoles)clase, ref result);
        }
    }
}
