<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DoctorDashboard_Home.aspx.cs" Inherits="clinicDeno.DoctorDashboard_Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section class="vertical-middle-landing">
        <div class="box-style box-adminHome item-center">
            <h2 class="montserrat grey-blue-second medium-font">Services</h2>
            <section class="layout-adminServices adminServices-section-gap">
                <div>
                    <asp:Button ID="AppBtn" runat="server" Text="📅" class="montserrat service-btn" OnClick="AppBtn_Click"/>
                    <p class="montserrat service-name">Upcoming Appointment</p>
                </div>
                <div>
                <asp:Button ID="MRBtn" runat="server" Text="📝" class="montserrat service-btn" OnClick="MRBtn_Click"/>
                    <p class="montserrat service-name">Medical Records</p>
                </div>
            </section>
            </div>
    </section>

    <script>
        $(document).ready(function () {
            $(".nav-admin-home").addClass("navigation-opacity-active").removeClass("navigation-opacity");
        })
    </script>
</asp:Content>
