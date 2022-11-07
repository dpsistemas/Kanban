using DevExpress.ExpressApp.Blazor.Components.Models;

using Kanban.Module.BusinessObjects;


namespace Kanban.Blazor.Server
{
  public class KanvanModelEditor : ComponentModelBase
  {

    public IEnumerable<Itask> Data
    {
      get => GetPropertyValue<IEnumerable<Itask>>();
      set => SetPropertyValue(value);
    }
    public void Refresh() => RaiseChanged();
    public void OnItemClick(Itask item) =>
            ItemClick?.Invoke(this, new KanvanItemListViewModelItemClickEventArgs(item));
    public event EventHandler<KanvanItemListViewModelItemClickEventArgs> ItemClick;

    public class KanvanItemListViewModelItemClickEventArgs : EventArgs
    {
      public KanvanItemListViewModelItemClickEventArgs(Itask item)
      {
        Item = item;
      }

      public Itask Item { get; }

    }
  }
}


