<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminRegistrationSuccess.aspx.cs" Inherits="clinicDeno.AdminRegistrationSuccess" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section class="vertical-middle-landing">
        <div class="box-style box-success item-center">
            <h2 class="montserrat grey-blue-second medium-font">Account Successfully Registered!</h2>
            <p class="openSans w-75 mx-auto mb-5 dark-text">
                A verification email has been sent to the email that is used to register the clinic. Your email needs to be verified before you can login to your account.
            </p>
            <div class="layout-inputField">
                <asp:Button ID="goAdminLoginBtn" runat="server" Text="Login" class="m-auto montserrat rounded-full standard-btn btn-standard-width y-gap" OnClick="goAdminLoginBtn_Click"/>

            <asp:Button ID="goToHomeBtn" runat="server" Text="Back To Home" class="montserrat rounded-full standard-btn btn-standard-width y-gap" OnClick="goBackHomeBtn_Click" />
                </div>
        </div>
    </section>


    <script>
        $(document).ready(function () {
            $(".nav-admin").addClass("navigation-opacity-active").removeClass("navigation-opacity");
        })
    </script>
</asp:Content>
