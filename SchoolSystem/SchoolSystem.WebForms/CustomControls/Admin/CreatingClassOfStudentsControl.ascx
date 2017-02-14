<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CreatingClassOfStudentsControl.ascx.cs" Inherits="SchoolSystem.WebForms.CustomControls.Admin.CreatingClassControl" %>
<%@ Register Src="~/CustomControls/Notifier/Notifier.ascx" TagPrefix="uc1" TagName="Notifier" %>

<h4 class="add-subject-header">Създаване на клас</h4>


<uc1:Notifier runat="server" ID="Notifier" />

<div>
    <asp:Label runat="server" AssociatedControlID="ClassNameTextBox" CssClass="dropdown-label">Име на класа</asp:Label>
    <asp:TextBox runat="server" ID="ClassNameTextBox" CssClass="class-of-students-dropdown" TextMode="SingleLine" />
    <asp:RequiredFieldValidator
        runat="server"
        ControlToValidate="ClassNameTextBox"
        CssClass="text-danger"
        ErrorMessage="Моля въведете име на класа"
        ValidationGroup="CreateClass" />
</div>
<div>
    <asp:Label runat="server" AssociatedControlID="SubjectsList" CssClass="dropdown-label">Предмети на класа</asp:Label>
    <div class="checkbox-scrollbar-container-subjects">
        <asp:CheckBoxList
            runat="server"
            ID="SubjectsList"
            DataTextField="Name"
            DataValueField="Id">
        </asp:CheckBoxList>
    </div>
</div>
<div class="add-class-button">
    <asp:Button runat="server" ID="CreateClsasBtn" Text="Създай клас" CssClass="btn btn-success" OnClick="CreateClsasBtn_Click" ValidationGroup="CreateClass" />
</div>

