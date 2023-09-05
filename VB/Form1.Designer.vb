Namespace DragDropExample

    Partial Class Form1

        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Me.components IsNot Nothing) Then
                Me.components.Dispose()
            End If

            MyBase.Dispose(disposing)
        End Sub

#Region "Windows Form Designer generated code"
        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Me.gridControl1 = New DevExpress.XtraGrid.GridControl()
            Me.gridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
            Me.listBoxControl1 = New DevExpress.XtraEditors.ListBoxControl()
            Me.behaviorManager1 = New DevExpress.Utils.Behaviors.BehaviorManager(Me.components)
            Me.splitterControl1 = New DevExpress.XtraEditors.SplitterControl()
            CType((Me.gridControl1), System.ComponentModel.ISupportInitialize).BeginInit()
            CType((Me.gridView1), System.ComponentModel.ISupportInitialize).BeginInit()
            CType((Me.listBoxControl1), System.ComponentModel.ISupportInitialize).BeginInit()
            CType((Me.behaviorManager1), System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            ' 
            ' gridControl1
            ' 
            Me.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.gridControl1.Location = New System.Drawing.Point(0, 0)
            Me.gridControl1.MainView = Me.gridView1
            Me.gridControl1.Name = "gridControl1"
            Me.gridControl1.Size = New System.Drawing.Size(493, 551)
            Me.gridControl1.TabIndex = 2
            Me.gridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridView1})
            ' 
            ' gridView1
            ' 
            Me.behaviorManager1.SetBehaviors(Me.gridView1, New DevExpress.Utils.Behaviors.Behavior() {CType((DevExpress.Utils.DragDrop.DragDropBehavior.Create(GetType(DevExpress.XtraGrid.Extensions.ColumnViewDragDropSource), True, True, True)), DevExpress.Utils.Behaviors.Behavior)})
            Me.gridView1.GridControl = Me.gridControl1
            Me.gridView1.Name = "gridView1"
            ' 
            ' listBoxControl1
            ' 
            Me.behaviorManager1.SetBehaviors(Me.listBoxControl1, New DevExpress.Utils.Behaviors.Behavior() {CType((DevExpress.Utils.DragDrop.DragDropBehavior.Create(GetType(DevExpress.XtraEditors.DragDropBehaviorSourceForListBox), True, True, True)), DevExpress.Utils.Behaviors.Behavior)})
            Me.listBoxControl1.Cursor = System.Windows.Forms.Cursors.[Default]
            Me.listBoxControl1.Dock = System.Windows.Forms.DockStyle.Right
            Me.listBoxControl1.Location = New System.Drawing.Point(498, 0)
            Me.listBoxControl1.Name = "listBoxControl1"
            Me.listBoxControl1.Size = New System.Drawing.Size(173, 551)
            Me.listBoxControl1.TabIndex = 3
            ' 
            ' splitterControl1
            ' 
            Me.splitterControl1.Dock = System.Windows.Forms.DockStyle.Right
            Me.splitterControl1.Location = New System.Drawing.Point(493, 0)
            Me.splitterControl1.Name = "splitterControl1"
            Me.splitterControl1.Size = New System.Drawing.Size(5, 551)
            Me.splitterControl1.TabIndex = 4
            Me.splitterControl1.TabStop = False
            ' 
            ' Form1
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(671, 551)
            Me.Controls.Add(Me.gridControl1)
            Me.Controls.Add(Me.splitterControl1)
            Me.Controls.Add(Me.listBoxControl1)
            Me.Name = "Form1"
            Me.Text = "Form1"
            CType((Me.gridControl1), System.ComponentModel.ISupportInitialize).EndInit()
            CType((Me.gridView1), System.ComponentModel.ISupportInitialize).EndInit()
            CType((Me.listBoxControl1), System.ComponentModel.ISupportInitialize).EndInit()
            CType((Me.behaviorManager1), System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
        End Sub

#End Region
        Private gridControl1 As DevExpress.XtraGrid.GridControl

        Private gridView1 As DevExpress.XtraGrid.Views.Grid.GridView

        Private listBoxControl1 As DevExpress.XtraEditors.ListBoxControl

        Private behaviorManager1 As DevExpress.Utils.Behaviors.BehaviorManager

        Private splitterControl1 As DevExpress.XtraEditors.SplitterControl
    End Class
End Namespace
