using DevExpress.Utils.DragDrop;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System.Data;
using System.Windows.Forms;

namespace DragDropExample {
    public partial class Form1 : DevExpress.XtraEditors.XtraForm {
        public Form1() {
            InitializeComponent();
            SetUpGrid(this.gridControl1, FillTable());
            HandleBehaviorDragDropEvents();
        }
        public DataTable FillTable() {
            DataTable table = new DataTable();
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("ItemName");
            for (int i = 1; i <= 10; i++)
                table.Rows.Add(new object[] { i, "Item " + i.ToString() });
            return table;
        }
        public void SetUpGrid(GridControl grid, DataTable table) {
            GridView view = grid.MainView as GridView;
            grid.DataSource = table;
            view.OptionsBehavior.Editable = false;
            view.OptionsSelection.MultiSelect = true;
            view.OptionsSelection.MultiSelectMode = GridMultiSelectMode.RowSelect;
            view.SelectRange(3, 7);
        }

        public void HandleBehaviorDragDropEvents() {
            DragDropBehavior listBoxBehavior = behaviorManager1.GetBehavior<DragDropBehavior>(this.listBoxControl1);
            listBoxBehavior.DragOver += ListBoxBehavior_DragOver;
            listBoxBehavior.DragDrop += ListBoxBehavior_DragDrop;
        }
        private void ListBoxBehavior_DragDrop(object sender, DragDropEventArgs e) {
            int[] rowHandles = (int[])e.Data;
            object[] rows = GetRows(this.gridView1, rowHandles);
            listBoxControl1.Items.Clear();
            foreach (object row in rows) {
                string name = (row as DataRowView)["ItemName"].ToString();
                listBoxControl1.Items.Add(name);
            }
        }
        private void ListBoxBehavior_DragOver(object sender, DragOverEventArgs e) {
            e.Default();
            Cursor.Current = Cursors.Default;
        }
        private object[] GetRows(GridView view, int[] rowHandles) {
            if (rowHandles.Length == 0)
                return null;
            object[] rows = new object[rowHandles.Length];
            for (int i = 0; i < rowHandles.Length; i++) {
                DataRowView row = view.GetRow(rowHandles[i]) as DataRowView;
                rows[i] = row;
            }
            return rows;
        }
    }
}