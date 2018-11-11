<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Comentario.aspx.cs" Inherits="Pagina_Maestra.Views.Comentario" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-horizontal">
        <div class="row">
        <asp:Label Visible="false" Text="Debe proveer el nombre" CssClass="text-danger" runat="server" ID="lblNombre"></asp:Label> <br />
        <asp:Label Visible="false" Text="Debe proveer el asunto" CssClass="text-danger" runat="server" ID="lblAsunto"></asp:Label><br />
        <asp:Label Visible="false" Text="Debe proveer el contenido" CssClass="text-danger" runat="server" ID="lblContenido"></asp:Label><br />
           <div class="row" style="margin-bottom: 10px;">
               <div class="col-sm-6">
                   <input type="text" class="form-control" id="txtSearch" runat="server" />
               </div>
               <div class="col-sm-6">
                    <asp:Button OnClick="btn_Search_Click" CssClass="btn btn-info" Text="buscar" runat="server"/>
               </div>
           </div>
            <asp:HiddenField ID="hidenId" runat="server" />
            <div class="form-group">
                <label class="col-sm-2"> Nombre</label>
                <div class="col-sm-10">
                    <input type="text" name="nombre" id="txtNombre" runat="server"/>
                </div>
            </div>
            <div class="form-group">
                <label class="col-sm-2"> Asunto</label>
                <div class="col-sm-10">
                    <input type="text" name="asunto" id="txtAsunto" runat="server"/>
                </div>
            </div>
            <div class="form-group">
                <label class="col-sm-2"> Contenido</label>
                <div class="col-sm-10">
                    <input type="text" name="contenido" id="txtContenido" runat="server"/>
                </div>
            </div>            
            <div class="col-sm-10 offset-sm-2">
                <asp:Button CssClass="btn btn-default" runat="server" Text="Guardar"  OnClick="btn_Guardar_Click"/>
            </div>
    </div>
        <div class="row">
            <div class="col-sm-12">
                <table class="table">
                    <thead>
                        <tr>
                            <th>Nombre</th>
                            <th>Asunto</th>
                            <th>Contenido</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater runat="server" ID="tblComentario">
                        <ItemTemplate>
                            <tr data-id="<%#DataBinder.Eval(Container.DataItem, "Id") %>">
                                <td><%#DataBinder.Eval(Container.DataItem, "Nombre") %></td>
                                <td><%#DataBinder.Eval(Container.DataItem, "Asunto") %></td>
                                <td><%#DataBinder.Eval(Container.DataItem, "Content") %></td>
                                <td>
                                    <button class="modificar btn btn-default" type="button">Modificar</button>
                                    <a class="btn btn-danger" href="Comentario.aspx?id=<%#DataBinder.Eval(Container.DataItem, "Id") %>">Eliminar</a>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    </tbody>
                </table>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        $(function () {
            $(".table").on("click", "tr button.modificar", function () {
                var tr = $(this).parents("tr");
                var td = $(tr).find("td");                
                inicializarCampos($(tr).data("id"), $(td[0]).text(), $(td[1]).text(), $(td[2]).text())
            })
        });        

        function inicializarCampos(id,nombre, asunto, contenido) {
            $("#MainContent_hidenId").val(id);
            $("#MainContent_txtNombre").val(nombre);
            $("#MainContent_txtAsunto").val(asunto);
            $("#MainContent_txtContenido").val(contenido);
        }
    </script>
</asp:Content>
