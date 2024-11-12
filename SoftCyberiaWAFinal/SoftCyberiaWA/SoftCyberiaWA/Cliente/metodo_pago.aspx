<%@ Page Title="" Language="C#" MasterPageFile="~/Cliente/SoftCyberiaCliente.Master" AutoEventWireup="true" CodeBehind="metodo_pago.aspx.cs" Inherits="SoftCyberiaWA.metodo_pago" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Método de Pago
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphStyle" runat="server">
    <link href="../Content/metodo_pago.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cphContenido" runat="server">

   <div class="container">
       <h2>Selecciona un Método de Pago</h2>

       <div class="payment-methods">
           <h3>Agregar tarjeta</h3>

           <!-- Opciones de Método de Pago -->
           <div class="payment-method" onclick="showDebitCardForm()">
               <img src="/Imagenes/card-icon.png" alt="Tarjeta Débito" />
               <span>Tarjeta de Débito</span>
           </div>

           


           <h3>Otras opciones</h3>
           <div class="payment-method" onclick="showYapePlinQR()">
               <img src="/Imagenes/pagoefectivo-icon.png" alt="PagoEfectivo" />
               <span>PagoEfectivo</span>
           </div>
           <!-- Botón Volver en la esquina inferior izquierda -->
           <asp:Button ID="btnVolver" runat="server" CssClass="btn btn-secondary" Text="Volver" OnClick="btnVolver_Click" />
       </div>

       

       <div class="payment-summary">
           <h3>Resumen de la compra</h3>
           <div class="summary-item">
               <span>Productos (1)</span>
               <span>S/ 1,899</span>
           </div>
           <div class="summary-item">
               <span>Descuentos (1)</span>
               <span>- S/ 400</span>
           </div>
           <div class="summary-item">
               <span>Entrega (1)</span>
               <span>S/ 8.90</span>
           </div>
           <hr>
           <div class="summary-item">
               <strong>Total:</strong>
               <strong>S/ 1,507.90</strong>
           </div>
           <button class="btn btn-primary" onclick="processPayment()">Continuar</button>
       </div>

       <!-- Formulario de Tarjeta de Débito -->
       <div id="debitCardForm" class="debit-card-form">
           <h3>Detalles de la Tarjeta</h3>
           <label>Número de Tarjeta:</label>
           <input type="text" id="cardNumber" class="form-control" /><br>
           <label>Fecha de Expiración:</label>
           <input type="text" id="expiryDate" class="form-control" placeholder="MM/AA" /><br>
           <label>CVV:</label>
           <input type="text" id="cvv" class="form-control" /><br>
       </div>

       <!-- QR para Yape/Plin -->
       <div id="yapePlinQR" class="yape-plin-qr">
           <h3>Escanee el Código QR para Pagar</h3>
           <img src="/Imagenes/qr_yape_plin.png" alt="QR para Yape/Plin" class="img-fluid" />
       </div>
   </div>




    <script>
        function showDebitCardForm() {
            document.getElementById("debitCardForm").style.display = "block";
            document.getElementById("yapePlinQR").style.display = "none";
        }

        function showYapePlinQR() {
            document.getElementById("yapePlinQR").style.display = "block";
            document.getElementById("debitCardForm").style.display = "none";
        }

        function processPayment() {
            alert("Pago procesado con éxito");
            window.location.href = "boleta_pago.aspx";
        }
    </script>






</asp:Content>
