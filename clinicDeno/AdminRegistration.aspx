<%@ Page  Async="true"  Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminRegistration.aspx.cs" Inherits="clinicDeno.AdminRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <section class="vertical-middle-landing">
        <div class="box-style box-desktop-600 item-center">
            <h2 class="montserrat grey-blue-second medium-font">Administrator Registration</h2>


            <section class="layout-inputField input-section-gap">
                <div class="inputHeader-row">
                    <p class="montserrat grey-blue-second bold-font">* All fields are required</p>
                </div>
                <asp:TextBox ID="AdminFirstName" runat="server" class="standard-inputField" type="text" placeholder="First Name" required="true" /></asp:TextBox>

                <%--                <asp:TextBox ID="ClinicTypeNET" runat="server" Class="html-hidden"></asp:TextBox>
                <select id="ClinicType" class="standard-inputField" required>
                    <option value="" disabled selected class="">Clinic Type</option>
                    <option value="general" class="standard-inputField" data-value="general">General</option>
                    <option value="dentist" class="standard-inputField" data-value="dentist">Dentist</option>
                </select>--%>
                <asp:TextBox ID="AdminLastName" runat="server" class="standard-inputField" type="text" placeholder="Last Name" required="true"></asp:TextBox>
            </section>

            <section class="layout-inputField input-section-gap">
                <div class="inputHeader-row">
                    <p class="montserrat grey-blue-second medium-font font-size-13">Date of Birth</p>
                </div>
                <asp:TextBox ID="AdminDOB" runat="server" title="Date of Birth" class="standard-inputField" type="date" placeholder="Start Time" required="true"></asp:TextBox>

                <asp:TextBox ID="AdminGenderNET" runat="server" Class="html-hidden"></asp:TextBox>
                <select id="AdminGender" class="standard-inputField" required>
                    <option value="" disabled selected class="">Gender</option>
                    <option value="male" class="standard-inputField" data-value="male">Male</option>
                    <option value="female" class="standard-inputField" data-value="female">Female</option>
                </select>
                

                <asp:TextBox ID="AdminPhoneNum" runat="server" class="standard-inputField" type="tel" placeholder="+65 " required="true" /></asp:TextBox>
                    <asp:TextBox ID="ExistingClinicNET" runat="server" Class="html-hidden"></asp:TextBox>
                    <asp:TextBox ID="SelectedClinicNET" runat="server" Class="html-hidden"></asp:TextBox>
                    <select id="ExistingClinic" class="standard-inputField w-100" required>
                        <option value="" disabled selected class="">Select Clinic</option>
                        <%-- <option value="male" class="standard-inputField" data-value="male">Male</option>
                        <option value="female" class="standard-inputField" data-value="female">Female</option>--%>
                    </select>
                <asp:TextBox ID="AdminEmail" runat="server" class="standard-inputField" type="email" placeholder="Email" required="true" /></asp:TextBox>
                <asp:TextBox ID="AdminPassword" runat="server" class="standard-inputField" type="password" placeholder="Password" required="true" /></asp:TextBox>
            </section>


            <asp:Button ID="AdminRegistrationBtn" runat="server" Text="Administrator Registration" class="montserrat rounded-full standard-btn btn-standard-width y-gap" OnClick="ClinicRegistrationBtn_Click" />

            <a class="form-redirection-text montserrat" runat="server" href="~/AdminLogin.aspx">Already have an account? Login -></a>

        </div>
    </section>
    <script>
        $(document).ready(function () {
            let clinicNameStr = $('#<%= ExistingClinicNET.ClientID %>').val();

            let clinicNameList = clinicNameStr.split(",")
            //$('#ExistingClinic').html(clinicList);
            for (let i = 0; i < clinicNameList.length - 1; i++) {
                let clinicHtml = `<option value = '${clinicNameList[i]}' class='standard-inputField' data-value='${clinicNameList[i]}'>${clinicNameList[i]}</option>`
                $('#ExistingClinic').append(clinicHtml)
                console.log(clinicNameList[i])
            }

            $("#AdminGender").change(function () {
                let genderData = $("#AdminGender").val();
                $('#<%= AdminGenderNET.ClientID %>').val(genderData);
            });

            $("select#ExistingClinic").change(function () {
                let optionSelected = $("select#ExistingClinic").find(':selected').data('value');
                                $('#<%= SelectedClinicNET.ClientID %>').val(optionSelected);
            });
            
            $(".nav-admin").addClass("navigation-opacity-active").removeClass("navigation-opacity");
        })

    </script>
</asp:Content>
