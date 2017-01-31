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

        <asp:UpdatePanel runat="server" ID="test" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:DropDownList
                    ID="DaysOfWeekDropDown"
                    runat="server"
                    AutoPostBack="true"
                    OnSelectedIndexChanged="DaysOfWeekDropDown_SelectedIndexChanged"
                    CssClass="form-control"
                    Width="250">
                    <asp:ListItem Text="Monday" Value="Monday" />
                    <asp:ListItem Text="Tuesday" Value="Tuesday" />
                    <asp:ListItem Text="Wednesday" Value="Wednesday" />
                    <asp:ListItem Text="Thursday" Value="Thursday" />
                    <asp:ListItem Text="Friday" Value="Friday" />
                </asp:DropDownList>

                <asp:GridView
                    ID="GridView1"
                    runat="server"
                    AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="SubjName" HeaderText="Име" />
                        <asp:BoundField DataField="StartHour" HeaderText="Начало" />
                        <asp:BoundField DataField="EndHour" HeaderText="Край" />
                        <asp:CommandField ShowEditButton="True" />
                    </Columns>
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>

    </div>
</div>
