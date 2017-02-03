<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="StudentScheduleControl.ascx.cs" Inherits="SchoolSystem.WebForms.CustomControls.Home.StudentScheduleControl" %>

<h4>Програма за деня</h4>

<asp:ListView ID="schedule" runat="server"
    ItemType="SchoolSystem.Data.Models.CustomModels.StudentSchedule">
    <LayoutTemplate>
        <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
    </LayoutTemplate>

    <ItemSeparatorTemplate>
        <hr />
    </ItemSeparatorTemplate>

    <ItemTemplate>
        <div class="program-items">
            <div class="program-item">
                <asp:Image ToolTip="<%#: Item.SubjectName %>" ImageUrl='<%#: "~/Images/subject_images/subject" + Item.SubjectId + ".png"  %>' runat="server" CssClass="subject-image" />
                <div class="time">
                    <div class="start-hour"><span>От:</span> <span><%#: Item.StartHour.ToString("H:mm:ss") %></span></div>
                    <div class="end-hour"><span>До:</span> <span><%#: Item.EndHour.ToString("H:mm:ss") %></span></div>
                </div>
                <div class="subject-info">
                    <div>Учител:</div>
                    <div class="teacher-name"><%#: Item.TeacherName %></div>
                </div>
            </div>
        </div>
    </ItemTemplate>
</asp:ListView>

