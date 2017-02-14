<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="SchoolSystem.WebForms.Account.Register" %>

<%@ Register Src="~/CustomControls/Notifier/Notifier.ascx" TagPrefix="custom" TagName="Notifier" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <asp:UpdatePanel runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="form-horizontal">
                <h4>Добавяне на нов потребител</h4>
                <hr />

                <custom:Notifier runat="server" ID="Notifier" />

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="UserTypeDropDown" CssClass="col-md-2 control-label">Тип на потребителя</asp:Label>
                    <div class="col-md-10">
                        <asp:DropDownList
                            runat="server"
                            ID="UserTypeDropDown"
                            CssClass="form-control"
                            Width="285"
                            DataValueField="Id"
                            DataTextField="Name"
                            OnSelectedIndexChanged="UserTypeDropDown_SelectedIndexChanged"
                            AutoPostBack="true">
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="form-group" runat="server" id="SubjectContainer">
                    <asp:Label runat="server" AssociatedControlID="AvailableSubjectsList" CssClass="col-md-2 control-label">Свободни предмети</asp:Label>
                    <div class="col-md-10 checkbox-scrollbar-container">
                        <asp:CheckBoxList
                            ID="AvailableSubjectsList"
                            runat="server"
                            DataValueField="Id"
                            DataTextField="Name"
                            With="285">
                        </asp:CheckBoxList>
                    </div>
                </div>

                <div class="form-group" runat="server" id="ClassContainer">
                    <asp:Label runat="server" AssociatedControlID="ClassDropDown" CssClass="col-md-2 control-label">Клас</asp:Label>
                    <div class="col-md-10">
                        <asp:DropDownList
                            runat="server"
                            ID="ClassDropDown"
                            CssClass="form-control"
                            Width="285"
                            DataValueField="Id"
                            DataTextField="Name">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="ClassDropDown"
                            CssClass="text-danger" ErrorMessage="Моля изберете класът, в който ще е ученикът" />
                    </div>
                </div>


                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Email</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                            CssClass="text-danger" ErrorMessage="Имейлът е задължтелен" />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="FirstNameTextBox" CssClass="col-md-2 control-label">Име</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="FirstNameTextBox" CssClass="form-control" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="FirstNameTextBox"
                            CssClass="text-danger" ErrorMessage="Името не е валидно" />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="LastNameTextBox" CssClass="col-md-2 control-label">Фамилия</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="LastNameTextBox" CssClass="form-control" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="LastNameTextBox"
                            CssClass="text-danger" ErrorMessage="Името не е валидно" />
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-offset-2 col-md-10">
                        <asp:Button runat="server" OnClick="CreateUser_Click" Text="Регистрация" CssClass="btn btn-success" />
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
