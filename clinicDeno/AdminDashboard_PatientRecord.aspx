<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminDashboard_PatientRecord.aspx.cs" Inherits="clinicDeno.AdminDashboard_PatientRecord" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <section class="vertical-middle-landing">
        <div class="box-style box-95 item-center">
            <h2 class="montserrat grey-blue-second medium-font">Patient Record</h2>
        </div>
    </section>
    <script>
        $(document).ready(function () {
            $(".nav-admin-record").addClass("navigation-opacity-active").removeClass("navigation-opacity");
        })
    </script>
</asp:Content>
