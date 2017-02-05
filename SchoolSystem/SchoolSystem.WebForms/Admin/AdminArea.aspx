<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminArea.aspx.cs" Inherits="SchoolSystem.WebForms.Admin.AdminArea" %>

<%@ Register Src="~/CustomControls/Admin/CreatingSubjectControl.ascx" TagPrefix="custom" TagName="CreatingSubjectControl" %>
<%@ Register Src="~/CustomControls/Admin/CreatingClassOfStudentsControl.ascx" TagPrefix="custom" TagName="CreatingClassOfStudentsControl" %>
<%@ Register Src="~/CustomControls/Admin/ManagingScheduleControl.ascx" TagPrefix="custom" TagName="ManagingScheduleControl" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%--  <custom:CreatingSubjectControl runat="server" ID="CreatingSubjectControl" />
    <custom:CreatingClassOfStudentsControl runat="server" ID="CreatingClassOfStudentsControl" />--%>
    <custom:ManagingScheduleControl runat="server" ID="ManagingScheduleControl" />
</asp:Content>
