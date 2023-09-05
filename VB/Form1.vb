Imports System
Imports System.Drawing
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo

Namespace MultiRow

    ''' <summary>
    ''' Summary description for Form1.
    ''' </summary>
    Public Class Form1
        Inherits Form

        Private gridControl1 As DevExpress.XtraGrid.GridControl

        Private gridView1 As GridView

        Private dataSet1 As DataSet

        Private dataTable1 As DataTable

        Private dataColumn1 As DataColumn

        Private dataColumn2 As DataColumn

        Private listBoxControl1 As DevExpress.XtraEditors.ListBoxControl

        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.Container = Nothing

        Public Sub New()
            '
            ' Required for Windows Form Designer support
            '
            InitializeComponent()
        '
        ' TODO: Add any constructor code after InitializeComponent call
        '
        End Sub

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If components IsNot Nothing Then
                    components.Dispose()
                End If
            End If

            MyBase.Dispose(disposing)
        End Sub

#Region "Windows Form Designer generated code"
        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            gridControl1 = New DevExpress.XtraGrid.GridControl()
            gridView1 = New GridView()
            dataSet1 = New DataSet()
            dataTable1 = New DataTable()
            dataColumn1 = New DataColumn()
            dataColumn2 = New DataColumn()
            listBoxControl1 = New DevExpress.XtraEditors.ListBoxControl()
            CType(gridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(gridView1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(dataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(dataTable1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(listBoxControl1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            ' 
            ' gridControl1
            ' 
            gridControl1.Dock = DockStyle.Fill
            ' 
            ' 
            ' 
            gridControl1.EmbeddedNavigator.Name = ""
            gridControl1.Location = New System.Drawing.Point(0, 0)
            gridControl1.MainView = gridView1
            gridControl1.Name = "gridControl1"
            gridControl1.Size = New System.Drawing.Size(424, 312)
            gridControl1.TabIndex = 0
            gridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {gridView1})
            ' 
            ' gridView1
            ' 
            gridView1.ActiveFilterString = ""
            gridView1.GridControl = gridControl1
            gridView1.Name = "gridView1"
            AddHandler gridView1.MouseDown, New MouseEventHandler(AddressOf gridView1_MouseDown)
            AddHandler gridView1.MouseMove, New MouseEventHandler(AddressOf gridView1_MouseMove)
            ' 
            ' dataSet1
            ' 
            dataSet1.DataSetName = "NewDataSet"
            dataSet1.Locale = New Globalization.CultureInfo("en-US")
            dataSet1.Tables.AddRange(New DataTable() {dataTable1})
            ' 
            ' dataTable1
            ' 
            dataTable1.Columns.AddRange(New DataColumn() {dataColumn1, dataColumn2})
            dataTable1.TableName = "Table1"
            ' 
            ' dataColumn1
            ' 
            dataColumn1.ColumnName = "ID"
            dataColumn1.DataType = GetType(Integer)
            ' 
            ' dataColumn2
            ' 
            dataColumn2.ColumnName = "ItemName"
            ' 
            ' listBoxControl1
            ' 
            listBoxControl1.AllowDrop = True
            listBoxControl1.Dock = DockStyle.Right
            listBoxControl1.Location = New System.Drawing.Point(424, 0)
            listBoxControl1.Name = "listBoxControl1"
            listBoxControl1.Size = New System.Drawing.Size(192, 312)
            listBoxControl1.TabIndex = 1
            AddHandler listBoxControl1.DragOver, New DragEventHandler(AddressOf listBoxControl1_DragOver)
            AddHandler listBoxControl1.DragDrop, New DragEventHandler(AddressOf listBoxControl1_DragDrop)
            ' 
            ' Form1
            ' 
            AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            ClientSize = New System.Drawing.Size(616, 312)
            Me.Controls.Add(gridControl1)
            Me.Controls.Add(listBoxControl1)
            Name = "Form1"
            Text = "Select multiple rows in the grid and drag them to the list box on the right"
            AddHandler Load, New EventHandler(AddressOf Form1_Load)
            CType(gridControl1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(gridView1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(dataSet1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(dataTable1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(listBoxControl1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
        End Sub

#End Region
        ''' <summary>
        ''' The main entry point for the application.
        ''' </summary>
        <STAThread>
        Shared Sub Main()
            Call Application.Run(New Form1())
        End Sub

        Private Sub FillTable()
            For i As Integer = 0 To 10 - 1
                dataTable1.Rows.Add(New Object() {i, "Item " & i.ToString()})
            Next

            dataTable1.AcceptChanges()
        End Sub

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs)
            FillTable()
            gridControl1.DataSource = dataTable1
            gridView1.OptionsSelection.MultiSelect = True
            gridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseUp
            gridView1.SelectRange(3, 7)
        End Sub

        Private downHitInfo As GridHitInfo = Nothing

        Private Sub gridView1_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
            Dim view As GridView = TryCast(sender, GridView)
            downHitInfo = Nothing
            Dim hitInfo As GridHitInfo = view.CalcHitInfo(New Point(e.X, e.Y))
            If ModifierKeys <> Keys.None Then Return
            If e.Button = MouseButtons.Left AndAlso hitInfo.InRow AndAlso hitInfo.HitTest <> GridHitTest.RowIndicator Then downHitInfo = hitInfo
        End Sub

        Private Function GetDragData(ByVal view As GridView) As String()
            Dim selection As Integer() = view.GetSelectedRows()
            If selection Is Nothing Then Return Nothing
            Dim count As Integer = selection.Length
            Dim result As String() = New String(count - 1) {}
            For i As Integer = 0 To count - 1
                result(i) = view.GetRowCellDisplayText(selection(i), view.Columns(1))
            Next

            Return result
        End Function

        Private Sub gridView1_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
            Dim view As GridView = TryCast(sender, GridView)
            If e.Button = MouseButtons.Left AndAlso downHitInfo IsNot Nothing Then
                Dim dragSize As Size = SystemInformation.DragSize
                Dim dragRect As Rectangle = New Rectangle(New Point(downHitInfo.HitPoint.X - dragSize.Width \ 2, downHitInfo.HitPoint.Y - dragSize.Height \ 2), dragSize)
                If Not dragRect.Contains(New Point(e.X, e.Y)) Then
                    view.GridControl.DoDragDrop(GetDragData(view), DragDropEffects.All)
                    downHitInfo = Nothing
                End If
            End If
        End Sub

        Private Sub listBoxControl1_DragOver(ByVal sender As Object, ByVal e As DragEventArgs)
            e.Effect = DragDropEffects.Copy
        End Sub

        Private Sub listBoxControl1_DragDrop(ByVal sender As Object, ByVal e As DragEventArgs)
            listBoxControl1.Items.Clear()
            Dim data As String() = TryCast(e.Data.GetData(GetType(String())), String())
            listBoxControl1.Items.AddRange(data)
        End Sub
    End Class
End Namespace
