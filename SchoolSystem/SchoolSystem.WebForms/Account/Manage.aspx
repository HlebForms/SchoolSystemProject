<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="SchoolSystem.WebForms.Account.Manage" %>

<%@ Register Src="~/CustomControls/Account/AvatarUploadControl.ascx" TagPrefix="custom" TagName="AvatarUploadControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <custom:AvatarUploadControl runat="server" id="AvatarUploadControl" />
</asp:Content>
