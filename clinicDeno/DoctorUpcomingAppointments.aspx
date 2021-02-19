<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DoctorUpcomingAppointments.aspx.cs" Inherits="clinicDeno.DoctorUpcomingAppointments" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <section class="vertical-middle-landing">
        <div class="box-style box-95 item-center">
             <asp:Label ID="appointmentActionMsg" runat="server" Text="Reminder sent successfully!" class="alert-ok" Visible="False"></asp:Label>
            <h2 class="montserrat grey-blue-second medium-font">Upcoming Appointment</h2>
             <div class="searchInput-position">
                <asp:TextBox ID="searchPatientNric" runat="server" title="Email" class="standard-inputField  search-input-box " type="search" placeholder="🔍 Search with NRIC"></asp:TextBox>
                <asp:Button ID="appointmentRequestSearchBtn" runat="server" Text="Search" class="montserrat standard-btn " OnClick="appointmentRequestSearchBtn_Click" />
            </div>

            <section id="appointRequestList">
                <article class="rowEntry-layout">
                    <div class="rowEntry-info-layout">
                        <p class="rowEntry-info-title openSans">Name</p>
                        <p class="rowEntry-info-title openSans">Appointment Date</p>
                    </div>
                    <div class="rowEntry-action-layout"></div>
                </article>


            </section>

             <asp:TextBox ID="JSONString" runat="server" Class="html-hidden"></asp:TextBox>
        </div>
    </section>

    <script>
        $(document).ready(function () {
            $(".nav-doctor-upcoming").addClass("navigation-opacity-active").removeClass("navigation-opacity");

            let jsonDataString = $('#<%= JSONString.ClientID %>').val();

            if (jsonDataString != "") {
                if (jsonDataString.charAt(jsonDataString.length - 1) == "|") {
                    jsonDataString = jsonDataString.slice(0, -1);
                }
                let dataArray = jsonDataString.split("|");

                for (let i = 0; i < dataArray.length; i++) {
                    let rowDataArray = dataArray[i].split(",");

                    let entryHtml = ` <article class="rowEntry-layout rowEntry-style">
                    <div class="rowEntry-info-layout">
                        <p class="rowEntry-info-cell openSans">${rowDataArray[1]}</p>
                        <p class="rowEntry-info-cell openSans">${rowDataArray[2]}</p>
                    </div>
                    <div class="rowEntry-action-layout">
                        <a  class="montserrat rounded-full standard-btn btn-standard-width y-gap" runat="server" href="~/DAppointment.aspx?aid=${rowDataArray[0]}">View Details</a>
                    </div>
                </article>`
                    $('#appointRequestList').append(entryHtml);

                }
                console.log(jsonDataString);

            } else {
                let entryHtml = `<h2 class="montserrat grey-blue - second medium - font">No Appointment Requests Found.</h2><h2 class="montserrat grey-blue - second medium - font">Appointments might not be approved by clinic admin yet.</h2>`
                $('#appointRequestList').append(entryHtml);
            }
        })
    </script>

</asp:Content>
