using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using DLLFullPrint;

namespace CommonMethod
{
    public class PrintDataGridView
    {
        public static void PrintTheDataGridView(DataGridView dgv)
        {
            DataTable dt = new DataTable();
            DataRow dr;
            //设置列表头 

            foreach (DataGridViewColumn headerCell in dgv.Columns)
            {
                dt.Columns.Add(headerCell.HeaderText);
            }
            foreach (DataGridViewRow item in dgv.Rows)
            {
                dr = dt.NewRow();
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    if (item.Cells[i].Value == null)
                    {
                        dr[i] = "";
                    }
                    else
                    {
                        dr[i] = item.Cells[i].Value.ToString();
                    }
                }
                dt.Rows.Add(dr);
            }
            DataSet dy = new DataSet();
            dy.Tables.Add(dt);
            MyDLL.TakeOver(dy);
        }


    }
}

