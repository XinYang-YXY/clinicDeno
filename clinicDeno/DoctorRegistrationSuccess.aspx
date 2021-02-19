<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DoctorRegistrationSuccess.aspx.cs" Inherits="clinicDeno.DoctorRegistrationSuccess" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section class="vertical-middle-landing">
        <div class="box-style box-success item-center">
            <h2 class="montserrat grey-blue-second medium-font">Account Successfully Registered!</h2>
            <div class="layout-inputField">
                <asp:Button ID="goDoctorLoginBtn" runat="server" Text="Login" class="m-auto montserrat rounded-full standard-btn btn-standard-width y-gap" OnClick="goDoctorLoginBtn_Click"/>

            <asp:Button ID="goToHomeBtn" runat="server" Text="Back To Home" class="montserrat rounded-full standard-btn btn-standard-width y-gap" OnClick="goToHomeBtn_Click" />
                </div>
        </div>
    </section>


    <script>
        $(document).ready(function () {
            $(".nav-doctor").addClass("navigation-opacity-active").removeClass("navigation-opacity");
        })
    </script>
</asp:Content>
