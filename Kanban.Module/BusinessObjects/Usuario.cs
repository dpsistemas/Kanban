using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.Module.BusinessObjects
{
  [DefaultClassOptions()]
  [DefaultProperty("Nombre")]
  public class Usuario : XPBaseObject
  {
    private int _Id;

    [VisibleInListView(true)]
    [VisibleInDetailView(true)]
    [Key(true)]
    public int Id {
      get { return _Id;}
      set { SetPropertyValue<int>("Id", ref _Id, value); }
    }
    private string _Nombre;
    public string Nombre {
      get { return _Nombre; }
      set { SetPropertyValue<string>("Nombre", ref _Nombre, value); }
    }

    public Usuario(Session session) : base(session) { }
  }
}
