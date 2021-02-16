<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminDashboard_MedicalInstruction.aspx.cs" Inherits="clinicDeno.AdminDashboard_MedicalInstruction" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <section class="vertical-middle-landing">
        <div class="box-style box-95 item-center">
            <h2 class="montserrat grey-blue-second medium-font">Medical Instruction</h2>
        </div>
    </section>
    <script>
        $(document).ready(function () {
            $(".nav-admin-medIns").addClass("navigation-opacity-active").removeClass("navigation-opacity");
        })
    </script>
</asp:Content>
