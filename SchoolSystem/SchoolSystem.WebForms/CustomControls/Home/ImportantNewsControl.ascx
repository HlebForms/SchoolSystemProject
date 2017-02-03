<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ImportantNewsControl.ascx.cs" Inherits="SchoolSystem.WebForms.CustomControls.Home.ImportantNewsControl" %>

        <h4 class="importantNews-header-text">Важни новини</h4>
        <div class="importantNews-container">
            <ul class="importantNews-list">
                <asp:Repeater ID="importantNewsList"
                    runat="server"
                    ItemType="SchoolSystem.Data.Models.Newsfeed">
                    <ItemTemplate>
                        <li class="importantNews-list-item">
                            <asp:Image runat="server" CssClass="importantNews-user-avatar" ImageUrl='<%#: Item.User.AvatarPictureUrl %>' ToolTip='<%#: Item.User.UserName %>' />
                            <asp:Label runat="server" CssClass="importantNews-content"> <%#: Item.Content %></asp:Label>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>

