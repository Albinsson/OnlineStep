using OnlineStep.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace OnlineStep.Assets
{
    public class CustomGrid : Grid 
    {
        public CustomGrid()
        {
            this.ChildAdded += CustomGridOnChildAdded;
        }
      
        private void CustomGridOnChildAdded(object sender, ElementEventArgs e)
        {
            Button btn = (Button)e.Element; { HorizontalOptions = LayoutOptions.CenterAndExpand; VerticalOptions = LayoutOptions.CenterAndExpand; };
            for(int rowIdx = 0; rowIdx < 2; rowIdx++)
            {
                for(int colIdx = 0; colIdx < 3; colIdx++)
                {
                    //this.Children.Add(btn, colIdx, rowIdx);                   
                }
            }
        }
    }
}
