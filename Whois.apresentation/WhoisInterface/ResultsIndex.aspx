<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResultsIndex.aspx.cs" Inherits="Whois.apresentation.WhoisInterface.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <!-- Meta tags Obrigatórias -->
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous">

    <title>Resultados</title>
    <style type="text/css">
        #form1 {
            height: 485px;
        }
    </style>
</head>
<body>

    <style> body {
        background-image: url('bgImg.jpg');
    background-repeat: no-repeat;
    background-size:100%;
    bottom: 0;
    color: black;
    left: 0;
    overflow: auto;
    padding: 3em;
    position: absolute;
    right: 0;
    text-align: center;
    top: 0;}
    </style>

    <form id="form1" runat="server">
        <div>
            &nbsp;<h2>
            <a href="WhoisIndex.aspx">
                <img src="indexIMG.png" alt="Home" style="border-style: none; border-color: inherit; border-width: 0; width: 30px; height: 30px;" /></a>&nbsp<asp:Label ID="Label1" runat="server" Text="     Back to Home " ForeColor="White"></asp:Label></h2>
            &nbsp;</div>
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Id" DataSourceID="SqlDataSource" ForeColor="#333333" GridLines="None" Height="600px" Width="1000px" HorizontalAlign="Center">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                <asp:BoundField DataField="nmURL" HeaderText="nmURL" SortExpression="nmURL" />
                <asp:BoundField DataField="boolAvaliable" HeaderText="boolAvaliable" SortExpression="boolAvaliable" />
                <asp:BoundField DataField="dtSearch" HeaderText="dtSearch" SortExpression="dtSearch" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:dbWHOISConnectionString %>" SelectCommand="SELECT * FROM [Table_nm_avaliable]"></asp:SqlDataSource>
    </form>
</body>
</html>
