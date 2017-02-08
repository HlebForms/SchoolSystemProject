<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="SchoolSystem.WebForms.Account.Manage" %>

<%@ Register Src="~/CustomControls/Account/AvatarUploadControl.ascx" TagPrefix="custom" TagName="AvatarUploadControl" %>
<%@ Register Src="~/CustomControls/Account/PasswordChanger.ascx" TagPrefix="custom" TagName="PasswordChanger" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Button Text="Смяна на аватар" BorderStyle="None" ID="Tab1" CssClass="btn btn-default" runat="server"
        OnClick="Tab1_Click" />

    <asp:Button Text="Промяна на парола" BorderStyle="None" ID="Tab2" CssClass="btn btn-default" runat="server"
        OnClick="Tab2_Click" />


    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View runat="server" ID="UploadAvatarView">
            <custom:AvatarUploadControl runat="server" ID="AvatarUploadControl" />
        </asp:View>
        <asp:View runat="server" ID="ChangePasswordView">
            <custom:PasswordChanger runat="server" ID="PasswordChanger" />
        </asp:View>
    </asp:MultiView>

</asp:Content>
