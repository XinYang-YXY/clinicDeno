<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminDashboard_UpcomingAppointment.aspx.cs" Inherits="clinicDeno.AdminDashboard_UpcomingAppointment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Upcoming appointment"></asp:Label>


    <script>
        $(document).ready(function () {
            $(".nav-admin-upcoming").addClass("navigation-opacity-active").removeClass("navigation-opacity");
        })
    </script>
</asp:Content>
