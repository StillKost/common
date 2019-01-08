<%@ Page Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="NetTest.Views.WebForm1" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
    <div class="container">
        <div class="col-md-3" id="box" runat="server">
            TEXT
        </div>
        <div class="col-md-3">
            TEXT
        </div>
        <div class="col-md-3">
            TEXT
        </div>
    </div>
</asp:Content>
