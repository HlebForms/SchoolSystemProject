<%@ Page Title="Log in" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SchoolSystem.WebForms.Account.Login" Async="true" %>

<%@ Register Src="~/CustomControls/Account/LoginControl.ascx" TagPrefix="custom" TagName="LoginControl" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <custom:LoginControl runat="server" ID="LoginControl" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>


