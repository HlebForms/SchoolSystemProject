<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SchoolSystem.WebForms._Default" %>

<%@ Register Src="~/CustomControls/Home/StudentScheduleControl.ascx" TagPrefix="custom" TagName="StudentScheduleControl" %>
<%@ Register Src="~/CustomControls/Home/NewsfeedControl.ascx" TagPrefix="custom" TagName="NewsfeedControl" %>
<%@ Register Src="~/CustomControls/Home/ImportantNewsControl.ascx" TagPrefix="custom" TagName="ImportantNewsControl" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="frame program col-xs-4">
            <custom:StudentScheduleControl runat="server" ID="StudentScheduleControl" />
        </div>
        <asp:UpdatePanel ID="updatePanelImportant" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="frame top-news col-xs-4">
                    <custom:ImportantNewsControl runat="server" ID="ImportantNewsControl" />
                </div>
                <div class="frame news-feed col-xs-4">
                    <custom:NewsfeedControl runat="server" ID="NewsfeedControl" />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>

