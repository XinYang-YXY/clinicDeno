<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ClinicRegistration.aspx.cs" Inherits="clinicDeno.ClinicRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section class="vertical-middle-landing">
        <div class="box-style box-desktop-600 item-center">
            <h2 class="montserrat grey-blue-second medium-font">Clinic Registration</h2>


            <section class="layout-inputField input-section-gap">
                <div class="inputHeader-row">
                    <p class="montserrat grey-blue-second bold-font">* All fields are required</p>
                </div>
                <input id="ClinicName" class="standard-inputField" type="text" placeholder="Clinic Name" required/>
                <select class="standard-inputField" required>
                    <option value="" disabled selected class="">Clinic Type</option>
                    <option value="general" class="standard-inputField">General</option>
                    <option value="dentist" class="standard-inputField">Dentist</option>
                </select>
                <input id="ClinicEmail" class="standard-inputField" type="email" placeholder="Clinic Email" required/>
                <input id="ClinicNum" class="standard-inputField" type="tel" placeholder="+65 Phone Number" required/>
            </section>

            <section class="layout-inputField input-section-gap">
                <div class="inputHeader-row">
                    <p class="montserrat grey-blue-second medium-font font-size-13">Operating Hours</p>
                </div>
                <input title="Start Time" id="ClinicStartTime" class="standard-inputField" type="time" placeholder="Start Time" required/>

                <input title="End Time" id="ClinicEndTime" class="standard-inputField" type="time" placeholder="End Time" required/>
            </section>
            
            <section class="layout-inputField input-section-gap">
                <div class="inputHeader-row">
                    <p class="montserrat grey-blue-second medium-font font-size-13">Address</p>
                </div>
                <textarea class="standard-inputField input-textarea" required></textarea>
            </section>

            <input type="submit"  value="Clinic Registration" class="montserrat rounded-full standard-btn btn-standard-width y-gap"/>

        </div>
    </section>
</asp:Content>
