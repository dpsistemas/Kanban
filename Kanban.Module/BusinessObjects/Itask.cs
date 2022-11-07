using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.Module.BusinessObjects
{
  public interface Itask
  {
    string Descripcion { get; }
    DateTime Fecha { get; }
    Usuario usuario { get; }

    string Estado { get; }

  }
}
