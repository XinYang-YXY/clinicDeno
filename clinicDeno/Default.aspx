<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="clinicDeno._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <section class="vertical-middle-landing">
        <div class="box-style box-mobile item-center">
            <h2 class="montserrat grey-blue-second medium-font">I am ...</h2>
            <asp:Button ID="doctorBtn" runat="server" Text="Doctor" class="montserrat rounded-full standard-btn btn-standard-width y-gap" OnClick="doctorBtn_Click"/>
            <asp:Button ID="adminBtn" runat="server" Text="Administrator" class="montserrat rounded-full standard-btn btn-standard-width y-gap" OnClick="adminBtn_Click"/>
            <p class="montserrat grey-blue-second margin-t-16">- OR -</p>
            <asp:Button ID="clinicBtn" runat="server" Text="Clinic Registration" class="montserrat rounded-full standard-btn btn-standard-width y-gap" OnClick="clinicBtn_Click"/>
        </div>
    </section>

    <script>
        $(document).ready(function () {
            $(".nav-home").addClass("navigation-opacity-active").removeClass("navigation-opacity");
        })
    </script>

</asp:Content>
