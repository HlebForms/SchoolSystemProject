<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Notifier.ascx.cs" Inherits="SchoolSystem.WebForms.CustomControls.Notifier.Notifier" %>

<div  runat="server" ID="NotificationPane">
    <button type="button" class="close" data-dismiss="alert">&times;</button>
    <asp:Label ID="NotificationMessage" runat="server"></asp:Label>
</div>
