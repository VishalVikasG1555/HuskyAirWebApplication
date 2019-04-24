using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.IO;
using System.Drawing;
using System.Text;


namespace Husky_Air
{
    public partial class Report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=HuskyAirReport.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";

            GridView1.AllowPaging = false;
            GridView1.DataBind();

            StringBuilder sb = new StringBuilder();
            for (int k = 0; k < GridView1.Columns.Count; k++)
            {
                //add separator
                sb.Append(GridView1.Columns[k].HeaderText + ',');
            }
            //append new line
            sb.Append("\r\n");
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                for (int k = 0; k < GridView1.Columns.Count; k++)
                {
                    //add separator
                    sb.Append(GridView1.Rows[i].Cells[k].Text + ',');
                }
                //append new line
                sb.Append("\r\n");
            }
            Response.Output.Write(sb.ToString());
            Response.Flush();
            Response.End();
            Response.Write("Report Generated Suucessfully");
            //    using (StringWriter sw = new StringWriter())
            //    {
            //        HtmlTextWriter hw = new HtmlTextWriter(sw);

            //        //To Export all pages
            //        GridView1.AllowPaging = false;
            //        this.BindGrid();

            //        GridView1.HeaderRow.BackColor = Color.White;
            //        foreach (TableCell cell in GridView1.HeaderRow.Cells)
            //        {
            //            cell.BackColor = GridView1.HeaderStyle.BackColor;
            //        }
            //        foreach (GridViewRow row in GridView1.Rows)
            //        {
            //            row.BackColor = Color.White;
            //            foreach (TableCell cell in row.Cells)
            //            {
            //                if (row.RowIndex % 2 == 0)
            //                {
            //                    cell.BackColor = GridView1.AlternatingRowStyle.BackColor;
            //                }
            //                else
            //                {
            //                    cell.BackColor = GridView1.RowStyle.BackColor;
            //                }
            //                cell.CssClass = "textmode";
            //            }
            //        }

            //        GridView1.RenderControl(hw);

            //        System.Web.UI.HtmlControls.HtmlForm form = new System.Web.UI.HtmlControls.HtmlForm();
            //        Controls.Add(form);
            //        form.Controls.Add(GridView1);
            //        form.RenderControl(hw);


            //        //style to format numbers to string
            //        string style = @"<style> .textmode { } </style>";
            //        Response.Write(style);
            //        Response.Output.Write(sw.ToString());
            //        Response.Flush();
            //        Response.End();
            //    }
            //}

            //    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
            //{
            //    GridView1.PageIndex = e.NewPageIndex;
            //    this.BindGrid();
            //}

        }



    }
}

