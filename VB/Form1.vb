Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Collections
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
		Inherits System.Windows.Forms.Form
		Private gridControl1 As DevExpress.XtraGrid.GridControl
		Private WithEvents gridView1 As DevExpress.XtraGrid.Views.Grid.GridView
		Private dataSet1 As System.Data.DataSet
		Private dataTable1 As System.Data.DataTable
		Private dataColumn1 As System.Data.DataColumn
		Private dataColumn2 As System.Data.DataColumn
		Private WithEvents listBoxControl1 As DevExpress.XtraEditors.ListBoxControl
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
		Protected Overrides Overloads Sub Dispose(ByVal disposing As Boolean)
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
			Me.gridControl1 = New DevExpress.XtraGrid.GridControl()
			Me.gridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
			Me.dataSet1 = New System.Data.DataSet()
			Me.dataTable1 = New System.Data.DataTable()
			Me.dataColumn1 = New System.Data.DataColumn()
			Me.dataColumn2 = New System.Data.DataColumn()
			Me.listBoxControl1 = New DevExpress.XtraEditors.ListBoxControl()
			CType(Me.gridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.gridView1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.dataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.dataTable1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.listBoxControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' gridControl1
			' 
			Me.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill
			' 
			' 
			' 
			Me.gridControl1.EmbeddedNavigator.Name = ""
			Me.gridControl1.Location = New System.Drawing.Point(0, 0)
			Me.gridControl1.MainView = Me.gridView1
			Me.gridControl1.Name = "gridControl1"
			Me.gridControl1.Size = New System.Drawing.Size(424, 312)
			Me.gridControl1.TabIndex = 0
			Me.gridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() { Me.gridView1})
			' 
			' gridView1
			' 
			Me.gridView1.ActiveFilterString = ""
			Me.gridView1.GridControl = Me.gridControl1
			Me.gridView1.Name = "gridView1"
'			Me.gridView1.MouseDown += New System.Windows.Forms.MouseEventHandler(Me.gridView1_MouseDown);
'			Me.gridView1.MouseMove += New System.Windows.Forms.MouseEventHandler(Me.gridView1_MouseMove);
			' 
			' dataSet1
			' 
			Me.dataSet1.DataSetName = "NewDataSet"
			Me.dataSet1.Locale = New System.Globalization.CultureInfo("en-US")
			Me.dataSet1.Tables.AddRange(New System.Data.DataTable() { Me.dataTable1})
			' 
			' dataTable1
			' 
			Me.dataTable1.Columns.AddRange(New System.Data.DataColumn() { Me.dataColumn1, Me.dataColumn2})
			Me.dataTable1.TableName = "Table1"
			' 
			' dataColumn1
			' 
			Me.dataColumn1.ColumnName = "ID"
			Me.dataColumn1.DataType = GetType(Integer)
			' 
			' dataColumn2
			' 
			Me.dataColumn2.ColumnName = "ItemName"
			' 
			' listBoxControl1
			' 
			Me.listBoxControl1.AllowDrop = True
			Me.listBoxControl1.Dock = System.Windows.Forms.DockStyle.Right
			Me.listBoxControl1.Location = New System.Drawing.Point(424, 0)
			Me.listBoxControl1.Name = "listBoxControl1"
			Me.listBoxControl1.Size = New System.Drawing.Size(192, 312)
			Me.listBoxControl1.TabIndex = 1
'			Me.listBoxControl1.DragOver += New System.Windows.Forms.DragEventHandler(Me.listBoxControl1_DragOver);
'			Me.listBoxControl1.DragDrop += New System.Windows.Forms.DragEventHandler(Me.listBoxControl1_DragDrop);
			' 
			' Form1
			' 
			Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
			Me.ClientSize = New System.Drawing.Size(616, 312)
			Me.Controls.Add(Me.gridControl1)
			Me.Controls.Add(Me.listBoxControl1)
			Me.Name = "Form1"
			Me.Text = "Select multiple rows in the grid and drag them to the list box on the right"
'			Me.Load += New System.EventHandler(Me.Form1_Load);
			CType(Me.gridControl1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.gridView1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.dataSet1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.dataTable1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.listBoxControl1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub
		#End Region

		''' <summary>
		''' The main entry point for the application.
		''' </summary>
		<STAThread> _
		Shared Sub Main()
			Application.Run(New Form1())
		End Sub

		Private Sub FillTable()
			For i As Integer = 0 To 9
				dataTable1.Rows.Add(New Object() {i, "Item " & i.ToString()})
			Next i
			dataTable1.AcceptChanges()
		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			FillTable()
			gridControl1.DataSource = dataTable1
			gridView1.OptionsSelection.MultiSelect = True
			gridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseUp

			gridView1.SelectRange(3, 7)
		End Sub

		Private downHitInfo As GridHitInfo = Nothing

		Private Sub gridView1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles gridView1.MouseDown
			Dim view As GridView = TryCast(sender, GridView)
			downHitInfo = Nothing

			Dim hitInfo As GridHitInfo = view.CalcHitInfo(New Point(e.X, e.Y))
			If Control.ModifierKeys <> Keys.None Then
				Return
			End If
			If e.Button = MouseButtons.Left AndAlso hitInfo.InRow AndAlso hitInfo.HitTest <> GridHitTest.RowIndicator Then
				downHitInfo = hitInfo
			End If
		End Sub

		Private Function GetDragData(ByVal view As GridView) As String()
			Dim selection() As Integer = view.GetSelectedRows()
			If selection Is Nothing Then
				Return Nothing
			End If
			Dim count As Integer = selection.Length
			Dim result(count - 1) As String
			For i As Integer = 0 To count - 1
				result(i) = view.GetRowCellDisplayText(selection(i), view.Columns(1))
			Next i
			Return result
		End Function

		Private Sub gridView1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles gridView1.MouseMove
			Dim view As GridView = TryCast(sender, GridView)
			If e.Button = MouseButtons.Left AndAlso downHitInfo IsNot Nothing Then
				Dim dragSize As Size = SystemInformation.DragSize
				Dim dragRect As New Rectangle(New Point(downHitInfo.HitPoint.X - dragSize.Width / 2, downHitInfo.HitPoint.Y - dragSize.Height / 2), dragSize)

				If (Not dragRect.Contains(New Point(e.X, e.Y))) Then
					view.GridControl.DoDragDrop(GetDragData(view), DragDropEffects.All)
					downHitInfo = Nothing
				End If
			End If
		End Sub

		Private Sub listBoxControl1_DragOver(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles listBoxControl1.DragOver
			e.Effect = DragDropEffects.Copy
		End Sub

		Private Sub listBoxControl1_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles listBoxControl1.DragDrop
			listBoxControl1.Items.Clear()
			Dim data() As String = TryCast(e.Data.GetData(GetType(String())), String())
			listBoxControl1.Items.AddRange(data)
		End Sub
	End Class
End Namespace