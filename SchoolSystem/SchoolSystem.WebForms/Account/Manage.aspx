<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="SchoolSystem.WebForms.Account.Manage" %>

<%@ Register Src="~/CustomControls/Account/AvatarUploadControl.ascx" TagPrefix="custom" TagName="AvatarUploadControl" %>
<%@ Register Src="~/CustomControls/Account/PasswordChanger.ascx" TagPrefix="custom" TagName="PasswordChanger" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%--<custom:AvatarUploadControl runat="server" id="AvatarUploadControl" />--%>
    <custom:PasswordChanger runat="server" id="PasswordChanger" />
</asp:Content>
