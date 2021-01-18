<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DoctorLogin.aspx.cs" Inherits="clinicDeno.DoctorLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Doctor Login</h1>

    <script>
        $(document).ready(function () {
            $(".nav-doctor").addClass("navigation-opacity-active").removeClass("navigation-opacity");
        })
    </script>
</asp:Content>
