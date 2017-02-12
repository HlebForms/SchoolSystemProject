<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SchoolReportCard.ascx.cs" Inherits="SchoolSystem.WebForms.CustomControls.Student.SchoolReportCard" %>

<asp:UpdatePanel runat="server">
    <ContentTemplate>
        <asp:GridView
            runat="server"
            ID="ScoolReportCardGrid"
            AutoGenerateColumns="false"
            ItemType="SchoolSystem.Data.Models.CustomModels.StudentMarks"
            AllowSorting="true"
            OnSorting="ScoolReportCardGrid_Sorting">
            <Columns>
                <asp:TemplateField HeaderText="Име на предмета" SortExpression="ByName">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%#: Item.SubjectName %>'> </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Оценки">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%#: string.Join(" ", Item.Marks) %>'> </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Среден Успех" SortExpression="ByAverage">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%#: string.Format("{0:F2}",Item.Average) %>'> </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </ContentTemplate>
</asp:UpdatePanel>
