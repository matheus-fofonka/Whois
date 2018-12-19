<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResultsIndex.aspx.cs" Inherits="Whois.apresentation.WhoisInterface.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Back to Home : "></asp:Label>
<a href="WhoisIndex.aspx"><img src="indexIMG.png" alt="Home" style="border-style: none; border-color: inherit; border-width: 0; width:25px; height:25px;"/></a>
    </div>
        <br />
            <asp:ListBox ID="lstResults" runat="server" Height="357px" Width="490px"></asp:ListBox>
            </form>
</body>
</html>
