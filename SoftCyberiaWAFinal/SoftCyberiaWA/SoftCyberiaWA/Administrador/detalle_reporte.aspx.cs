﻿using SoftCyberiaBaseBO.CyberiaWS;
using SoftCyberiaInventarioBO;
using SoftCyberiaReporteBO;
using System;
using System.Diagnostics;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoftCyberiaWA.Administrador
{
    public partial class Detalle_reporte : Page
    {
        private readonly SedeBO sedeBO;
        private readonly ReporteBO reporteBO;
        public Detalle_reporte()
        {
            sedeBO = new SedeBO();
            reporteBO = new ReporteBO();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarSedes();
            }
        }
        private void CargarSedes()
        {
            sedeNombre.DataSource = sedeBO.Sede_listar();
            sedeNombre.DataTextField = "nombre";
            sedeNombre.DataValueField = "idSede";
            sedeNombre.DataBind();

            sedeNombre.Items.Insert(0, new ListItem("Seleccione una Sede", "0"));
        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            Debug.WriteLine(sedeNombre.SelectedIndex);
            byte[] reporte = reporteBO.ReporteStock(sedeNombre.SelectedIndex);
            reporteBO.AbrirReporte(Response, "ReporteStockProductos", reporte);
        }
        protected void BtnTop_Click(object sender, EventArgs e)
        {
            byte[] reporte = reporteBO.ReporteClientes(sedeNombre.SelectedIndex);
            reporteBO.AbrirReporte(Response, "ReporteTopClientes", reporte);
        }



    }
}