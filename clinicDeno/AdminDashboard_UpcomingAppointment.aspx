<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminDashboard_UpcomingAppointment.aspx.cs" Inherits="clinicDeno.AdminDashboard_UpcomingAppointment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <section class="vertical-middle-landing">
        <div class="box-style box-95 item-center">
            <h2 class="montserrat grey-blue-second medium-font">Upcoming Appointment</h2>
        </div>
    </section>

    <script>
        $(document).ready(function () {
            $(".nav-admin-upcoming").addClass("navigation-opacity-active").removeClass("navigation-opacity");
        })
    </script>
</asp:Content>
