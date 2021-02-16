<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminDashboard_Request_Details.aspx.cs" Inherits="clinicDeno.AdminDashboard_Request_Details" %>

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
                <div class="modal fade bd-example-modal-lg" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
                    <div class="modal-dialog ">
                        <div class="modal-content  box-style box-desktop-600">
                            <h5 class="montserrat grey-blue-second medium-font">Comments</h5>
                            <textarea id="appointmentDetailsAgreeFeedback" class="standard-inputField input-textarea"></textarea>
                            <asp:TextBox ID="appointmentDetailsAgreeFeedBackNET" runat="server"  class="input-white"></asp:TextBox>

                            <asp:Button ID="acceptBtn" runat="server" Text="Accept" class="montserrat rounded-full standard-btn btn-standard-width y-gap ml-auto mr-auto" OnClick="AcceptBtn_Click" />
                        </div>
                    </div>
                </div>

                <div class="modal fade bd-example-modal-sm" tabindex="-1" role="dialog" aria-labelledby="mySmallModalLabel" aria-hidden="true">
                    <div class="modal-dialog">
                        <div class="modal-content  box-style box-desktop-600">
                            <h5 class="montserrat grey-blue-second medium-font">Comments</h5>
                            <textarea id="appointmentDetailsRejectFeedback" class="standard-inputField input-textarea" ></textarea>
                            <asp:TextBox ID="appointmentDetailsRejectFeedBackNET" runat="server" CssClass="input-white" ></asp:TextBox>
                            <asp:Button ID="rejectBtn" runat="server" Text="Reject" class="montserrat rounded-full alert-btn btn-standard-width y-gap ml-auto mr-auto" OnClick="RejectBtn_Click" />
                        </div>
                    </div>
                </div>

            </section>

            <div class="appointmentDetails-btn-layout">
                <!-- Large modal -->
                <button type="button" class="montserrat rounded-full standard-btn  y-gap btn-smaller-width" data-toggle="modal" data-target=".bd-example-modal-lg">Accept</button>
                <!-- Small modal -->
                <button type="button" class="montserrat rounded-full alert-btn  y-gap btn-smaller-width" data-toggle="modal" data-target=".bd-example-modal-sm">Reject</button>
            </div>


        </div>
    </section>


    <script>
        $(document).ready(function () {
            $("#appointmentDetailsAgreeFeedback").keyup(function () {
                let textAreaData = $("#appointmentDetailsAgreeFeedback").val();
                $('#<%= appointmentDetailsAgreeFeedBackNET.ClientID %>').val(textAreaData);
            });

            $("#appointmentDetailsRejectFeedback").keyup(function () {
                let textAreaData = $("#appointmentDetailsRejectFeedback").val();
                $('#<%= appointmentDetailsRejectFeedBackNET.ClientID %>').val(textAreaData);
             });
        })
    </script>
</asp:Content>
