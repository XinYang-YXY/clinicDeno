<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MedicalRecordsSearch.aspx.cs" Inherits="clinicDeno.MedicalRecordsSearch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section class="vertical-middle-landing">
        <div class="box-style box-desktop-950 item-center">
            <h2 class="montserrat grey-blue-second medium-font">Patient's medical records retrieval</h2>


            <section class="long-layout-inputField input-section-gap">
                <div class="longinputHeader-row">
                    <p class="montserrat grey-blue-second bold-font">Patient Information</p>
                </div>
                <asp:TextBox ID="Name" runat="server"  class="long-inputField" type="text" placeholder="Patient's Name" required="true"></asp:TextBox>
                <asp:TextBox ID="NRIC" runat="server" class="long-inputField" type="text" placeholder="Patient's NRIC"></asp:TextBox>
            </section>

            <asp:Button ID="SearchBtn" runat="server" Text="Search"  class="montserrat rounded-full standard-btn btn-standard-width y-gap" OnClick="SearchBtn_Click"/>

        </div>
    </section>
</asp:Content>
