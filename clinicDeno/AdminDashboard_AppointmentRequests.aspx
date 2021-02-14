<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminDashboard_AppointmentRequests.aspx.cs" Inherits="clinicDeno.AdminDashboard_AppointmentRequests" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="Label1" runat="server" Text="app requests"></asp:Label>

    <script>
        $(document).ready(function () {
            $(".nav-admin-request").addClass("navigation-opacity-active").removeClass("navigation-opacity");
        })
    </script>
</asp:Content>
