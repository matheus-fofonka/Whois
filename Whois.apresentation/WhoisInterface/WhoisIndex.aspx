﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WhoisIndex.aspx.cs" Inherits="Whois.apresentation.WhoisInterface.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <!-- Meta tags Obrigatórias -->
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous">

    <title>Pesquise Domínios</title>
    <style type="text/css">
        #IndexWI {
            height: 289px;
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

    <form id="IndexWI" runat="server">
        <div>
            
            <asp:Label ID="Label1" runat="server" Text="Domínio : "></asp:Label>
            <asp:TextBox ID="txtURL" runat="server" Height="19px"  Width="267px" ></asp:TextBox>  
            <asp:Button ID="btnSearch" runat="server" OnClick="Button1_Click" Text="Search" />
        </div>
        <br />
        <asp:Label ID="Label8" runat="server" Text="Site : "></asp:Label>
        <asp:Label ID="lblDomain" runat="server"></asp:Label>
        &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
        <asp:Label ID="Label7" runat="server" Text="Search History : "></asp:Label>
        <a href="ResultsIndex.aspx"><img src="resultsIMG.png" alt="Results" style="border-style: none; border-color: inherit; border-width: 0; width:35px; height:35px;"/></a>
        <br />
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
        <br />
        <div>
            <asp:Label ID="Label6" runat="server" Text="Lista de Servers:"></asp:Label>
            <br />
            <asp:ListBox ID="ListBox1" runat="server" Width="600px" Height="250px"></asp:ListBox>
            <br />
        </div>
        <div>   


            <asp:Label ID="lblContent" runat="server"></asp:Label>
            <br />
            <asp:ListBox ID="LstContent" runat="server" Height="250px"  Width="600px"></asp:ListBox>


        </div>

    </form>
</body>
</html>
