using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using DevExpress.Xpf.Printing;
// ...

namespace UseCollectionViewLinkSL {
    public partial class MainPage : UserControl {
        public MainPage() {
            InitializeComponent();
        }

        #region #CollectionViewLink
        void Page_Loaded(object sender, RoutedEventArgs e) {
            // Create a link and bind it to the PrintPreview instance.
            CollectionViewLink link = new CollectionViewLink();
            preview.Model = new LinkPreviewModel(link);

            // Create an ICollectionView object.
            link.CollectionView = CreateMonthCollectionView();
            link.ExportServiceUri = "../ExportService1.svc";

            // Provide export templates.
            link.DetailTemplate = (DataTemplate)Resources["monthNameTemplate"];
            link.GroupInfos.Add(new GroupInfo((DataTemplate)Resources["monthQuarterTemplate"]));

            // Create a document.
            link.CreateDocument(true);
        }

        static ICollectionView CreateMonthCollectionView() {
            MonthItem[] data = CultureInfo.CurrentCulture.DateTimeFormat.MonthNames
                .Where(x => !string.IsNullOrEmpty(x))
                .Select((x, i) => new MonthItem(x, (i / 3) + 1))
                .ToArray();

            var source = new CollectionViewSource {
                Source = data
            };
            source.GroupDescriptions.Add(new PropertyGroupDescription("Quarter"));

            return source.View;
        }
        #endregion #CollectionViewLink
    }
}