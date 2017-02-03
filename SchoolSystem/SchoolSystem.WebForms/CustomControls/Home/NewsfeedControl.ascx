<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewsfeedControl.ascx.cs" Inherits="SchoolSystem.WebForms.CustomControls.Home.NewsfeedControl" %>
<asp:UpdatePanel ID="updatePanel" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
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
                    ItemType="SchoolSystem.Data.Models.Newsfeed">
                    <ItemTemplate>
                        <li class="comment-list-item">
                            <asp:Image runat="server" CssClass="comment-user-avatar" ImageUrl='<%#: Item.User.AvatarPictureUrl %>' ToolTip='<%#: Item.User.UserName %>' />
                            <asp:Label runat="server" CssClass="comment-content"> <%#: Item.Content %></asp:Label>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
