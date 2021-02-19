<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DoctorCreateMedicalInstruction.aspx.cs" Inherits="clinicDeno.DoctorCreateMedicalInstruction" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
  <link rel="stylesheet" href="/resources/demos/style.css">
  <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script type="text/javascript">
        function AddFields() {
            var Pinput = document.createElement('input');
            Pinput.type = "text";
            Pinput.name = "Pinput"
            Pinput.className = "long-inputField-split P";
            Pinput.placeholder = "Enter prescription"
            document.getElementById("MainContent_MIPanel").appendChild(Pinput);

            var Iinput = document.createElement('input');
            Iinput.type = "text";
            Iinput.name = "Iinput"
            Iinput.className = "long-inputField-split";
            Iinput.placeholder = "Enter instructions"
            document.getElementById("MainContent_MIPanel").appendChild(Iinput);

            var Qinput = document.createElement('input');
            Qinput.type = "text";
            Qinput.name = "Qinput"
            Qinput.className = "long-inputField-split";
            Qinput.placeholder = "Enter quantity"
            document.getElementById("MainContent_MIPanel").appendChild(Qinput);

            var Rinput = document.createElement('input');
            Rinput.type = "text";
            Rinput.name = "Rinput"
            Rinput.className = "long-inputField-split";
            Rinput.placeholder = "Enter number of refilled allowed"
            document.getElementById("MainContent_MIPanel").appendChild(Rinput);

            setInterval(function () {
                var availableTags = "Acetaminophen,Acetaminophen,Albuterol,Alprazolam,AmlodipineMetoprolol,Amoxicillin,Atenolol,Atorvastatin,Citalopram,Fluticasone,Furosemide,Hydrochlorothiazide,Hydrocodone,Insulin glargine,Levothyroxine,Lisinopril,Losartan,Metformin,Montelukast,Neurontin,Omeprazole,Pantoprazole,Sertraline,Simvastatin,Trazodone,Xanax".split(',');
                $(".P").autocomplete({
                    source: availableTags
                });
            }, 100);
        }
    </script>
    <section class="vertical-middle-landing">
        <div class="box-style box-desktop-950 item-center">
            <h2 class="montserrat grey-blue-second medium-font">Medical Instruction</h2>


            <section class="layout-inputField input-section-gap">
                <asp:Label runat="server" CssClass="montserrat bold-font" id="date" style="text-align:left"></asp:Label>
                <div class="inputHeader-row 2col font-size-11">
                    <p class="montserrat grey-blue-second bold-font">Patient Particulars</p>
                </div>
                <asp:Label ID="Name" runat="server"  class="long-inputField-split" type="text" Text="" style="opacity:55%;text-align:left;"></asp:Label>
                <asp:Label ID="NRIC" runat="server" class="long-inputField-split" type="text" Text="" style="opacity:55%;text-align:left;"></asp:Label>
                <asp:Label ID="Gender" runat="server"  class="long-inputField-split" type="text" Text="" style="opacity:55%;text-align:left;"></asp:Label>
                <asp:Label ID="PNum" runat="server" class="long-inputField-split" type="text" Text="" style="opacity:55%;text-align:left;"></asp:Label>
                <asp:Label ID="Email" runat="server"  class="long-inputField-2col" type="text" Text="" style="opacity:55%;text-align:left;"></asp:Label>

                <div class="inputHeader-row 2col font-size-11">
                    <p class="montserrat grey-blue-second bold-font">Medical Instruction <asp:LinkButton runat="server" ID="ABtn" CssClass="plus-btn" OnClientClick="AddFields();return false;"><i class="fa fa-plus"></i></asp:LinkButton> </p>
                </div>
                <asp:TextBox ID="Prescription" runat="server"  class="long-inputField-split P" type="text" placeholder="Enter prescription" required="true"></asp:TextBox>
                <asp:TextBox ID="Instructions" runat="server" class="long-inputField-split" type="text" placeholder="Enter instructions" required="true"></asp:TextBox>
                <asp:TextBox ID="Quantity" runat="server"  class="long-inputField-split" type="text" placeholder="Enter quantity" required="true"></asp:TextBox>
                <asp:TextBox ID="Refills" runat="server" class="long-inputField-split" type="text" placeholder="Enter number of refills allowed" required="true"></asp:TextBox>
                <asp:Panel runat="server" ID="MIPanel" CssClass="layout-inputField-noMargin 2col"></asp:Panel>
            </section>

            <asp:Button ID="CreateBtn" runat="server" Text="Create Medical Instruction"  class="montserrat rounded-full standard-btn btn-standard-width y-gap" OnClick="CreateBtn_Click"/>

        </div>
    </section>
</asp:Content>
