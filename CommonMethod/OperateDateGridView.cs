using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace CommonMethod
{
    public class OperateDateGridView
    {
        public static DataGridView CloneDataGridView(DataGridView dgv)
        {
            try
            {
                DataGridView ResultDGV = new DataGridView();
                ResultDGV.AllowUserToAddRows = false;
                ResultDGV.ColumnHeadersDefaultCellStyle = dgv.ColumnHeadersDefaultCellStyle.Clone();
                DataGridViewCellStyle dtgvdcs = dgv.RowsDefaultCellStyle.Clone();
                dtgvdcs.BackColor = dgv.DefaultCellStyle.BackColor;
                dtgvdcs.ForeColor = dgv.DefaultCellStyle.ForeColor;
                dtgvdcs.Font = dgv.DefaultCellStyle.Font;
                ResultDGV.RowsDefaultCellStyle = dtgvdcs;
                ResultDGV.AlternatingRowsDefaultCellStyle = dgv.AlternatingRowsDefaultCellStyle.Clone();
                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    DataGridViewColumn DTGVC = dgv.Columns[i].Clone() as DataGridViewColumn;
                    DTGVC.DisplayIndex = dgv.Columns[i].DisplayIndex;
                    if (DTGVC.CellType == null)
                    {
                        DTGVC.CellTemplate = new DataGridViewTextBoxCell();
                        ResultDGV.Columns.Add(DTGVC);
                    }
                    else
                    {
                        ResultDGV.Columns.Add(DTGVC);
                    }
                }
                for (int ii = 0; ii < dgv.Rows.Count; ii++)
                {
                    DataGridViewRow var = dgv.Rows[ii];
                    DataGridViewRow Dtgvr = var.Clone() as DataGridViewRow;
                    Dtgvr.DefaultCellStyle = var.DefaultCellStyle.Clone();
                    for (int i = 0; i < var.Cells.Count; i++)
                    {
                        Dtgvr.Cells[i].Value = var.Cells[i].Value;
                    }
                    if (var.Index % 2 == 0)
                        Dtgvr.DefaultCellStyle.BackColor = ResultDGV.RowsDefaultCellStyle.BackColor;
                    ResultDGV.Rows.Add(Dtgvr);
                
                }
                    
               
                return ResultDGV;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }
        
    }
}
