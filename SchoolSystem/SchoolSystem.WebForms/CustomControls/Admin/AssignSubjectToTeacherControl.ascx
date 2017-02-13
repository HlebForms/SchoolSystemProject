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
                    AutoPostBack="true"
                    DataValueField="Id"
                    DataTextField="Fullname"
                    CssClass="form-control"
                    Width="285"
                    OnSelectedIndexChanged="TeacherDropDown_SelectedIndexChanged" />
            </div>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
