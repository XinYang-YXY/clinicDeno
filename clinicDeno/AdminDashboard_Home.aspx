<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminDashboard_Home.aspx.cs" Inherits="clinicDeno.AdminDashboard_Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section class="vertical-middle-landing">
        <div class="box-style box-adminHome item-center">
            <h2 class="montserrat grey-blue-second medium-font">Services</h2>
            <section class="layout-adminServices adminServices-section-gap">
                <div>
                    <asp:Button ID="appReqBtn" runat="server" Text="❔" class="montserrat service-btn" OnClick="appReqBtn_Click" />
                    <p class="montserrat service-name">Upcoming Appointments</p>
                </div>
                <div>
                    <asp:Button ID="appUpBtn" runat="server" Text="📅" class="montserrat service-btn" OnClick="appUpBtn_Click"/>
                    <p class="montserrat service-name">Upcoming Appointment</p>
                </div>
                <div>
                <asp:Button ID="appReminderBtn" runat="server" Text="⏰" class="montserrat service-btn" OnClick="appReminderBtn_Click"/>
                    <p class="montserrat service-name">Appoinment Reminder</p>
                </div>
                <div>
                <asp:Button ID="patientRecordBtn" runat="server" Text="📔" class="montserrat service-btn" OnClick="patientRecordBtn_Click"/>
                    <p class="montserrat service-name">Patient's Record</p>

                </div>
                <div>
                <asp:Button ID="medicalInsBtn" runat="server" Text="📝" class="montserrat service-btn" OnClick="medicalInsBtn_Click"/>
                    <p class="montserrat service-name">Medical Instruction</p>

                </div>
            </section>
            </div>
    </section>

    <script>
        $(document).ready(function () {
            $(".nav-admin-home").addClass("navigation-opacity-active").removeClass("navigation-opacity");
        })
    </script>
    </asp:Label></asp:Content>
