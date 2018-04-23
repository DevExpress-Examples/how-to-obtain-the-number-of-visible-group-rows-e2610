Imports Microsoft.VisualBasic
Imports System.Windows
Imports System.Windows.Controls
Imports DevExpress.Xpf.Grid

Namespace ObtainGroupRowCountView
	Partial Public Class MainPage
		Inherits UserControl
		Public Sub New()
			InitializeComponent()
			grid.ItemsSource = New ProductList()
			grid.GroupBy("Country")
			grid.GroupBy("City")
			grid.ExpandGroupRow(-1)
		End Sub

		Private Sub Button_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			MessageBox.Show(String.Format("{0} group rows are displayed within the Table View.", GetVisibleGroupRowCount(grid)), "Group Row Info", MessageBoxButton.OK)
		End Sub

		Private Function GetVisibleGroupRowCount(ByVal grid As GridControl) As Integer
			Dim count As Integer = 0
			For i As Integer = 0 To grid.VisibleRowCount - 1
				Dim rowHandle As Integer = grid.GetRowHandleByVisibleIndex(i)
				If grid.IsGroupRowHandle(rowHandle) Then
					count += 1
				End If
			Next i
			Return count
		End Function

	End Class
End Namespace
