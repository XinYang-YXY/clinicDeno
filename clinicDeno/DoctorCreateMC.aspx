<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DoctorCreateMC.aspx.cs" Inherits="clinicDeno.DoctorCreateMC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section class="vertical-middle-landing">
        <div class="box-style box-desktop-950 item-center">
            <h2 class="montserrat grey-blue-second medium-font">Medical Certificate</h2>


            <section class="layout-inputField input-section-gap">
                <asp:Label runat="server" CssClass="montserrat bold-font" id="date" style="text-align:left"></asp:Label>
                <div class="inputHeader-row 2col font-size-11">
                    <p class="montserrat grey-blue-second bold-font">Duration<a style="color:red;">*</a></p>
                </div>
                <asp:TextBox ID="Duration" runat="server"  class="long-inputField-2col" type="text" placeholder="Amount of days" required="true"></asp:TextBox>

                <div class="inputHeader-row 2col font-size-11">
                    <p class="montserrat grey-blue-second bold-font">Comment</p>
                </div>
                <asp:TextBox ID="Comment" runat="server"  class="long-inputField-2col-fat" type="text" TextMode="MultiLine" placeholder="Comments"></asp:TextBox>
            </section>

            <asp:Button ID="CreateBtn" runat="server" Text="Create Medical Instruction"  class="montserrat rounded-full standard-btn btn-standard-width y-gap" OnClick="CreateBtn_Click"/>

        </div>
    </section>
</asp:Content>
