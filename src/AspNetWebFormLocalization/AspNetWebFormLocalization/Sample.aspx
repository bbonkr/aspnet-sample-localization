<%@ Page Language="C#" Title="지역화 샘플" meta:resourcekey="Sample" UICulture="Auto" AutoEventWireup="true" CodeBehind="Sample.aspx.cs" Inherits="AspNetWebFormLocalization.Sample" MasterPageFile="~/Site.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">

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


    <input type="hidden" id="languageHiddenField" name="lang" />
    <script>
        $(document).ready(function () {
            $('#<%= setLanguageButton.ClientID %>').on('click', function (e) {
                var lang = $('#<%= languageDropDownList.ClientID%>').val();
                $('#languageHiddenField').val(lang);
                $('form').submit();
            });
        });
    </script>
</asp:Content>