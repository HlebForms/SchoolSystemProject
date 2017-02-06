<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PasswordChanger.ascx.cs" Inherits="SchoolSystem.WebForms.CustomControls.Account.PasswordChanger" %>

<h1>Промяна на паролата</h1>
<asp:UpdatePanel runat="server">
    <ContentTemplate>
        <div class="form-horizontal">
            <p class="text-danger">
                <asp:Literal runat="server" ID="ErrorMessage" />
            </p>
            <asp:ValidationSummary runat="server" ShowModelStateErrors="true" CssClass="text-danger" />
            <div class="form-group">
                <asp:Label runat="server" ID="CurrentPasswordLabel" AssociatedControlID="CurrentPassword" CssClass="col-md-2 control-label">Текуща парола</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="CurrentPassword" TextMode="Password" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="CurrentPassword"
                        CssClass="text-danger" ErrorMessage="Моля, въведете текущата парола!"
                        ValidationGroup="ChangePassword" />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" ID="NewPasswordLabel" AssociatedControlID="NewPassword" CssClass="col-md-2 control-label">Нова парола</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="NewPassword" TextMode="Password" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="NewPassword"
                        CssClass="text-danger" ErrorMessage="Моля, въведете новата си парола!"
                        ValidationGroup="ChangePassword" />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" ID="ConfirmNewPasswordLabel" AssociatedControlID="ConfirmNewPassword" CssClass="col-md-2 control-label">Потвъредете новата парола</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="ConfirmNewPassword" TextMode="Password" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmNewPassword"
                        CssClass="text-danger" Display="Dynamic" ErrorMessage="Моля, въведете новата парола отново"
                        ValidationGroup="ChangePassword" />
                    <asp:CompareValidator runat="server" ControlToCompare="NewPassword" ControlToValidate="ConfirmNewPassword"
                        CssClass="text-danger" Display="Dynamic" ErrorMessage="Въведените пароли не съвпадат"
                        ValidationGroup="ChangePassword" />
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-offset-2 col-md-10">
                    <asp:Button runat="server" Text="Промяна на паролата" ID="ChangePassrodBtn" ValidationGroup="ChangePassword" OnClick="ChangePassrodBtn_Click" CssClass="btn btn-default" />
                </div>
            </div>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
