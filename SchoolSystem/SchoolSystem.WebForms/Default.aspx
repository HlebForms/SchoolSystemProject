<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" ValidateRequest="false" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SchoolSystem.WebForms._Default" %>

<%@ Register Src="~/CustomControls/Home/StudentScheduleControl.ascx" TagPrefix="custom" TagName="StudentScheduleControl" %>
<%@ Register Src="~/CustomControls/Home/NewsfeedControl.ascx" TagPrefix="custom" TagName="NewsfeedControl" %>
<%@ Register Src="~/CustomControls/Account/LoginControl.ascx" TagPrefix="custom" TagName="LoginControl" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="frame program col-xs-4">
            <asp:LoginView runat="server" ID="LoginView" ViewStateMode="Disabled">

                <AnonymousTemplate>
                    <custom:LoginControl runat="server" id="LoginControl" />
                </AnonymousTemplate>

                <LoggedInTemplate>
                    <custom:StudentScheduleControl runat="server" ID="StudentScheduleControl" />
                </LoggedInTemplate>

            </asp:LoginView>
        </div>
        <asp:UpdatePanel ID="updatePanelImportant" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <custom:NewsfeedControl runat="server" ID="NewsfeedControl" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>

