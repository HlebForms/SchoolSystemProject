<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AvatarUploadControl.ascx.cs" Inherits="SchoolSystem.WebForms.CustomControls.Account.AvatarUploadControl" %>


<div class="form-group">
    <div class="col-md-10">
        <asp:Image Width="200" Height="200" runat="server" ID="UserAvatar" />
    </div>

    <asp:FileUpload ID="AvatarUpload" runat="server" CssClass="upload-button" />
    <asp:Label AssociatedControlID="AvatarUpload" runat="server" CssClass="upload-button-modified btn btn-warning">
        Избери аватар
    </asp:Label>
    <asp:Button ID="UploadAvatarBtn"
        runat="server"
        OnClick="UploadAvatarBtn_Click"
        Text="Качи"
        CssClass="btn btn-primary" />
    <asp:Label runat="server" ID="StatusLabel" Text="Upload status: " />
</div>
