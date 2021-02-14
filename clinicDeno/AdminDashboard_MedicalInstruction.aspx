<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminDashboard_MedicalInstruction.aspx.cs" Inherits="clinicDeno.AdminDashboard_MedicalInstruction" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="Label1" runat="server" Text="medical instruction"></asp:Label>

    <script>
        $(document).ready(function () {
            $(".nav-admin-medIns").addClass("navigation-opacity-active").removeClass("navigation-opacity");
        })
    </script>
</asp:Content>
