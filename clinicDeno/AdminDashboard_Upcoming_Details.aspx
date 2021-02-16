<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminDashboard_Upcoming_Details.aspx.cs" Inherits="clinicDeno.AdminDashboard_Upcoming_Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <section class="vertical-middle-landing">
        <div class="box-style box-95 item-center">
            <h2 class="montserrat grey-blue-second medium-font">Request Details</h2>
            <asp:TextBox ID="detailHeader" runat="server" Visible="False">request</asp:TextBox>

            <div class="goBackBtn-layout">
                <asp:Button ID="detailGoBackBtn" runat="server" Text="< Back" class="montserrat rounded-full  y-gap goBackBtn-style" OnClick="detailGoBackBtn_Click" />

            </div>
            <section class="appointmentDetails-layout ">
                <article class="appointmentDetails-info-section-layout">
                    <h3 class="montserrat grey-blue-second medium-font">Appointment Details</h3>
                    <div>
                        <article class="appointmentDetails-info-cell">
                            <p class="appointmentDetails-info-cell-title openSans">Preferred Doctor:</p>
                            <asp:Label ID="appointmentRequestDoctor" runat="server" Text="DR Tan T.P" CssClass="appointmentDetails-info-cell-content openSans"></asp:Label>
                        </article>
                        <article class="appointmentDetails-info-cell">
                            <p class="appointmentDetails-info-cell-title openSans">Preferred Date/Time:</p>
                            <asp:Label ID="appointmentRequestDateTime" runat="server" Text="11 Dec 2020 4pm - 4.30pm" CssClass="appointmentDetails-info-cell-content openSans"></asp:Label>
                        </article>
                    </div>
                </article>

                <article class="appointmentDetails-info-section-layout ">
                    <h3 class="montserrat grey-blue-second medium-font">Patient Particulars</h3>
                    <div>
                        <article class="appointmentDetails-info-cell">
                            <p class="appointmentDetails-info-cell-title openSans">Name:</p>
                            <asp:Label ID="appointmentRequestPatientName" runat="server" Text="Ben Lee" CssClass="appointmentDetails-info-cell-content openSans"></asp:Label>
                        </article>
                        <article class="appointmentDetails-info-cell">
                            <p class="appointmentDetails-info-cell-title openSans">NRIC:</p>
                            <asp:Label ID="appointmentRequestPatientnric" runat="server" Text="T01234567J" CssClass="appointmentDetails-info-cell-content openSans"></asp:Label>
                        </article>
                        <article class="appointmentDetails-info-cell">
                            <p class="appointmentDetails-info-cell-title openSans">Gender:</p>
                            <asp:Label ID="appointmentRequestPatientGender" runat="server" Text="Male" CssClass="appointmentDetails-info-cell-content openSans"></asp:Label>
                        </article>
                        <article class="appointmentDetails-info-cell">
                            <p class="appointmentDetails-info-cell-title openSans">Email:</p>
                            <asp:Label ID="appointmentRequestPatientEmail" runat="server" Text="benlee@gmail.com" CssClass="appointmentDetails-info-cell-content openSans"></asp:Label>
                        </article>
                        <article class="appointmentDetails-info-cell">
                            <p class="appointmentDetails-info-cell-title openSans">Contact Number:</p>
                            <asp:Label ID="appointmentRequestPatientContactNum" runat="server" Text="98352537" CssClass="appointmentDetails-info-cell-content openSans"></asp:Label>
                        </article>
                    </div>
                </article>
                <article>
                </article>
  
            </section>

            <asp:Button ID="upcomingAppointmentSendReminder" runat="server" Text="Send Reminder" class="montserrat rounded-full  y-gap standard-btn btn-standard-width margin-t-16" OnClick="upcomingAppointmentSendReminder_Click"/>

         

        </div>
    </section>


    <script>
        $(document).ready(function () {
               })
    </script>
</asp:Content>
