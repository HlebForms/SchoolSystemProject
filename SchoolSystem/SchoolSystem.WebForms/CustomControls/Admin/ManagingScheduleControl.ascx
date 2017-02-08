<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ManagingScheduleControl.ascx.cs" Inherits="SchoolSystem.WebForms.CustomControls.Admin.CreateScheduleControl" %>

<h4>Менажиране на програма</h4>
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
                    OnSelectedIndexChanged="DaysOfWeekDropDown_SelectedIndexChanged"
                    CssClass="form-control"
                    Width="250">
                </asp:DropDownList>
            </div>
        </div>
        <div class="form-group">

            <asp:ListView
                runat="server"
                ID="ScheduleList"
                ItemType="SchoolSystem.Data.Models.CustomModels.ManagingScheduleModel"
                OnItemCommand="ScheduleList_ItemCommand"
                InsertItemPosition="LastItem"
                OnItemDeleting="ScheduleList_ItemDeleting"
                OnItemInserting="ScheduleList_ItemInserting">
                <InsertItemTemplate>
                    <tr>
                        <td>
                            <asp:Button ID="InsertBtn"
                                runat="server"
                                CommandName="Insert"
                                CssClass="btn btn-success btn-sm"
                                Text="Добави" />
                        </td>
                        <td>
                            <asp:DropDownList ID="AddingSubjectDropDown" runat="server"
                                CssClass="form-control"
                                SelectMethod="PopulateSubjects"
                                DataTextField="Name"
                                DataValueField="Id">
                                <asp:ListItem Selected="True">Моля изберете предмет</asp:ListItem>
                            </asp:DropDownList>

                        </td>
                        <td>
                            <asp:DropDownList ID="StartHourDropDown" runat="server"
                                CssClass="form-control">
                                <asp:ListItem>7</asp:ListItem>
                                <asp:ListItem>8</asp:ListItem>
                                <asp:ListItem>9</asp:ListItem>
                                <asp:ListItem>10</asp:ListItem>
                                <asp:ListItem>11</asp:ListItem>
                                <asp:ListItem>12</asp:ListItem>
                                <asp:ListItem>13</asp:ListItem>
                                <asp:ListItem>14</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:DropDownList ID="EndHourDropDown" runat="server"
                                CssClass="form-control">
                                <asp:ListItem>7</asp:ListItem>
                                <asp:ListItem>8</asp:ListItem>
                                <asp:ListItem>9</asp:ListItem>
                                <asp:ListItem>10</asp:ListItem>
                                <asp:ListItem>11</asp:ListItem>
                                <asp:ListItem>12</asp:ListItem>
                                <asp:ListItem>13</asp:ListItem>
                                <asp:ListItem>14</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                </InsertItemTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:LinkButton ID="Delete"
                                runat="server"
                                CssClass="btn btn-danger btn-sm"
                                CommandName="Delete"
                                Text="Изтрий"
                                CommandArgument='<%#: Item.Subject.Id %>' />
                        </td>
                        <td runat="server" id="subjName"><%#: Item.Subject.Name %></td>
                        <td><%#: Item.StartHour.Hour %></td>
                        <td><%#: Item.EndHour.Hour %></td>
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
                    <table runat="server" class="table table-striped table-hover">
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
