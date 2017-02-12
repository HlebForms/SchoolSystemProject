<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SchoolReportCard.aspx.cs" Inherits="SchoolSystem.WebForms.Student.SchoolReportCard" %>

<%@ Register Src="~/CustomControls/Student/SchoolReportCard.ascx" TagPrefix="custom" TagName="SchoolReportCard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <custom:SchoolReportCard runat="server" id="SchoolReportCard" />
</asp:Content>
