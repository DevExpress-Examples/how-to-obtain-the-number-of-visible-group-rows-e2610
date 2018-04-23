using System.Windows;
using System.Windows.Controls;
using DevExpress.Xpf.Grid;

namespace ObtainGroupRowCountView {
    public partial class MainPage : UserControl {
        public MainPage() {
            InitializeComponent();
            grid.DataSource = new ProductList();
            grid.GroupBy("Country");
            grid.GroupBy("City");
            grid.ExpandGroupRow(-1);
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            MessageBox.Show(string.Format("{0} group rows are displayed within the Table View.",
                GetVisibleGroupRowCount(grid)),
                "Group Row Info", MessageBoxButton.OK);
        }

        private int GetVisibleGroupRowCount(GridControl grid) {
            int count = 0;
            for (int i = 0; i < grid.VisibleRowCount; i++) {
                int rowHandle = grid.GetRowHandleByVisibleIndex(i);
                if (grid.IsGroupRowHandle(rowHandle))
                    count++;
            }
            return count;
        }

    }
}
