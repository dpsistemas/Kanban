using DevExpress.Persistent.BaseImpl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Xpo;
using DevExpress.Persistent.Base;
using System.ComponentModel;

namespace Kanban.Module.BusinessObjects
{
  [DefaultClassOptions()]
  [DefaultProperty("Descripcion")]
  public class Tarea : XPBaseObject , Itask
  {
    private int _IdTarea;

    [VisibleInListView(true)]
    [VisibleInDetailView(true)]
    [Key(true)]
    public int IdTarea {
      get { return _IdTarea; }
      set { SetPropertyValue<int>("IdTarea", ref _IdTarea, value); }
    }
    private string _Descripcion;
    public string Descripcion {
      get { return _Descripcion; }
      set { SetPropertyValue<string>("Descripcion", ref _Descripcion, value); } 
    }
    private DateTime _Fecha; 
    public DateTime Fecha {
      get { return _Fecha; }
      set { SetPropertyValue<DateTime>("Fecha", ref _Fecha, value); } 
    }
    private Usuario _usuario;
    public Usuario usuario {
      get { return _usuario; }
      set { SetPropertyValue<Usuario>("Usuario", ref _usuario, value); } 
    }

    private string _Estado;
    public string Estado
    {
      get { return _Estado; } 
      set { SetPropertyValue<string>("Estado", ref _Estado, value); }
    }

    public Tarea(Session session) : base(session){}

    
  }
}
