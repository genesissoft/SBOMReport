using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Serialization;
using Newtonsoft.Json;
using ClosedXML.Excel;
using System.Data;

public partial class SOBMReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadSBOMData();
        }
    }
    private void LoadSBOMData()
    {
        List<SOBM> sbomList = SOBM.GetSampleData();
        gvSBOM.DataSource = sbomList;
        gvSBOM.DataBind();
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        ExportGridToExcel();
    }

    private void ExportGridToExcel()
    {
        DataTable dt = new DataTable();

        // Extract data from GridView into DataTable
        foreach (TableCell cell in gvSBOM.HeaderRow.Cells)
        {
            dt.Columns.Add(cell.Text);
        }

        foreach (GridViewRow row in gvSBOM.Rows)
        {
            DataRow dr = dt.NewRow();
            for (int i = 0; i < row.Cells.Count; i++)
            {
                dr[i] = row.Cells[i].Text;
            }
            dt.Rows.Add(dr);
        }

        using (XLWorkbook wb = new XLWorkbook())
        {
            wb.Worksheets.Add(dt, "SBOM Report");
            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment;filename=SBOM_Report.xlsx");

            using (MemoryStream stream = new MemoryStream())
            {
                wb.SaveAs(stream);
                stream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
        }
    }
    private DataTable GetSBOMData()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("Component Name");
        dt.Columns.Add("Version");
        dt.Columns.Add("Description");
        dt.Columns.Add("Supplier");
        dt.Columns.Add("License");
        dt.Columns.Add("Origin");
        dt.Columns.Add("Dependencies");
        dt.Columns.Add("Criticality");
        dt.Columns.Add("Usage Restrictions");
        dt.Columns.Add("Checksum/Hash");
        dt.Columns.Add("Comments/Notes");

        dt.Rows.Add("Newtonsoft.Json", "13.0.1", "JSON framework", "Newtonsoft", "MIT", "NuGet", "None", "Low", "None", "abc123", "Commonly used library");
        dt.Rows.Add("ClosedXML", "0.93.0", "Excel library", "ClosedXML Team", "MIT", "NuGet", "None", "Medium", "None", "xyz789", "Free and easy-to-use");

        return dt;
    }
    private void ExportToExcel()
    {
        //List<SBOMBasic> sbomList = SBOMBasic.GetSampleData();
        //using (XLWorkbook test = new XLWorkbook())
        //{
        //    var ws = test.Worksheets.Add("SBOM Report");

        //    // Add headers
        //    ws.Cell(1, 1).Value = "Component Name";
        //    ws.Cell(1, 2).Value = "Version";
        //    ws.Cell(1, 3).Value = "Description";
        //    ws.Cell(1, 4).Value = "Supplier";
        //    ws.Cell(1, 5).Value = "License";
        //    ws.Cell(1, 6).Value = "Origin";
        //    ws.Cell(1, 7).Value = "Dependencies";
        //    ws.Cell(1, 8).Value = "Criticality";
        //    ws.Cell(1, 9).Value = "Usage Restrictions";
        //    ws.Cell(1, 10).Value = "Checksum/Hash";
        //    ws.Cell(1, 11).Value = "Comments/Notes";

        //    // Populate data
        //    int row = 2;
        //    foreach (var sbom in sbomList)
        //    {
        //        ws.Cell(row, 1).Value = sbom.ComponentName;
        //        ws.Cell(row, 2).Value = sbom.Version;
        //        ws.Cell(row, 3).Value = sbom.Description;
        //        ws.Cell(row, 4).Value = sbom.Supplier;
        //        ws.Cell(row, 5).Value = sbom.License;
        //        ws.Cell(row, 6).Value = sbom.Origin;
        //        ws.Cell(row, 7).Value = sbom.Dependencies;
        //        ws.Cell(row, 8).Value = sbom.Criticality;
        //        ws.Cell(row, 9).Value = sbom.UsageRestrictions;
        //        ws.Cell(row, 10).Value = sbom.ChecksumHash;
        //        ws.Cell(row, 11).Value = sbom.Comments;
        //        row++;
        //    }

        //    // Set response headers
        //    Response.Clear();
        //    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        //    Response.AddHeader("content-disposition", "attachment;filename=SBOM_Report.xlsx");

        //    using (MemoryStream stream = new MemoryStream())
        //    {
        //        wb.SaveAs(stream);
        //        stream.WriteTo(Response.OutputStream);
        //        Response.Flush();
        //        Response.End();
        //    }
        //}
    }
}