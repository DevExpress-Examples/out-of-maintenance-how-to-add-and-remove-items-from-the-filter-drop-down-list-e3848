Imports Microsoft.VisualBasic
Imports System.IO
Imports System.Reflection
Imports System.Windows.Controls
Imports System.Xml.Serialization
Imports DevExpress.Xpf.PivotGrid
Imports DevExpress.XtraPivotGrid.Data

Namespace DXPivotGrid_CustomFilterItems
	Partial Public Class MainPage
		Inherits UserControl
		Private dataFileName As String = "nwind.xml"
		Public Sub New()
			InitializeComponent()

			' Parses an XML file and creates a collection of data items.
			Dim [assembly] As System.Reflection.Assembly = _
				System.Reflection.Assembly.GetExecutingAssembly()
			Dim stream As Stream = [assembly].GetManifestResourceStream(dataFileName)
			Dim s As New XmlSerializer(GetType(OrderData))
			Dim dataSource As Object = s.Deserialize(stream)

			' Binds a pivot grid to this collection.
			pivotGridControl1.DataSource = dataSource
		End Sub
		Private ReadOnly dummyItem As String = ""
		Private Sub pivotGridControl1_CustomFilterPopupItems(ByVal sender As Object, _
			ByVal e As PivotCustomFilterPopupItemsEventArgs)
            If Object.ReferenceEquals(e.Field, fieldCountry) Then
                For i As Integer = e.Items.Count - 1 To 0 Step -1
                    If Object.Equals(e.Items(i).Value, "UK") Then
                        e.Items.RemoveAt(i)
                        Exit For
                    End If
                Next i
                e.Items.Insert(0, New PivotGridFilterItem(dummyItem, _
                            "Dummy Item", _
                            e.Field.FilterValues.Contains(dummyItem)))
            End If
		End Sub
	End Class
End Namespace
