<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AvatarUploadControl.ascx.cs" Inherits="SchoolSystem.WebForms.CustomControls.Account.AvatarUploadControl" %>


<div class="form-group">
    <asp:Label runat="server" ID="Label1" Text="Текущ аватар" />
    <div class="col-md-10">
        <asp:Image Width="200" Height="200" runat="server" ID="UserAvatar" />
    </div>
</div>

<div class="form-gorup">
    <asp:FileUpload ID="AvatarUpload" runat="server" CssClass="btn btn-primary" />
    <asp:Button ID="UploadAvatarBtn"
        runat="server"
        OnClick="UploadAvatarBtn_Click"
        Text="Качи"
        CssClass="btn btn-default btn-sm" />
    <asp:Label runat="server" ID="StatusLabel" Text="Upload status: " />
</div>
