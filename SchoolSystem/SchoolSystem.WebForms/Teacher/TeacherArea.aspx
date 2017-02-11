<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TeacherArea.aspx.cs" Inherits="SchoolSystem.WebForms.Teacher.TeacherArea" %>

<%@ Register Src="~/CustomControls/Teacher/ManagingMarksControl.ascx" TagPrefix="uc1" TagName="ManagingMarksControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:ManagingMarksControl runat="server" id="AdddingMarksControl" />
</asp:Content>
