<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="StudentScheduleControl.ascx.cs" Inherits="SchoolSystem.WebForms.CustomControls.Home.StudentScheduleControl" %>

<h4>Програма за деня</h4>

<div class="schedule-container">
    <ul class="schedule-list">
        <asp:Repeater ID="schedule"
            runat="server"
            ItemType="SchoolSystem.Data.Models.CustomModels.StudentSchedule">
            <ItemTemplate>
                <li class="schedule-list-item">
                    <asp:Image ToolTip="<%#: Item.SubjectName %>" ImageUrl='<%#:Item.ImageUrl %>' runat="server" CssClass="subject-image" />
                    <div class="time">
                        <div class="start-hour"><span>От:</span> <span><%#: Item.StartHour.ToString("H:mm") %></span></div>
                        <div class="end-hour"><span>До:</span> <span><%#: Item.EndHour.ToString("H:mm") %></span></div>
                    </div>
                    <div class="subject-info">
                        <div>Учител</div>
                        <div class="teacher-name"><%#: Item.TeacherName %></div>
                    </div>
                </li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
</div>


