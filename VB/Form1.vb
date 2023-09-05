Imports DevExpress.Utils.DragDrop
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports System.Data
Imports System.Windows.Forms

Namespace DragDropExample

    Public Partial Class Form1
        Inherits DevExpress.XtraEditors.XtraForm

        Public Sub New()
            InitializeComponent()
            SetUpGrid(gridControl1, FillTable())
            HandleBehaviorDragDropEvents()
        End Sub

        Public Function FillTable() As DataTable
            Dim table As DataTable = New DataTable()
            table.Columns.Add("ID", GetType(Integer))
            table.Columns.Add("ItemName")
            For i As Integer = 1 To 10
                table.Rows.Add(New Object() {i, "Item " & i.ToString()})
            Next

            Return table
        End Function

        Public Sub SetUpGrid(ByVal grid As GridControl, ByVal table As DataTable)
            Dim view As GridView = TryCast(grid.MainView, GridView)
            grid.DataSource = table
            view.OptionsBehavior.Editable = False
            view.OptionsSelection.MultiSelect = True
            view.OptionsSelection.MultiSelectMode = GridMultiSelectMode.RowSelect
            view.SelectRange(3, 7)
        End Sub

        Public Sub HandleBehaviorDragDropEvents()
            Dim listBoxBehavior As DragDropBehavior = behaviorManager1.GetBehavior(Of DragDropBehavior)(listBoxControl1)
            AddHandler listBoxBehavior.DragOver, AddressOf ListBoxBehavior_DragOver
            AddHandler listBoxBehavior.DragDrop, AddressOf ListBoxBehavior_DragDrop
        End Sub

        Private Sub ListBoxBehavior_DragDrop(ByVal sender As Object, ByVal e As DragDropEventArgs)
            Dim rowHandles As Integer() = CType(e.Data, Integer())
            Dim rows As Object() = GetRows(gridView1, rowHandles)
            listBoxControl1.Items.Clear()
            For Each row As Object In rows
                Dim name As String = TryCast(row, DataRowView)("ItemName").ToString()
                listBoxControl1.Items.Add(name)
            Next
        End Sub

        Private Sub ListBoxBehavior_DragOver(ByVal sender As Object, ByVal e As DragOverEventArgs)
            e.Default()
            Cursor.Current = Cursors.Default
        End Sub

        Private Function GetRows(ByVal view As GridView, ByVal rowHandles As Integer()) As Object()
            If rowHandles.Length = 0 Then Return Nothing
            Dim rows As Object() = New Object(rowHandles.Length - 1) {}
            For i As Integer = 0 To rowHandles.Length - 1
                Dim row As DataRowView = TryCast(view.GetRow(rowHandles(i)), DataRowView)
                rows(i) = row
            Next

            Return rows
        End Function
    End Class
End Namespace
