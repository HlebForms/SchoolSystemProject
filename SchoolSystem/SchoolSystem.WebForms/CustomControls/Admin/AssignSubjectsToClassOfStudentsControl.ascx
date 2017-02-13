<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AssignSubjectsToClassOfStudentsControl.ascx.cs" Inherits="SchoolSystem.WebForms.CustomControls.Admin.AssignSubjectsToClassOfStudentsControl" %>
<%@ Register Src="~/CustomControls/Notifier/Notifier.ascx" TagPrefix="custom" TagName="Notifier" %>

<h4>Добави предмети към клас</h4>
<asp:UpdatePanel runat="server">
    <ContentTemplate>
        <custom:Notifier runat="server" ID="Notifier" />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ClassOfStudentsDropDown" CssClass="col-md-2 control-label">Клас</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList
                    runat="server"
                    ID="ClassOfStudentsDropDown"
                    ItemType="SchoolSystem.Data.Models.ClassOfStudents"
                    AutoPostBack="true"
                    DataValueField="Id"
                    DataTextField="Name"
                    CssClass="form-control"
                    Width="285"
                    OnSelectedIndexChanged="ClassOfStudentsDropDown_SelectedIndexChanged" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="" CssClass="col-md-2 control-label">Предмети</asp:Label>
            <div class="col-md-10 checkbox-scrollbar-container">
                <asp:CheckBoxList
                    runat="server"
                    ID="AvailableSubjectsCheckboxList"
                    ItemType="SchoolSystem.Data.Models.CustomModels.SubjectBasicInfo"
                    DataValueField="Id"
                    DataTextField="Name"
                    CssClass="form-control" />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-10">
                <asp:Button
                    ID="AddSubjectsToClassBtn"
                    runat="server"
                    CssClass="btn btn-primary"
                    Text="Добави избраните предмети към класа"
                    OnClick="AddSubjectsToClassBtn_Click" />
            </div>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
