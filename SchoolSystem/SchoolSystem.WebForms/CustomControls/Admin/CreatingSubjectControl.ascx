<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CreatingSubjectControl.ascx.cs" Inherits="SchoolSystem.WebForms.CustomControls.Admin.AddingSubjectUserControl" %>

<asp:TextBox runat="server" ID="SubjectNameTextBox"> </asp:TextBox>
<asp:Button  
    runat="server" 
    Text="Създай предмет"
    ID="AddSubjectBtn" 
    OnClick="AddSubjectBtn_Click"/>