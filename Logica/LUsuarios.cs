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
    public class LUsuarios : ICatalogos
    {
        public void Delete(object clase, ref ETransactionResult result)
        {
            DaUsuarios _daLista = new DaUsuarios();
            _daLista.Usuarios_Delete((EUsuarios) clase, ref result);
        }

        public List<object> GetAll(ref ETransactionResult result)
        {
            DaUsuarios _daLista = new DaUsuarios();
            List<object> _usuarios = new List<object>(_daLista.Usuarios_GetAll(ref result));
            return _usuarios;
        }

        public void Insert(object clase, ref ETransactionResult result)
        {
            DaUsuarios _daLista = new DaUsuarios();
            _daLista.Usuarios_Insert((EUsuarios)clase, ref result);
        }

        public object select(object clase, ref ETransactionResult result)
        {
            DaUsuarios _daLista = new DaUsuarios();
            return _daLista.Usuarios_Get((EUsuarios)clase, ref result);            
        }

        public void Update(object clase, ref ETransactionResult result)
        {
            DaUsuarios _daLista = new DaUsuarios();
            _daLista.Usuarios_Update((EUsuarios)clase, ref result);
        }
    }
}
