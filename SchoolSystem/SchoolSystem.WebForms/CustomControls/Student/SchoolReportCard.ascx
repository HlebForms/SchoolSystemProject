<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SchoolReportCard.ascx.cs" Inherits="SchoolSystem.WebForms.CustomControls.Student.SchoolReportCard" %>

<asp:UpdatePanel runat="server">
    <ContentTemplate>
        <div class="container">
            <h4>Моят бележник</h4>
            <asp:GridView
                runat="server"
                ID="ScoolReportCardGrid"
                AutoGenerateColumns="false"
                ItemType="SchoolSystem.Data.Models.CustomModels.StudentMarksModel"
                AllowSorting="true"
                OnSorting="ScoolReportCardGrid_Sorting"
                CssClass="table table-striped table-hover student-marks-table"
                CurrentSortDir="ASC"
                CurrentSortField="DESC">
                <Columns>
                    <asp:TemplateField HeaderText="Име на предмета" SortExpression="ByName" HeaderStyle-CssClass="student-marks-table-header">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%#: Item.SubjectName %>'> </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Оценки" HeaderStyle-CssClass="student-marks-table-header">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%#: string.Join(" ", Item.Marks) %>'> </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Среден Успех" SortExpression="ByAverage" HeaderStyle-CssClass="student-marks-table-header">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%#: string.Format("{0:F2}",Item.Average) %>'> </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
