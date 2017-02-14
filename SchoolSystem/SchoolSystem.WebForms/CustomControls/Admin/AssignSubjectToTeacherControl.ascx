<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AssignSubjectToTeacherControl.ascx.cs" Inherits="SchoolSystem.WebForms.CustomControls.Admin.AssignSubjectToTeacherControl" %>
<%@ Register Src="~/CustomControls/Notifier/Notifier.ascx" TagPrefix="custom" TagName="Notifier" %>


<asp:UpdatePanel runat="server">
    <ContentTemplate>
        <custom:Notifier runat="server" ID="Notifier" />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="TeacherDropDown" CssClass="col-md-2 control-label">Учител</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList
                    runat="server"
                    ID="TeacherDropDown"
                    ItemType="SchoolSystem.Data.Models.CustomModels.TeacherBasicInfo"
                    DataValueField="Id"
                    DataTextField="Fullname"
                    CssClass="form-control"
                    Width="285"
                    OnSelectedIndexChanged="TeacherDropDown_SelectedIndexChanged" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="SubjectsWithoutTeacherCheboxList" CssClass="col-md-2 control-label">Учител</asp:Label>
            <div class="col-md-10">
                <asp:CheckBoxList
                    runat="server"
                    ID="SubjectsWithoutTeacherCheboxList"
                    ItemType="SchoolSystem.Data.Models.CustomModels.SubjectBasicInfo"
                    DataValueField="Id"
                    DataTextField="Name"
                    CssClass="form-control"
                    Width="285" />
            </div>
        </div>
        <div>
            <asp:Button ID="AssignSubjectsToTeacherBtn"
                runat="server"
                OnClick="AssignSubjectsToTeacherBtn_Click"
                Text="Добави предметите" 
                CssClass="btn btn-success"/>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
