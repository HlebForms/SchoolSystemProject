<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CreatingClassOfStudentsControl.ascx.cs" Inherits="SchoolSystem.WebForms.CustomControls.Admin.CreatingClassControl" %>
<h4>Създаване на клас</h4>
<div class="row">
    <div class="form-group">
        <asp:Label runat="server" AssociatedControlID="ClassNameTextBox" CssClass="col-md-2 control-label">Име на класа</asp:Label>
        <div class="col-md-10">
            <asp:TextBox runat="server" ID="ClassNameTextBox" CssClass="form-control" TextMode="SingleLine" />
            <asp:RequiredFieldValidator
                runat="server"
                ControlToValidate="ClassNameTextBox"
                CssClass="text-danger"
                ErrorMessage="Моля въведете име на класа"
                ValidationGroup="CreateClass" />
        </div>
    </div>
    <div class="form-group">
        <asp:Label runat="server" AssociatedControlID="SubjectsList" CssClass="col-md-2 control-label">Предмети на класа</asp:Label>
        <div class="col-md-10 checkbox-scrollbar-container">
            <asp:CheckBoxList
                runat="server"
                ID="SubjectsList"
                CssClass="form-control"
                DataTextField="Name"
                DataValueField="Id"
                Width="200">
            </asp:CheckBoxList>
        </div>
    </div>
    <div class="form-group">
        <div class="col-md-offset-2 col-md-10">
            <asp:Button runat="server" ID="CreateClsasBtn" Text="Създай клас" CssClass="btn btn-primary" OnClick="CreateClsasBtn_Click" ValidationGroup="CreateClass" />
        </div>
    </div>
</div>
