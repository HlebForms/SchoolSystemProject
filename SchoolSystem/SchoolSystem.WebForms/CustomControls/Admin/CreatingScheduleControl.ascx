<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CreatingScheduleControl.ascx.cs" Inherits="SchoolSystem.WebForms.CustomControls.Admin.CreateScheduleControl" %>

<div class="form-group">
    <asp:Label runat="server" AssociatedControlID="ClassOfStudentsDropDown" CssClass="col-md-2 control-label">Клас</asp:Label>
    <div class="col-md-10">
        <asp:DropDownList
            runat="server"
            ID="ClassOfStudentsDropDown"
            DataValueField="Id"
            DataTextField="Name"
            CssClass="form-control"
            Width="150">
        </asp:DropDownList>
    </div>
</div>

<div class="form-group">
    <div class="col-md-10">
        <asp:GridView ID="GridView1"
            runat="server">
        </asp:GridView>
    </div>
</div>
