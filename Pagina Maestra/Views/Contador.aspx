<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contador.aspx.cs" Inherits="Pagina_Maestra.Views.Contador" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel">
        <div class="panel-header">
            <h2>Contador</h2>
        </div>
        <div class="panel-body">
            <div class="form-group">
         <label>Fecha</label>
         <asp:Label ID="lblFecha" CssClass="form-control" runat="server"></asp:Label>
    </div>
    <div class="form-group">
        <label>Contador</label>
        <asp:Label ID="lblContatador" CssClass="form-control" Text="0" runat="server"></asp:Label>
    </div>
        </div>
        <div class="panel-footer">
             <asp:Button ID="btnIncrementCounter" CssClass="btn btn-sm btn-primary" Text="Incrementar Contador" OnClick="btnIncrementCounter_Click" runat="server" />
        </div>
    </div>
    
   
</asp:Content>

