<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SchoolSystem.WebForms._Default" %>

<%@ Register Src="~/CustomControls/Home/StudentScheduleControl.ascx" TagPrefix="custom" TagName="StudentScheduleControl" %>
<%@ Register Src="~/CustomControls/Home/NewsfeedControl.ascx" TagPrefix="custom" TagName="NewsfeedControl" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="frame program col-xs-4">
            <custom:StudentScheduleControl runat="server" ID="StudentScheduleControl" />
        </div>
        <div class="frame top-news col-xs-4">IMPORTANT NEWS</div>
        <div class="frame news-feed col-xs-4">
            <custom:NewsfeedControl runat="server" id="NewsfeedControl" />
        </div>

    </div>
</asp:Content>
