<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ClinicRegistration.aspx.cs" Inherits="clinicDeno.ClinicRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section class="vertical-middle-landing">
        <div class="box-style box-desktop-600 item-center">
            <h2 class="montserrat grey-blue-second medium-font">Clinic Registration</h2>


            <section class="layout-inputField input-section-gap">
                <div class="inputHeader-row">
                    <p class="montserrat grey-blue-second bold-font">* All fields are required</p>
                </div>
                <div>
                <asp:TextBox ID="ClinicName" runat="server"  class="standard-inputField" type="text" placeholder="Clinic Name" required="true"/></asp:TextBox>

                </div>

                <asp:TextBox ID="ClinicTypeNET" runat="server" Class="html-hidden"></asp:TextBox>
                <select id="ClinicType" class="standard-inputField" required>
                    <option value="" disabled selected class="">Clinic Type</option>
                    <option value="general" class="standard-inputField" data-value="general">General</option>
                    <option value="dentist" class="standard-inputField" data-value="dentist">Dentist</option>
                </select>
                <asp:TextBox ID="ClinicEmail" runat="server" class="standard-inputField" type="email" placeholder="Clinic Email" required="true"></asp:TextBox>
                <asp:TextBox ID="ClinicNum" runat="server" class="standard-inputField" type="tel" placeholder="+65 Phone Number" required="true"></asp:TextBox>
            </section>

            <section class="layout-inputField input-section-gap">
                <div class="inputHeader-row">
                    <p class="montserrat grey-blue-second medium-font font-size-13">Operating Hours</p>
                </div>
                <asp:TextBox ID="ClinicStartTime" runat="server" title="Start Time"  class="standard-inputField" type="time" placeholder="Start Time" required="true"></asp:TextBox>
                <asp:TextBox ID="ClinicEndTime" runat="server" title="End Time" class="standard-inputField" type="time" placeholder="End Time" required="true"></asp:TextBox>
            </section>
            
            <section class="layout-inputField input-section-gap">
                <div class="inputHeader-row">
                    <p class="montserrat grey-blue-second medium-font font-size-13">Address</p>
                </div>
                <asp:TextBox ID="ClinicAddressNET" runat="server" Class="html-hidden"></asp:TextBox>
                 <textarea  id="ClinicAddress"  class="standard-inputField input-textarea" required></textarea>
            </section>
           <%-- <input type="submit"  value="Clinic Registration" class="montserrat rounded-full standard-btn btn-standard-width y-gap"/>--%>
            <asp:Button ID="ClinicRegistrationBtn" runat="server" Text="Clinic Registration"  class="montserrat rounded-full standard-btn btn-standard-width y-gap " OnClick="ClinicRegistrationBtn_Click" />

        </div>
    </section>
    <script>

        $(document).ready(function () {
            $("#ClinicAddress").keyup(function () {
                let textAreaData = $("#ClinicAddress").val();
                $('#<%= ClinicAddressNET.ClientID %>').val(textAreaData);
            });

            $("select#ClinicType").change(function () {
                let optionSelected = $("select#ClinicType").find(':selected').data('value');
                console.log(optionSelected)
                $('#<%= ClinicTypeNET.ClientID %>').val(optionSelected);
            });

            $(".nav-clinic").addClass("navigation-opacity-active").removeClass("navigation-opacity");
        })
    </script>
</asp:Content>
