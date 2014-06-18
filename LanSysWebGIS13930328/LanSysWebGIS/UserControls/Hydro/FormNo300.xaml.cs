using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace LanSysWebGIS.UserControls.Hydro
{
    public partial class FormNo300 : UserControl
    {
        public FormNo300()
        {
            InitializeComponent();
        }

        public IList SelectedItems
        {
            get { return this.dataGrid.SelectedItems; }
        }
    }
}
