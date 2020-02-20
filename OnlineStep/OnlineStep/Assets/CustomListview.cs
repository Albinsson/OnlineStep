using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace OnlineStep.Assets
{
    class CustomListview : ListView
    {
        //    public static BindableProperty ItemClickCommandProperty = BindableProperty.Create<ListView, ICommand>(x => x.ItemClickCommand, null);

        //    public CustomListview()
        //    {
        //        this.ItemTapped += CustomListviewItemTapped;
        //    }

        //    public ICommand ItemClickCommand
        //    {
        //        get { return (ICommand)this.GetValue(ItemClickCommandProperty); }
        //        set { this.SetValue(ItemClickCommandProperty, value); }
        //    }

        //    private void CustomListviewItemTapped(object sender, ItemTappedEventArgs e)
        //    {
        //        if(e.Item != null && this.ItemClickCommand != null && this.ItemClickCommand.CanExecute(e))
        //        {
        //            this.ItemClickCommand.Execute(e.Item);
        //            this.SelectedItem = null;
        //        }
        //    }
        //}
    }
}
