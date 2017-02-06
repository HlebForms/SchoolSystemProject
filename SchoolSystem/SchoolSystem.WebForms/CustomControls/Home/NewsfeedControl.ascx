<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewsfeedControl.ascx.cs" Inherits="SchoolSystem.WebForms.CustomControls.Home.NewsfeedControl" %>
<div class="frame top-news col-xs-4">
    <h4 class="importantNews-header-text">Важни новини</h4>
    <div class="importantNews-container">
        <ul class="importantNews-list">
            <asp:Repeater ID="ImportantNewsList"
                runat="server"
                ItemType="SchoolSystem.Data.Models.CustomModels.NewsModel">
                <ItemTemplate>
                    <li class="importantNews-list-item">
                        <asp:Image runat="server" CssClass="importantNews-user-avatar" ImageUrl='<%#: Item.AvatarPictureUrl %>' ToolTip='<%#: Item.Creator %>' />
                        <asp:Label runat="server" CssClass="importantNews-content"> <%#: Item.Content %></asp:Label>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
</div>
<div class="frame news-feed col-xs-4">
    <asp:LoginView runat="server" ID="LoginView" ViewStateMode="Disabled">

        <AnonymousTemplate>
            <h5 class="newsfeed-header-text">Трябва да сте логнат в системата, за да напишете новина!</h5>
        </AnonymousTemplate>

        <LoggedInTemplate>
            <h5 class="newsfeed-header-text">Добави коментар</h5>
            <asp:TextBox TextMode="MultiLine" Rows="3" MaxLength="200" placeholder="Максимум 200 символа..." ID="AddTextbox" CssClass="comment-box" runat="server"></asp:TextBox>
            <asp:Button ID="AddComment" OnClick="AddComment_Click" runat="server" Text="Добави" />

        </LoggedInTemplate>

    </asp:LoginView>

    <hr class="comments-hr" />

    <div class="comments-container">
        <ul class="comments-list">
            <asp:Repeater ID="CommentsList"
                runat="server"
                ItemType="SchoolSystem.Data.Models.CustomModels.NewsModel">
                <ItemTemplate>
                    <li class="comment-list-item">
                        <asp:Image runat="server" CssClass="comment-user-avatar" ImageUrl='<%#: Item.AvatarPictureUrl %>' ToolTip='<%#: Item.Creator %>' />
                        <asp:Label runat="server" CssClass="comment-content"> <%#: Item.Content %></asp:Label>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
</div>
