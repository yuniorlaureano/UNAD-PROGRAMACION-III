<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Calculator.aspx.cs" Inherits="Pagina_Maestra.Views.Calculator" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-sm-4">
        <div class="form-group">
            <label>Numero1</label>
            <asp:TextBox ID="number1" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
         <div class="form-group">
            <label>Numero2</label>
            <asp:TextBox ID="number2" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:RadioButton GroupName="opt" ID="radioSuma" Text="Suma" runat="server"/>
            <asp:RadioButton GroupName="opt" ID="radioResta" Text="Resta"  runat="server"/>
            <asp:RadioButton GroupName="opt" ID="radioMultiplicacion" Text="Multiplicacion"  runat="server"/>
            <asp:RadioButton GroupName="opt" ID="radioDivicion" Text="Divicion" runat="server"/>
        </div>
        <div class="well">
            <asp:Label ID="lblReuslt" runat="server"></asp:Label>
        </div>
        <div class="form-group">
            <asp:Button runat="server" CssClass="btn btn-default" Text="Calcular" OnClick="btnCalcular_Click" />
        </div>
    </div>
    <div class="clearfix"></div>
</asp:Content>