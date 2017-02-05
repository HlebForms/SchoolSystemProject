<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AvatarUploadControl.ascx.cs" Inherits="SchoolSystem.WebForms.CustomControls.Account.AvatarUploadControl" %>

<asp:FileUpload ID="AvatarUpload" runat="server" />
<asp:Button ID="UploadAvatarBtn"
    runat="server"
    OnClick="UploadAvatarBtn_Click"
    Text="Качи"
    CssClass="btn btn-default btn-sm" />
<asp:Label runat="server" ID="StatusLabel" Text="Upload status: " />
