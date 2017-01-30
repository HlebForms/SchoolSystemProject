<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SchoolSystem.WebForms._Default" %>

<%@ Register Src="~/CustomControls/Home/StudentScheduleControl.ascx" TagPrefix="custom" TagName="StudentScheduleControl" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <custom:StudentScheduleControl runat="server" id="StudentScheduleControl" />
        <div class="frame top-news col-xs-4">IMPORTANT NEWS</div>
        <div class="frame news-feed col-xs-4">NEWS FEED</div>

    </div>
</asp:Content>
