<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="clinicDeno.AdminLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <section class="vertical-middle-landing">
        <div class="box-style box-mobile-400 item-center">
            <asp:Label ID="loginMsg" runat="server" Text="" class="alert " Visible="False"></asp:Label>
            <h2 class="montserrat grey-blue-second medium-font">Administrator Login</h2>
            <section class="layout-inputField mb-3 mt-5">
                <div class="inputHeader-row">
                    <asp:TextBox ID="ClinicAdminLoginEmail" runat="server" title="Email" class="standard-inputField w-100" type="email" placeholder="Email" required="true"></asp:TextBox>
                </div>
                <div class="inputHeader-row">
                    <asp:TextBox ID="ClinicAdminLoginPassword" runat="server" title="Password" class="standard-inputField w-100" type="password" placeholder="Password" required="true"></asp:TextBox>
                </div>
                <div class="inputHeader-row">
                    <asp:Button ID="clinicAdminLoginBtn" runat="server" Text="Login" class="montserrat rounded-full standard-btn btn-standard-width y-gap w-100" OnClick="clinicAdminLoginBtn_Click" />
                </div>
            </section>
            <a class="form-redirection-text montserrat" runat="server" href="~/AdminRegistration.aspx">Register an account -></a>
        </div>
    </section>

    <script>
        $(document).ready(function () {
            $(".nav-admin").addClass("navigation-opacity-active").removeClass("navigation-opacity");
        })
    </script>
</asp:Content>
