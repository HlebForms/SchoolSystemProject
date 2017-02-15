<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AssignSubjectToTeacherControl.ascx.cs" Inherits="SchoolSystem.WebForms.CustomControls.Admin.AssignSubjectToTeacherControl" %>
<%@ Register Src="~/CustomControls/Notifier/Notifier.ascx" TagPrefix="custom" TagName="Notifier" %>

<h4 class="add-subject-header">Добави предмети към Учител</h4>
<asp:UpdatePanel runat="server">
    <ContentTemplate>
        <custom:Notifier runat="server" ID="Notifier" />
        <div>
            <asp:Label runat="server" AssociatedControlID="TeacherDropDown" CssClass="dropdown-label">Учител</asp:Label>
            <asp:DropDownList
                runat="server"
                ID="TeacherDropDown"
                ItemType="SchoolSystem.Data.Models.CustomModels.TeacherBasicInfo"
                DataValueField="Id"
                DataTextField="Fullname"
                CssClass="class-of-students-dropdown"
                OnSelectedIndexChanged="TeacherDropDown_SelectedIndexChanged" />
        </div>
        <div>
            <asp:Label runat="server" AssociatedControlID="SubjectsWithoutTeacherCheboxList" CssClass="dropdown-label">Предмети</asp:Label>
            <div class="checkbox-scrollbar-container-teacher">
                <asp:CheckBoxList
                    runat="server"
                    ID="SubjectsWithoutTeacherCheboxList"
                    ItemType="SchoolSystem.Data.Models.CustomModels.SubjectBasicInfo"
                    DataValueField="Id"
                    DataTextField="Name" />
            </div>
        </div>
        <div class="add-subject-button-teacher">
            <asp:Button ID="AssignSubjectsToTeacherBtn"
                runat="server"
                OnClick="AssignSubjectsToTeacherBtn_Click"
                Text="Добави предметите"
                CssClass="btn btn-success" />
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
