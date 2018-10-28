<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Repeater.aspx.cs" MasterPageFile="~/Site.Master" Inherits="Pagina_Maestra.Views.Repeater" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-sm-12">
            <div class="form-group">
                    <label>Nombre</label>
                    <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label>Nota</label>
                    <asp:TextBox ID="txtNota" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div>
                    <asp:Button ID="btnSubmit" OnClick="btnScoreSubmit" Text="Aceptar" runat="server" />
                </div>
                <div class="well">
                    <asp:Repeater runat="server" ID="rptResult">
                        <ItemTemplate>
                            <dl>
                                <dt><%#DataBinder.Eval(Container.DataItem, "Name") %></dt>
                                <dd><%#DataBinder.Eval(Container.DataItem, "Score") %></dd>
                            </dl>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
        </div>
    </div>
</asp:Content>
