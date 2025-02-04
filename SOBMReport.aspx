<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SOBMReport.aspx.cs" Inherits="SOBMReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Software Bill of Materials (SBOM) Report</h2>
            <asp:GridView ID="gvSBOM" runat="server" AutoGenerateColumns="False" BorderWidth="1" CellPadding="5">
                <Columns>
                    <asp:BoundField DataField="ComponentName" HeaderText="Component Name" />
                    <asp:BoundField DataField="Version" HeaderText="Version" />
                    <asp:BoundField DataField="Description" HeaderText="Description" />
                    <asp:BoundField DataField="Supplier" HeaderText="Supplier" />
                    <asp:BoundField DataField="License" HeaderText="License" />
                    <asp:BoundField DataField="Origin" HeaderText="Origin" />
                    <asp:BoundField DataField="Dependencies" HeaderText="Dependencies" />
                    <asp:BoundField DataField="Criticality" HeaderText="Criticality" />
                    <asp:BoundField DataField="UsageRestrictions" HeaderText="Usage Restrictions" />
                    <asp:BoundField DataField="ChecksumHash" HeaderText="Checksum/Hash" />
                    <asp:BoundField DataField="Comments" HeaderText="Comments/Notes" />
                </Columns>
            </asp:GridView>
            <br />
            <asp:Button ID="btnExport" runat="server" Text="Export to Excel" OnClick="btnExport_Click" />
        </div>
    </form>
</body>
</html>
