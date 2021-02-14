<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminDashboard_PatientRecord.aspx.cs" Inherits="clinicDeno.AdminDashboard_PatientRecord" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="Label1" runat="server" Text="patientRecord"></asp:Label>

    <script>
        $(document).ready(function () {
            $(".nav-admin-record").addClass("navigation-opacity-active").removeClass("navigation-opacity");
        })
    </script>
</asp:Content>
