<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ManagingMarksControl.ascx.cs" Inherits="SchoolSystem.WebForms.CustomControls.Teacher.AdddingMarksControl" %>

<h4>Teache area</h4>
<asp:UpdatePanel runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="SubjectsDropDown" CssClass="col-md-2 control-label">Премет</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList
                    runat="server"
                    ID="SubjectsDropDown"
                    DataValueField="Id"
                    DataTextField="Name"
                    AutoPostBack="true"
                    CssClass="form-control"
                    OnSelectedIndexChanged="SubjectsDropDown_SelectedIndexChanged"
                    Width="150">
                </asp:DropDownList>
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ClassOfStudentsDropDown" CssClass="col-md-2 control-label">Клас</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList
                    ID="ClassOfStudentsDropDown"
                    runat="server"
                    AutoPostBack="true"
                    DataTextField="Name"
                    DataValueField="Id"
                    CssClass="form-control"
                    OnSelectedIndexChanged="ClassOfStudentsDropDown_SelectedIndexChanged"
                    Width="250">
                </asp:DropDownList>
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-10">
                <asp:ListView runat="server" ID="SchoolReportCardListView"
                    ItemType="SchoolSystem.Data.Models.CustomModels.SchoolReportCard"
                    InsertItemPosition="LastItem"
                    OnItemInserting="SchoolReportCardListView_ItemInserting"
                    OnItemCommand="SchoolReportCardListView_ItemCommand">
                    <LayoutTemplate>
                        <table>
                            <tr>
                                <th>Име</th>
                                <th>Фамилия</th>
                                <th>Оценки</th>
                            </tr>
                            <tr id="itemPlaceholder" runat="server">
                            </tr>
                        </table>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr>
                            <td><%#: Item.FirstName %></td>
                            <td><%#: Item.LastName %></td>
                            <td><%#: string.Join(", ",Item.Grades )%></td>
                        </tr>
                    </ItemTemplate>
                    <InsertItemTemplate>
                        <tr>
                            <td>
                                <asp:DropDownList
                                    ID="StudentsDropDown"
                                    runat="server"
                                    ItemType="SchoolSystem.Data.Models.CustomModels.StudentInfo"
                                    DataValueField="Id"
                                    DataTextField="FullName"
                                    SelectMethod="PopulateStudentsDropDown"
                                    Visible="true"
                                    CssClass="form-control">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:DropDownList
                                    ID="MarksDropDown"
                                    runat="server"
                                    SelectMethod="PopulateMarksDropDown"
                                    DataValueField="Id"
                                    DataTextField="Name"
                                    Visible="true"
                                    CssClass="form-control">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Button
                                    runat="server"
                                    ID="InsertBtn"
                                    CommandName="Insert"
                                    Text="Добави оценка"
                                    CssClass="btn btn-small btn-primary" />
                            </td>
                        </tr>
                    </InsertItemTemplate>
                    <EmptyDataTemplate>
                        <h4>Няма въведени оценки по съответната дисциплина!</h4>
                    </EmptyDataTemplate>
                </asp:ListView>
            </div>
    </ContentTemplate>
</asp:UpdatePanel>
