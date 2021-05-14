using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Interfaces
{
    public interface ICatalogos
    {        
        List<object> GetAll(ref ETransactionResult result);
        object select(object clase, ref ETransactionResult result);
        void Insert(object clase, ref ETransactionResult result);
        void Update(object clase, ref ETransactionResult result);
        void Delete(object clase, ref ETransactionResult result);        
    }
}
