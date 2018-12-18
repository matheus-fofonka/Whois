<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WhoisIndex.aspx.cs" Inherits="Whois.apresentation.WhoisInterface.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        #IndexWI {
            height: 289px;
        }
    </style>
</head>
<body>
    <form id="IndexWI" runat="server">
        <div>

            <asp:Label ID="Label1" runat="server" Text="Domínio : "></asp:Label>
            <asp:TextBox ID="txtURL" runat="server" Height="19px"  Width="267px" OnTextChanged="txtURL_TextChanged" ></asp:TextBox>            
        </div>
        <asp:Label ID="lblDomain" runat="server"></asp:Label>
        <br />
        <br />
        <div>
        <asp:Button ID="btnSearch" runat="server" OnClick="Button1_Click" Text="Search" />
            </div>
            <br />
        <div>
            <asp:Label ID="lblSTATUS" runat="server" ForeColor="Blue" Text="STATUS"></asp:Label>
        </div>
        <br />  
        <div>
            <asp:Label ID="Label3" runat="server" Text="Data de Registro :"></asp:Label>

            <asp:Label ID="lblDtRegister" runat="server"></asp:Label>

        </div>
        <div>
            <asp:Label ID="Label4" runat="server" Text="Data de Alteração :"></asp:Label>
            <asp:Label ID="lblDtUpdate" runat="server"></asp:Label>
        </div>
        <div>
            <asp:Label ID="Label5" runat="server" Text="Data de Expiração :"></asp:Label>
            <asp:Label ID="lblDtExpiration" runat="server"></asp:Label>
        </div>
        <br />        <br />
        <div>
            <asp:Label ID="Label6" runat="server" Text="Lista de Servers:"></asp:Label>
            <br />
            <asp:ListBox ID="ListBox1" runat="server" Width="354px" Height="200px"></asp:ListBox>
            <br />
            <br />
        </div>

    </form>
</body>
</html>
