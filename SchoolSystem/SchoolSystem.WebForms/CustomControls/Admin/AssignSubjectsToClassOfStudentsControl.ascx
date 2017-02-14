<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AssignSubjectsToClassOfStudentsControl.ascx.cs" Inherits="SchoolSystem.WebForms.CustomControls.Admin.AssignSubjectsToClassOfStudentsControl" %>
<%@ Register Src="~/CustomControls/Notifier/Notifier.ascx" TagPrefix="custom" TagName="Notifier" %>

<h4 class="add-subject-header">Добави предмети към клас</h4>
<asp:UpdatePanel runat="server">
    <ContentTemplate>
        <custom:Notifier runat="server" ID="Notifier" />
        <div>
            <asp:Label runat="server" AssociatedControlID="ClassOfStudentsDropDown" CssClass="dropdown-label">Клас</asp:Label>
                <asp:DropDownList
                    runat="server"
                    ID="ClassOfStudentsDropDown"
                    ItemType="SchoolSystem.Data.Models.ClassOfStudents"
                    AutoPostBack="true"
                    DataValueField="Id"
                    DataTextField="Name"
                    CssClass="class-of-students-dropdown"
                    OnSelectedIndexChanged="ClassOfStudentsDropDown_SelectedIndexChanged" />
            </div>
        </div>
        <div >
            <asp:Label runat="server" AssociatedControlID="" CssClass="dropdown-label">Предмети</asp:Label>
            <div class="checkbox-scrollbar-container">
                <asp:CheckBoxList
                    runat="server"
                    ID="AvailableSubjectsCheckboxList"
                    ItemType="SchoolSystem.Data.Models.CustomModels.SubjectBasicInfo"
                    DataValueField="Id"
                    DataTextField="Name"/>
            </div>
        </div>
        <div class="add-subject-button">
            <asp:Button
                ID="AddSubjectsToClassBtn"
                runat="server"
                CssClass="btn btn-success"
                Text="Добави избраните предмети към класа"
                OnClick="AddSubjectsToClassBtn_Click" />
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
