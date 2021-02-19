<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MedicalRecordsCreate.aspx.cs" Inherits="clinicDeno.MedicalRecordsCreate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
  <link rel="stylesheet" href="/resources/demos/style.css">
  <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script type="text/javascript">
        var ACount = 0;
        var FMHCount = 0;
        var CMCount = 0;
        var CCount = 0;
        function AddAFields() {
            var input = document.createElement('input');
            input.id = "A" + ACount;
            ACount += 1
            input.type = "text";
            input.name = "A"
            input.className = "long-inputField-2col A";
            input.placeholder = "Enter Allergy Here"
            document.getElementById("MainContent_APanel").appendChild(input);
        }
        function AddFMHFields() {
            var input = document.createElement('input');
            input.id = "FMH" + FMHCount;
            FMHCount += 1
            input.type = "text";
            input.name = "FMH"
            input.className = "long-inputField-2col FMH";
            input.placeholder = "Enter Family Medical History Here"
            document.getElementById("MainContent_FMHPanel").appendChild(input);
        }
        function AddCMFields() {
            var input = document.createElement('input');
            input.id = "CM" + CMCount;
            CMCount += 1
            input.type = "text";
            input.name = "CM"
            input.className = "long-inputField-2col CM";
            input.placeholder = "Enter Current Medications Here"
            document.getElementById("MainContent_CMPanel").appendChild(input);
        }
        function AddCFields() {
            var input = document.createElement('input');
            input.id = "C" + CCount;
            CCount += 1
            input.type = "text";
            input.name = "C"
            input.className = "long-inputField-2col C";
            input.placeholder = "Enter Comments Here"
            document.getElementById("MainContent_CPanel").appendChild(input);
        }

        setInterval(function () {
            var availableTags = "Balsam of Peru, Buckwheat, Cat , Celery , Cephalosporins , Chromium , Cobalt chloride , Cold stimuli , Cosmetics , Dilantin, Dog , Egg , Fish, Formaldehyde , Fruit, Fungicide, Garlic , Gold , Hot peppers , House dust mite , Insect sting , Intravenous contrast dye , Latex , Local anesthetics , Maize , Milk , Mold , Nickel , Non-steroidal anti-inflammatories , Oats , Peanut , Penicillin , Perfume, Photographic developers , Pollen , Poultry Meat , Red Meat , Rice , Semen , Sesame , Shellfish , Soy , Sulfites, Sulfonamides , Tartrazine , Tegretol , Tetracycline, Tree nut, Water , Wheat".split(',');
            $(".A").autocomplete({
                source: availableTags
            });
        }, 100);

        setInterval(function () {
            var availableTags = "Alzheimer's disease,Arthritis,Beta thalassemia,Cancer,Congenital deafness,Cystic fibrosis,Dementia,Diabetes,Heart disease,High blood pressure,Huntington disease,Marfan syndrome,Multiple sclerosis,Neurofibromatosis type 1,Parkinson's disease,Sickle-cell anemia,Spina bifida,Spinal muscular atrophy (SMA),Tay-sachs disease,Thyroid disorders".split(',');
            $(".FMH").autocomplete({
                source: availableTags
            });
        }, 100);

        setInterval(function () {
            var availableTags = "Acetaminophen,Attapulgite,Benzocaine,Bismuth subsalicylate,Calcium carbonate,Cromolyn sodium,Dextromethorphan,Dimenhydrinate,Diphenhydramine,Emetrol,Guaifenesin,Ibuprofen,Loperamide,Nonsteroidal Anti-inflammatory Drugs,Salicylic Acid or Aspirin,Simethicone".split(',');
            $(".CM").autocomplete({
                source: availableTags
            });
        }, 100);
    </script>
    <section class="vertical-middle-landing">
        <div class="box-style box-desktop-950 item-center">
            <h2 class="montserrat grey-blue-second medium-font">Medical Record</h2>


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
                    <p class="montserrat grey-blue-second bold-font">Allergies <asp:LinkButton runat="server" ID="ABtn" CssClass="plus-btn" OnClientClick="AddAFields();return false;"><i class="fa fa-plus"></i></asp:LinkButton> </p>
                </div>
                <asp:Panel runat="server" ID="APanel" CssClass="layout-inputField-noMargin"></asp:Panel>

                <div class="inputHeader-row 2col font-size-11">
                    <p class="montserrat grey-blue-second bold-font">Family Medical History <asp:LinkButton runat="server" ID="FMHButton" CssClass="plus-btn" OnClientClick="AddFMHFields();return false;"><i class="fa fa-plus"></i></asp:LinkButton> </p>
                </div>
                <asp:Panel runat="server" ID="FMHPanel" CssClass="layout-inputField-noMargin"></asp:Panel>

                <div class="inputHeader-row 2col font-size-11">
                    <p class="montserrat grey-blue-second bold-font">Current Medications <asp:LinkButton runat="server" ID="CMButton" CssClass="plus-btn" OnClientClick="AddCMFields();return false;"><i class="fa fa-plus"></i></asp:LinkButton> </p>
                </div>
                <asp:Panel runat="server" ID="CMPanel" CssClass="layout-inputField-noMargin"></asp:Panel>

                <div class="inputHeader-row 2col font-size-11">
                    <p class="montserrat grey-blue-second bold-font">Diagnosis</p>
                </div>
                <asp:TextBox ID="Diagnosis" runat="server"  class="long-inputField-2col" type="text" placeholder="Enter Diagnosis" required="true"></asp:TextBox>

                <div class="inputHeader-row 2col font-size-11">
                    <p class="montserrat grey-blue-second bold-font">Comment <asp:LinkButton runat="server" ID="CButton" CssClass="plus-btn" OnClientClick="AddCFields();return false;"><i class="fa fa-plus"></i></asp:LinkButton> </p>
                </div>
                <asp:Panel runat="server" ID="CPanel" CssClass="layout-inputField-noMargin"></asp:Panel>
            </section>

            <asp:Button ID="CreateBtn" runat="server" Text="Create Medical Record"  class="montserrat rounded-full standard-btn btn-standard-width y-gap" OnClick="CreateBtn_Click"/>

        </div>
    </section>
</asp:Content>
