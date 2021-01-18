<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ClinicRegistrationSuccess.aspx.cs" Inherits="clinicDeno.ClinicRegistrationSuccess" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <section class="vertical-middle-landing">
        <div class="box-style box-success item-center">
            <h2 class="montserrat grey-blue-second medium-font">Clinic Successfully Registered!</h2>
            <p class="openSans w-50 mx-auto mb-5 dark-text">You can now add doctor and administrator accounts to your clinic</p>
            <div class="layout-inputField">
                <asp:Button ID="addDoctorBtn" runat="server" Text="Add Doctor" class="m-auto montserrat rounded-full standard-btn btn-standard-width y-gap" OnClick="addDoctorBtn_Click"/>
                <asp:Button ID="addAdminBtn" runat="server" Text="Add Administrator" class="m-auto montserrat rounded-full standard-btn btn-standard-width y-gap" OnClick="addAdminBtn_Click"/>
            </div>
            <p class="montserrat grey-blue-second mt-3">- OR -</p>
            <asp:Button ID="goToHomeBtn" runat="server" Text="Back To Home" class="montserrat rounded-full standard-btn btn-standard-width y-gap" OnClick="goBackHomeBtn_Click"/>
        </div>
    </section>

    
    <script>
        $(document).ready(function () {
            $(".nav-clinic").addClass("navigation-opacity-active").removeClass("navigation-opacity");
        })
    </script>
</asp:Content>
