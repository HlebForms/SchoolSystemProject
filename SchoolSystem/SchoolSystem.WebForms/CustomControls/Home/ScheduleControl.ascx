<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ScheduleControl.ascx.cs" Inherits="SchoolSystem.WebForms.CustomControls.Home.ScheduleControl" %>

<h4>Програма за деня</h4>

<div class="schedule-container">
    <ul class="schedule-list">
        <asp:Repeater ID="Schedule"
            runat="server"
            ItemType="SchoolSystem.Data.Models.CustomModels.ScheduleModel">
            <ItemTemplate>
                <li class="schedule-list-item">
                    <asp:Image ToolTip="<%#: Item.SubjectName %>" ImageUrl='<%#:Item.ImageUrl %>' runat="server" CssClass="subject-image" />
                    <div class="time">
                        <div class="start-hour"><span>От:</span> <span><%#: Item.StartHour.ToString("H:mm") %></span></div>
                        <div class="end-hour"><span>До:</span> <span><%#: Item.EndHour.ToString("H:mm") %></span></div>
                    </div>

                    <asp:Panel CssClass="subject-info" runat="server" ID="TeacherName">
                        <div><%#: this.Page.User.IsInRole("Teacher")? "Клас" : "Преподавател" %></div>
                        <div class="teacher-name"><%#: this.Page.User.IsInRole("Teacher")? Item.ClassName : Item.TeacherName %></div>
                    </asp:Panel>
                </li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
</div>


