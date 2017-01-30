<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminArea.aspx.cs" Inherits="SchoolSystem.WebForms.Admin.AdminArea" %>

<%@ Register Src="~/CustomControls/Admin/AddingSubjectUserControl.ascx" TagPrefix="spuc" TagName="AddingSubjectUserControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <spuc:AddingSubjectUserControl runat="server" id="AddingSubjectUserControl" />
</asp:Content>
