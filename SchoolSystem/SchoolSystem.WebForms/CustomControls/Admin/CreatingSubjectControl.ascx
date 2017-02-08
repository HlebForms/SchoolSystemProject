<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CreatingSubjectControl.ascx.cs" Inherits="SchoolSystem.WebForms.CustomControls.Admin.AddingSubjectUserControl" %>
<%@ Register Src="~/CustomControls/Notifier/Notifier.ascx" TagPrefix="uc1" TagName="Notifier" %>

<asp:UpdatePanel runat="server">
    <ContentTemplate>
        <h4>Cъздаване на предмет</h4>
        <uc1:Notifier runat="server" ID="Notifier" />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="SubjectNameTextBox" CssClass="col-md-2 control-label">Име на предмета</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="SubjectNameTextBox" CssClass="form-control"> </asp:TextBox>
                <br />
                <asp:Button
                    runat="server"
                    Text="Създай предмет"
                    ID="AddSubjectBtn"
                    CssClass="btn btn-primary"
                    OnClick="AddSubjectBtn_Click" />
            </div>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
