<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminDashboard_AppointmentReminder.aspx.cs" Inherits="clinicDeno.AdminDashboard_AppointmentReminder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="Label1" runat="server" Text="App reminder"></asp:Label>

    <script>
        $(document).ready(function () {
            $(".nav-admin-reminder").addClass("navigation-opacity-active").removeClass("navigation-opacity");
        })
    </script>
</asp:Content>
