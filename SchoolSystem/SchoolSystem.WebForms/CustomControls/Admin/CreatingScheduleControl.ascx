<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CreatingScheduleControl.ascx.cs" Inherits="SchoolSystem.WebForms.CustomControls.Admin.CreateScheduleControl" %>


<asp:UpdatePanel runat="server" ID="test" UpdateMode="Conditional">
    <ContentTemplate>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ClassOfStudentsDropDown" CssClass="col-md-2 control-label">Клас</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList
                    runat="server"
                    ID="ClassOfStudentsDropDown"
                    DataValueField="Id"
                    DataTextField="Name"
                    OnSelectedIndexChanged="DaysOfWeekDropDown_SelectedIndexChanged"
                    AutoPostBack="true"
                    CssClass="form-control"
                    Width="150">
                </asp:DropDownList>
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="DaysOfWeekDropDown" CssClass="col-md-2 control-label">Ден ог седмицата</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList
                    ID="DaysOfWeekDropDown"
                    runat="server"
                    AutoPostBack="true"
                    DataTextField="Name"
                    DataValueField="Id"
                    SelectMethod="PopulateDaysOfWeek"
                    ItemType="SchoolSystem.Data.Models.DaysOfWeek"
                    OnSelectedIndexChanged="DaysOfWeekDropDown_SelectedIndexChanged"
                    CssClass="form-control"
                    Width="250">
                </asp:DropDownList>
            </div>
        </div>
        <div class="form-group">

            <asp:ListView runat="server" ID="ScheduleList"
                ItemType="SchoolSystem.WebForms.CustomControls.Admin.Models.Test"
                UpdateMethod="ScheduleList_UpdateItem"
                SelectMethod="ScheduleList_GetData"
                InsertMethod="ScheduleList_InsertItem"
                InsertItemPosition="LastItem"
                DataKeyNames="Id">
                <InsertItemTemplate>
                    <tr>
                        <td>
                            <asp:Button ID="InsertBtn" runat="server"
                                CommandName="Insert" Text="Insert" />
                        </td>
                        <td>
                            <asp:DropDownList ID="dd" runat="server">
                                <asp:ListItem>1</asp:ListItem>
                                <asp:ListItem>2</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBox3" runat="server"
                                Text='<%# BindItem.StartHour %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="TextBox4" runat="server"
                                Text='<%# BindItem.EndHour %>' />
                        </td>
                    </tr>
                </InsertItemTemplate>
                <EditItemTemplate>
                    <tr>
                        <td>
                            <asp:Button ID="UpdateButton" runat="server"
                                CommandName="Update" Text="Update" />
                            <asp:Button ID="CancelButton" runat="server"
                                CommandName="Cancel" Text="Cancel" />
                        </td>
                        <td>
                            <asp:TextBox ID="TextBox5" runat="server" Text='<%# BindItem.SubjName %>'></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# BindItem.StartHour %>'></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# BindItem.EndHour %>'></asp:TextBox>
                        </td>
                    </tr>
                </EditItemTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:Button ID="EditButton" runat="server"
                                CommandName="Edit" Text="Edit" />
                        </td>
                        <td><%#: Item.SubjName %></td>
                        <td><%#: Item.StartHour %></td>
                        <td><%#: Item.EndHour %></td>
                    </tr>
                </ItemTemplate>
                <EmptyDataTemplate>
                    <table runat="server">
                        <tr>
                            <td>No data was returned.</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <LayoutTemplate>
                    <table runat="server">
                        <tr runat="server">
                            <td runat="server">
                                <table id="itemPlaceholderContainer" runat="server">
                                    <tr runat="server">
                                        <th runat="server"></th>
                                        <th runat="server">Име на предмета</th>
                                        <th runat="server">Начален час</th>
                                        <th runat="server">Краен час</th>
                                    </tr>
                                    <tr id="itemPlaceholder" runat="server">
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr runat="server">
                            <td runat="server" style="text-align: center; background-color: #CCCCCC; font-family: Verdana, Arial, Helvetica, sans-serif; color: #000000;"></td>
                        </tr>
                    </table>
                </LayoutTemplate>
            </asp:ListView>

        </div>


    </ContentTemplate>


</asp:UpdatePanel>


