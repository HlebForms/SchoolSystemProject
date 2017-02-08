<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="SchoolSystem.WebForms.Account.Register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <asp:UpdatePanel runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <p class="text-danger">
                <asp:Literal runat="server" ID="ErrorMessage" />
            </p>
            <p class="text-success">
                <asp:Literal runat="server" ID="SuccessMessage" />
            </p>

            <div class="form-horizontal">
                <h4>Добавяне на нов потребител</h4>
                <hr />
                <asp:ValidationSummary runat="server" CssClass="text-danger" />
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
                    <asp:Label runat="server" AssociatedControlID="SubjectDropDown" CssClass="col-md-2 control-label">Предмет</asp:Label>
                    <div class="col-md-10">
                        <asp:DropDownList
                            runat="server"
                            ID="SubjectDropDown"
                            CssClass="form-control"
                            Width="285"
                            DataValueField="Id"
                            DataTextField="Name">
                        </asp:DropDownList>
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
                    </div>
                </div>


                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Email</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                            CssClass="text-danger" ErrorMessage="The email field is required." />
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
                    <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Парола</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                            CssClass="text-danger" ErrorMessage="Моля, въведете парола" />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="col-md-2 control-label">Потвърди паролата</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                            CssClass="text-danger" Display="Dynamic" ErrorMessage="Полето е задължително" />
                        <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                            CssClass="text-danger" Display="Dynamic" ErrorMessage="Паролите не съвпадат" />
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-offset-2 col-md-10">
                        <asp:Button runat="server" OnClick="CreateUser_Click" Text="Регистрация" CssClass="btn btn-primary" />
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
