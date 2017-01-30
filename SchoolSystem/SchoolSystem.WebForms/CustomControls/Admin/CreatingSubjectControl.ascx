<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CreatingSubjectControl.ascx.cs" Inherits="SchoolSystem.WebForms.CustomControls.Admin.AddingSubjectUserControl" %>

<div class="form-group">
    <asp:Label runat="server" AssociatedControlID="SubjectNameTextBox" CssClass="col-md-2 control-label">Име на предмета</asp:Label>
    <div class="col-md-10">
        <asp:TextBox runat="server" ID="SubjectNameTextBox" CssClass="form-control"> </asp:TextBox>
        <asp:Button
            runat="server"
            Text="Създай предмет"
            ID="AddSubjectBtn"
            CssClass="btn btn-default"
            OnClick="AddSubjectBtn_Click" />
    </div>
</div>
