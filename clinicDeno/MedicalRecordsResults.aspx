<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MedicalRecordsResults.aspx.cs" Inherits="clinicDeno.MedicalRecordsResults" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section class="vertical-middle-landing">
        <div class="box-style box-desktop-950 item-center">
            <h2 class="montserrat grey-blue-second medium-font">Search Results</h2>

            <asp:Panel ID="allPatients" runat="server" class="long-layout-inputField input-section-gap">
                <%--<div class="layout-records">
                    <asp:Label runat="server"  class="record-titles IDTitle" text="Patient ID:"></asp:Label>
                    <asp:Label runat="server"  class="records ID" text="103"></asp:Label>
                    <asp:Label runat="server"  class="record-titles NRICTitle" text="NRIC:"></asp:Label>
                    <asp:Label runat="server"  class="records NRIC" text="T0219315F"></asp:Label>
                    <asp:Label runat="server"  class="record-titles NameTitle" text="Name:"></asp:Label>
                    <asp:Label runat="server"  class="records Name" text="Ben Lee"></asp:Label>
                    <asp:Label runat="server"  class="record-titles EmailTitle" text="Email:"></asp:Label>
                    <asp:Label runat="server"  class="records Email" text="benlee@gmail.com"></asp:Label>
                    <asp:Label runat="server"  class="record-titles GenderTitle" text="Gender:"></asp:Label>
                    <asp:Label runat="server"  class="records Gender" text="Male"></asp:Label>
                    <asp:Label runat="server"  class="record-titles ContactTitle" text="Contact Number:"></asp:Label>
                    <asp:Label runat="server"  class="records Contact" text="912371234"></asp:Label>
                    <asp:Button ID="Button1" runat="server" Text="View records"  class="montserrat rounded-full standard-btn btn-standard-width y-gap record-btn"/>
                </div>--%>
            </asp:Panel>

        </div>
    </section>
</asp:Content>
