<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebFormsDemo._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h3>Export View</h3>
    <br />

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CellPadding="5">

        <Columns>
            <asp:BoundField HeaderText="clienteId" Datafield="clienteId"   />
            <asp:BoundField HeaderText="Nombre" Datafield="Nombre"   />

        </Columns>


    </asp:GridView>
    

   </asp:Content>
