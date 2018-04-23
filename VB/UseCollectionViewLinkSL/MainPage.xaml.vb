Imports System
Imports System.Linq
Imports System.ComponentModel
Imports System.Globalization
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports DevExpress.Xpf.Printing
' ...

Namespace UseCollectionViewLinkSL
    Partial Public Class MainPage
        Inherits UserControl
        Public Sub New()
            InitializeComponent()
        End Sub

#Region "#CollectionViewLink"
        Sub Page_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
            ' Create a link and bind it to the PrintPreview instance.
            Dim link As New CollectionViewLink()
            preview.Model = New LinkPreviewModel(link)

            ' Create an ICollectionView object.
            link.CollectionView = CreateMonthCollectionView()
            link.ExportServiceUri = "../ExportService1.svc"

            ' Provide export templates.
            link.DetailTemplate = CType(Resources("monthNameTemplate"), DataTemplate)
            link.GroupInfos.Add(New GroupInfo(CType(Resources("monthQuarterTemplate"), DataTemplate)))

            ' Create a document.
            link.CreateDocument(True)
        End Sub

        Shared Function CreateMonthCollectionView() As ICollectionView
            Dim data = CultureInfo.CurrentCulture.DateTimeFormat.MonthNames _
                       .Where(Function(x) Not String.IsNullOrEmpty(x)) _
                       .Select(Function(x, i) New MonthItem(x, (i \ 3) + 1)) _
                       .ToArray()

            Dim source As New CollectionViewSource() With {
                .Source = data
            }
            source.GroupDescriptions.Add(New PropertyGroupDescription("Quarter"))

            Return source.View
        End Function
#End Region ' #CollectionViewLink
    End Class
End Namespace