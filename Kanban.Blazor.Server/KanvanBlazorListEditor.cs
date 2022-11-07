using DevExpress.ExpressApp.Blazor.Components;
using DevExpress.ExpressApp.Blazor;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp;
using Microsoft.AspNetCore.Components;
using System.ComponentModel;
using Kanban.Blazor.Server.Pages;
using System.Collections;
using Kanban.Module.BusinessObjects;
using static Kanban.Blazor.Server.KanvanModelEditor;

namespace Kanban.Blazor.Server
{
  [ListEditor(typeof(Itask))]
  public class KanvanBlazorListEditor : ListEditor
  {
    public class KanvanListViewHolder : IComponentContentHolder
      {
        private RenderFragment componentContent;
        public KanvanListViewHolder(KanvanModelEditor componentModel)
        {
          ComponentModel =
              componentModel ?? throw new ArgumentNullException(nameof(componentModel));
        }
        private RenderFragment CreateComponent() =>
            ComponentModelObserver.Create(ComponentModel,
                                            GridKanvanListView.Create(ComponentModel));
        public KanvanModelEditor ComponentModel { get; }
        RenderFragment IComponentContentHolder.ComponentContent =>
            componentContent ??= CreateComponent();
      }
      private Itask[] selectedObjects = Array.Empty<Itask>();
      public KanvanBlazorListEditor(IModelListView model) : base(model) { }
      protected override object CreateControlsCore() =>
          new KanvanListViewHolder(new KanvanModelEditor());

    protected override void AssignDataSourceToControl(object dataSource)
    {
      if (Control is KanvanListViewHolder holder)
      {
        if (holder.ComponentModel.Data is IBindingList bindingList)
        {
          bindingList.ListChanged -= BindingList_ListChanged;
        }
        holder.ComponentModel.Data =
            (dataSource as IEnumerable)?.OfType<Itask>().OrderBy(i => i.usuario);
        if (dataSource is IBindingList newBindingList)
        {
          newBindingList.ListChanged += BindingList_ListChanged;
        }
      }
    }
   
    public override void Refresh()
    {
      if (Control is KanvanListViewHolder holder)
      {
        holder.ComponentModel.Refresh();
      }
    }
    private void BindingList_ListChanged(object sender, ListChangedEventArgs e)
    {
      Refresh();
    }
    //private void ComponentModel_ItemClick(object sender,
    //                                        PictureItemListViewModelItemClickEventArgs e)
    //{
    //  selectedObjects = new IPictureItem[] { e.Item };
    //  OnSelectionChanged();
    //  OnProcessSelectedItem();
    //}

    protected override void OnControlsCreated()
    {
      if (Control is KanvanListViewHolder holder)
      {
        holder.ComponentModel.ItemClick += ComponentModel_ItemClick;
      }
      base.OnControlsCreated();
    }
    public override void BreakLinksToControls()
    {
      if (Control is KanvanListViewHolder holder)
      {
        holder.ComponentModel.ItemClick -= ComponentModel_ItemClick;
      }
      AssignDataSourceToControl(null);
      base.BreakLinksToControls();
    }
    private void ComponentModel_ItemClick(object sender,
                                                KanvanItemListViewModelItemClickEventArgs e)
    {
      selectedObjects = new Itask[] { e.Item };
      OnSelectionChanged();
      OnProcessSelectedItem();
    }
    public override SelectionType SelectionType => SelectionType.Full;
    public override IList GetSelectedObjects() => selectedObjects;
  }
  
}
