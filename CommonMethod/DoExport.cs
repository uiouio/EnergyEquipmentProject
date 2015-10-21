using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Reflection;
using System.Data;
using System.Windows.Forms;
using NPOI;
using NPOI.HPSF;
using NPOI.HSSF;
using NPOI.HSSF.UserModel;
using System.IO;
namespace CommonMethod
{
    public  class DoExport
    {
        public static bool DoTheExport(DataGridView dgv)
        {

            if (dgv.Rows.Count > 0)
            {
                System.Data.DataTable dt = new System.Data.DataTable();

                DataRow drr;
                //设置列表头 

                foreach (DataGridViewColumn headerCell in dgv.Columns)
                {
                    dt.Columns.Add(headerCell.HeaderText);
                }
                foreach (DataGridViewRow item in dgv.Rows)
                {
                    drr = dt.NewRow();
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        drr[i] = item.Cells[i].Value == null?"":item.Cells[i].Value.ToString();
                    }
                    dt.Rows.Add(drr);
                }

                ExportExcel(dt);
                return true;
            }
            else
            {
                MessageBox.Show("没有数据导出！");
                return false;
            
            }


           
        }

        public static void ExportExcel(DataTable Dt)
        {
            HSSFWorkbook hssfworkbook2 = new HSSFWorkbook();
            HSSFSheet sheet = (HSSFSheet)hssfworkbook2.CreateSheet("Sheet1");

            HSSFRow row1 = (HSSFRow)sheet.CreateRow(0);


            for (int j1 = 0; j1 <= Dt.Columns.Count - 1; j1++)
            {
                row1.CreateCell(j1).SetCellValue(Dt.Columns[j1].ColumnName);
                sheet.SetColumnWidth(j1, 20 * 256);
            }

            for (int I = 0; I <= Dt.Rows.Count - 1; I++)
            {
                HSSFRow row2 = (HSSFRow)sheet.CreateRow(I + 1);

                for (int j = 0; j <= Dt.Columns.Count - 1; j++)
                {
                    string DgvValue = Dt.Rows[I][j].ToString();
                    row2.CreateCell(j).SetCellValue(DgvValue);
                    sheet.SetColumnWidth(j, 20 * 256);
                }
            }


            try
            {

                SaveFileDialog Sfd = new SaveFileDialog();
                Sfd.Filter = "Excel文件(*.xls)|*.xls";
                if (Sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    FileStream file3 = new FileStream(Sfd.FileName, FileMode.Create);
                    hssfworkbook2.Write(file3);
                    file3.Close();
                    MessageBox.Show("成功导出为Excel！");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }


    }
}
