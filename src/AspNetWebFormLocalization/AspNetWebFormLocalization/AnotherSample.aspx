<%@ Page Title="다른 페이지" meta:resourcekey="anotherSample" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AnotherSample.aspx.cs" Inherits="AspNetWebFormLocalization.AnotherSample" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div class="page-header">
        <h1><%: Title %></h1>
    </div>

    <div class="row">
        <div class="col col-xs-12">
            <div class="form-group">
                <asp:Label runat="server" meta:resourcekey="languageLabel" AssociatedControlID="languageDropDownList" Text="언어" />
                <asp:DropDownList runat="server" ID="languageDropDownList" CssClass="form-control" />
            </div>
            <asp:Button runat="server" ID="setLanguageButton" meta:resourcekey="setLanguageButton" Text="설정" CssClass="btn btn-default" />
        </div>
    </div>
    <div class="row">
        <div class="col col-xs-12">
            <div class="form-group">
                <asp:Label runat="server" meta:resourcekey="lastNameLabel" AssociatedControlID="lastNameTextBox" Text="성" />
                <asp:TextBox runat="server" ID="lastNameTextBox" CssClass="form-control" />
            </div>
            <div class="form-group">
                <asp:Label runat="server" meta:resourcekey="firstNameLabel" AssociatedControlID="firstNameTextBox" Text="이름" />
                <asp:TextBox runat="server" ID="firstNameTextBox" CssClass="form-control" />
            </div>

            <asp:Button runat="server" ID="saveButton" meta:resourcekey="saveButton" Text="저장" CssClass="btn btn-primary" />
        </div>
    </div>
</asp:Content>
