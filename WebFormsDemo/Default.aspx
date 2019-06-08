<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebFormsDemo._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h3>Export View</h3>
    <br />

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CellPadding="5">

        <Columns>
            <asp:BoundField HeaderText="PollitoId" Datafield="PollitoId"   />
            <asp:BoundField HeaderText="Nombre" Datafield="Nombre"   />

        </Columns>


    </asp:GridView>
    
    <div>
        <asp:Button ID="Botón1" runat="server" Text="Word" OnClick="Botón1_Click" />
        <asp:Button ID="Button2" runat="server" Text="Excel" OnClick="Button2_Click" />
        
    </div>

   </asp:Content>
