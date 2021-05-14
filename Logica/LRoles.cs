using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Logica.Interfaces;
using Datos;

namespace Logica
{
    public class LRoles : ICatalogos
    {
        public void Delete(object clase, ref ETransactionResult result)
        {
            DaRoles _daRoles = new DaRoles();
            _daRoles.Roles_Delete((ERoles)clase, ref result);
        }

        public List<object> GetAll(ref ETransactionResult result)
        {
            DaRoles _daRoles = new DaRoles();
            List<object> _roles = new List<object>(_daRoles.Roles_GetAll(ref result));
            return _roles;
        }

        public void Insert(object clase, ref ETransactionResult result)
        {
            DaRoles _daRoles = new DaRoles();            
            _daRoles.Roles_Insert((ERoles)clase, ref result);
        }

        public object select(object clase, ref ETransactionResult result)
        {
            DaRoles _daRoles = new DaRoles();
            return _daRoles.Roles_Get((ERoles)clase, ref result);
        }

        public void Update(object clase, ref ETransactionResult result)
        {
            DaRoles _daRoles = new DaRoles();
            _daRoles.Roles_Update((ERoles)clase, ref result);
        }
    }
}
