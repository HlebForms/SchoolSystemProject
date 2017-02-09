<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AvatarUploadControl.ascx.cs" Inherits="SchoolSystem.WebForms.CustomControls.Account.AvatarUploadControl" %>
<%@ Register Src="~/CustomControls/Notifier/Notifier.ascx" TagPrefix="uc1" TagName="Notifier" %>


<uc1:Notifier runat="server" ID="Notifier" />
<asp:UpdatePanel runat="server">
    <ContentTemplate>
        <div class="form-group">
            <div class="col-md-10">
                <asp:Image Width="200" Height="200" runat="server" ID="UserAvatar" />
            </div>

            <asp:FileUpload ID="AvatarUpload" runat="server" CssClass="upload-button" AllowMultiple="true" />
            <asp:Label AssociatedControlID="AvatarUpload" runat="server" CssClass="upload-button-modified btn btn-warning">
        Избери аватар
            </asp:Label>
            <asp:Button ID="UploadAvatarBtn"
                runat="server"
                OnClick="UploadAvatarBtn_Click"
                Text="Качи"
                CssClass="btn btn-primary" />
        </div>
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="UploadAvatarBtn" />
    </Triggers>
</asp:UpdatePanel>

