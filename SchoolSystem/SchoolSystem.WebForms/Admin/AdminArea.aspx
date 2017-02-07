<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminArea.aspx.cs" Inherits="SchoolSystem.WebForms.Admin.AdminArea" %>

<%@ Register Src="~/CustomControls/Admin/CreatingSubjectControl.ascx" TagPrefix="custom" TagName="CreatingSubjectControl" %>
<%@ Register Src="~/CustomControls/Admin/CreatingClassOfStudentsControl.ascx" TagPrefix="custom" TagName="CreatingClassOfStudentsControl" %>
<%@ Register Src="~/CustomControls/Admin/ManagingScheduleControl.ascx" TagPrefix="custom" TagName="ManagingScheduleControl" %>

<%@ Register Assembly="AjaxControlToolkit"
    Namespace="AjaxControlToolkit"
    TagPrefix="ajaxtoolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <ajaxtoolkit:TabContainer runat="server" ID="Container">
        <ajaxtoolkit:TabPanel runat="server" ID="CreatingSubject">
            <HeaderTemplate>Създаване на предмет</HeaderTemplate>
            <ContentTemplate>
                <custom:CreatingSubjectControl runat="server"></custom:CreatingSubjectControl>
            </ContentTemplate>
        </ajaxtoolkit:TabPanel>
          <ajaxtoolkit:TabPanel runat="server" ID="TabPanel1">
            <HeaderTemplate>Създаване на клас</HeaderTemplate>
            <ContentTemplate>
                <custom:CreatingClassOfStudentsControl runat="server"></custom:CreatingClassOfStudentsControl>
            </ContentTemplate>
        </ajaxtoolkit:TabPanel>
          <ajaxtoolkit:TabPanel runat="server" ID="TabPanel2">
            <HeaderTemplate>Промяна по разписанието на класовете</HeaderTemplate>
            <ContentTemplate>
                <custom:ManagingScheduleControl runat="server"></custom:ManagingScheduleControl>
            </ContentTemplate>
        </ajaxtoolkit:TabPanel>
    </ajaxtoolkit:TabContainer>

</asp:Content>
