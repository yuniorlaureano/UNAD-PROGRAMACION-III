<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Noticias.aspx.cs" Inherits="Pagina_Maestra.Views.Noticias" %>
<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-horizontal">
        <div class="row">
       <input type="hidden" name="id" />
            <div class="form-group">
                <label class="col-sm-2"> Titutlo</label>
                <div class="col-sm-10">
                    <input type="text" name="titulo" />
                </div>
            </div>
            <div class="form-group">
                <label class="col-sm-2"> Contendio</label>
                <div class="col-sm-10">
                    <input type="text" name="contenido" />
                </div>
            </div>
            <div class="form-group">
                <label class="col-sm-2"> Image</label>
                <div class="col-sm-10">
                    <input type="text" name="imagen" />
                </div>
            </div>
            <div class="form-group">
                <label class="col-sm-2"> Author</label>
                <div class="col-sm-10">
                    <input type="text" name="author" />
                </div>
            </div>  
            <div class="col-sm-10 offset-sm-2">
                <button type="submit" class="btn btn-default">Guardar</button>
            </div>
    </div>
        <div class="row">
            <div class="col-sm-12">
                <table class="table">
                    <thead>
                        <tr>
                            <th>Titutlo</th>
                            <th>Contendio</th>
                            <th>Author</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater runat="server" ID="tblNoticias">
                        <ItemTemplate>
                            <tr>
                                <td><%#DataBinder.Eval(Container.DataItem, "Titulo") %></td>
                                <td><%#DataBinder.Eval(Container.DataItem, "Contenido") %></td>
                                <td><%#DataBinder.Eval(Container.DataItem, "Author") %></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</asp:Content>