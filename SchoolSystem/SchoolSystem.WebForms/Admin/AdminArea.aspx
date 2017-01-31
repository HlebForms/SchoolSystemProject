<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminArea.aspx.cs" Inherits="SchoolSystem.WebForms.Admin.AdminArea" %>

<%@ Register Src="~/CustomControls/Admin/CreatingSubjectControl.ascx" TagPrefix="spuc" TagName="CreatingSubjectControl" %>
<%@ Register Src="~/CustomControls/Admin/CreatingClassOfStudentsControl.ascx" TagPrefix="spuc" TagName="CreatingClassOfStudentsControl" %>
<%@ Register Src="~/CustomControls/Admin/CreatingScheduleControl.ascx" TagPrefix="spuc" TagName="CreatingScheduleControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <spuc:CreatingSubjectControl runat="server" ID="CreatingSubjectControl" />
    <spuc:CreatingClassOfStudentsControl runat="server" ID="CreatingClassOfStudentsControl" />
    <spuc:CreatingScheduleControl runat="server" ID="CreatingScheduleControl" />
</asp:Content>
