<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DAppointment.aspx.cs" Inherits="clinicDeno.DAppointment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section class="vertical-middle-landing">
        <div class="box-style box-desktop-950 item-center">
            <h2 class="montserrat grey-blue-second medium-font">Appointment Details</h2>

            <asp:Panel ID="appointInfo" runat="server" class="record-inputFieldAppointment input-section-gap">
                <div>
                    <p class="montserrat grey-blue-second bold-font font-size-11">Appointment Details</p>
                    <div class="record-inputFieldDetails">
                        <asp:PlaceHolder 
                        ID="AppDetails"
                        runat="server"
                        >
                        </asp:PlaceHolder>
                    </div>
                </div>

                <div class="inputHeader-second">
                    <p class="montserrat grey-blue-second bold-font font-size-11">Patient Particulars</p>
                    <div class="record-inputFieldDetails">
                        <asp:PlaceHolder 
                        ID="AppPatient"
                        runat="server"
                        >
                        </asp:PlaceHolder>
                    </div>
                    <asp:Button ID="RecordsBtn" runat="server" Text="Get medical records"  class="montserrat rounded-full standard-btn btn-standard-width y-gap" OnClick="RecordsBtn_Click"/>
                </div>
            </asp:Panel>

            <asp:Panel ID="paperworkBtns" runat="server" class="appoint-paperBtns">
                <asp:Button ID="createRecordBtn" runat="server" Text="Create medical record"  class="montserrat rounded-full orange-btn btn-standard-width y-gap" OnClick="createRecordBtn_Click"/>
                <asp:Button ID="instructBtn" runat="server" Text="Send medical instruction"  class="montserrat rounded-full orange-btn btn-standard-width y-gap" OnClick="instructBtn_Click"/>
                <asp:Button ID="MCBtn" runat="server" Text="Generate MC"  class="montserrat rounded-full orange-btn btn-standard-width y-gap" OnClick="MCBtn_Click"/>
            </asp:Panel>

        </div>
    </section>
</asp:Content>
