<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="StudentForms.aspx.cs" Inherits="Pagina_Maestra.Views.StudentFormaspx" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="row">
        <div class="panel">
            <div class="panel-body">
                <div class="form-horizontal col-sm-6">
                    <ul>
                        <li style="list-style-type: none;"><asp:Label runat="server" ID="lblNombreValidation" CssClass="text-danger" Visible="false">Nombre requerido</asp:Label></li>
                        <li style="list-style-type: none;"><asp:Label runat="server" ID="lblApellidoValidation" CssClass="text-danger" Visible="false">Apellido requerido</asp:Label></li>
                        <li style="list-style-type: none;"><asp:Label runat="server" ID="lblDireccionValidation" CssClass="text-danger" Visible="false">Direccion requerida</asp:Label></li>
                        <li style="list-style-type: none;"><asp:Label runat="server" ID="lblSexo" CssClass="text-danger" Visible="false">El sexo es requerido</asp:Label></li>
                        <li style="list-style-type: none;"><asp:Label runat="server" ID="lblCedula" CssClass="text-danger" Visible="false">La cedula es requerida</asp:Label></li>
                        <li style="list-style-type: none;"><asp:Label runat="server" ID="lblExperienciaLaboral" CssClass="text-danger" Visible="false">La experiencia laboral</asp:Label></li>
                        <li style="list-style-type: none;"><asp:Label runat="server" ID="lblCarrera" CssClass="text-danger" Visible="false">La carrera es requerida</asp:Label></li>
                    </ul>
                    <div class="form-group">
                        <div class="col-sm-12">
                             <input type="text" class="form-control col-sm-6" runat="server" id="textSearch" />
                            <asp:Button  OnClick="btnBuscarClick" Text="Descargar" CssClass="btn btn-info" value="Descargar" runat="server" />
                            </div>
                        </div>
                    <div class="form-group">
                        <label class="col-sm-2 control-label">Nombre</label>
                        <div class="col-sm-10">
                            <input type="text" runat="server" id="textNombre" class="form-control" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-2 control-label">Apellido</label>
                        <div class="col-sm-10">
                            <input type="text" runat="server" id="textApellido" class="form-control" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-2 control-label">Direccion</label>
                        <div class="col-sm-10">
                            <textarea class="form-control" rows="2" id="textDireccion" runat="server">
                            </textarea>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-2 control-label">Sexo</label>
                        <div class="col-sm-10">
                            <select type="text" runat="server" id="textSexo" class="form-control">
                                <option value="M">M</option>
                                <option value="F">F</option>
                            </select>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-2 control-label">Cedula</label>
                        <div class="col-sm-10">
                           <input type="text" runat="server" id="textCedula"  class="form-control" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-2 control-label">Experiencia Laboral</label>
                        <div class="col-sm-10">
                            <input type="text" runat="server" id="textExperienciaLaboral" class="form-control" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-2 control-label">Carrera</label>
                        <div class="col-sm-10">
                            <input type="text" runat="server" id="textCarrera" class="form-control"/>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-6 control-label">Acepta los terminos <input type="checkbox" runat="server" id="checkTerminos" /></label>
                        <div class="col-sm-6">

                        </div>
                        </div>
                    <div class="form-group">
                        <div class="col-sm-offset-2 col-sm-10">
                            <asp:Button  OnClick="btnGuardarClick" Text="Guardar" CssClass="btn btn-default" value="Guardar" runat="server" id="btnGuardar" />
                            <asp:Button  OnClick="btnBorrarClick" Text="Borrar" CssClass="btn btn-default" value="Borrar" runat="server" id="btnBurrar" />
                            <asp:Button  OnClick="btnDouwnloadClick" Text="Descargar" CssClass="btn btn-default" value="Descargar" runat="server" id="btnDescargar" />
                        </div>
                    </div>
                </div>
                <div class="col-sm-6">
                <table class="table table-bordered">
                    <tr>
                        <th>Nombre</th>
                        <th>Apellido</th>
                        <th>Direccion</th>
                        <th>Sexo</th>
                        <th>Cedula</th>
                        <th>Experiencia laboral</th>
                        <th>Carrera</th>
                    </tr>
                    <asp:Repeater runat="server" ID="tblStudents">
                        <ItemTemplate>
                            <tr>
                                <td><%#DataBinder.Eval(Container.DataItem, "Name") %></td>
                                <td><%#DataBinder.Eval(Container.DataItem, "Apellido") %></td>
                                <td><%#DataBinder.Eval(Container.DataItem, "Direccion") %></td>
                                <td><%#DataBinder.Eval(Container.DataItem, "Sexo") %></td>
                                <td><%#DataBinder.Eval(Container.DataItem, "Cedula") %></td>
                                <td><%#DataBinder.Eval(Container.DataItem, "ExperienciaLaboral") %></td>
                                <td><%#DataBinder.Eval(Container.DataItem, "Carrera") %></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
            </div>
            
        </div>
    </div>
</asp:Content>