using System.IO;
using System.Reflection;
using System.Windows.Controls;
using System.Xml.Serialization;
using DevExpress.Xpf.PivotGrid;
using DevExpress.XtraPivotGrid.Data;

namespace DXPivotGrid_CustomFilterItems {
    public partial class MainPage : UserControl {
        string dataFileName = "DXPivotGrid_CustomFilterItems.nwind.xml";
        public MainPage() {
            InitializeComponent();

            // Parses an XML file and creates a collection of data items.
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream stream = assembly.GetManifestResourceStream(dataFileName);
            XmlSerializer s = new XmlSerializer(typeof(OrderData));
            object dataSource = s.Deserialize(stream);

            // Binds a pivot grid to this collection.
            pivotGridControl1.DataSource = dataSource;
        }
        readonly string dummyItem = "";
        private void pivotGridControl1_CustomFilterPopupItems(object sender, 
            PivotCustomFilterPopupItemsEventArgs e) {
            if (object.ReferenceEquals(e.Field, fieldCountry)) {
                for (int i = e.Items.Count - 1; i >= 0; i--) {
                    if (object.Equals(e.Items[i].Value, "UK")) {
                        e.Items.RemoveAt(i);
                        break;
                    }
                }
                e.Items.Insert(0, new PivotGridFilterItem(dummyItem,
                                                          "Dummy Item",
                                                          e.Field.FilterValues.Contains(dummyItem)));
            }
        }
    }
}
