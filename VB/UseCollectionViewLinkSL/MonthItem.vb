Namespace UseCollectionViewLinkSL
    Public Class MonthItem
        Public Property Name() As String
        Public Property Quarter() As Integer

        Public Sub New(ByVal name As String, ByVal quarter As Integer)
            Me.Name = name
            Me.Quarter = quarter
        End Sub
    End Class
End Namespace
