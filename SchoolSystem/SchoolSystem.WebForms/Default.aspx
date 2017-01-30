<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SchoolSystem.WebForms._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">

        <div class="frame program col-xs-4">
          <h4> Програма за деня</h4>

          <asp:ListView ID="schedule" runat="server"
              ItemType="SchoolSystem.Data.Models.SubjectClassOfStudentsDaysOfWeek">
              <LayoutTemplate>
                  <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
              </LayoutTemplate>

              <ItemSeparatorTemplate>
                  <hr />
              </ItemSeparatorTemplate>

              <ItemTemplate>
                  <div class="program-items">
                      <div class="program-item">
                          <asp:Image ToolTip="pesho" ImageUrl='<%#: "~/Images/subject_images/subject" + Item.SubjectId + ".png"  %>' runat="server" CssClass="subject-image" />
                          <div class="time">
                              <div class="start-hour"><span>От:</span> <span><%#: Item.StartHour.ToString("H:mm:ss") %></span></div>
                              <div class="end-hour"><span>До:</span> <span><%#: Item.EndHour.ToString("H:mm:ss") %></span></div>
                          </div>
                          <div class="subject-info">
                              <div>Учител:</div>
                              <div class="teacher-name"><%#: Item.SubjectId %></div>
                          </div>
                      </div>
                  </div>
              </ItemTemplate>
          </asp:ListView>

        </div>
        <div class="frame top-news col-xs-4">IMPORTANT NEWS</div>
        <div class="frame news-feed col-xs-4">NEWS FEED</div>

    </div>
</asp:Content>
