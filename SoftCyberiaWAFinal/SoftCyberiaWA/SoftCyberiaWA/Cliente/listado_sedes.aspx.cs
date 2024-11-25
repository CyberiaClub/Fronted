﻿using Newtonsoft.Json;
using SoftCyberiaBaseBO.CyberiaWS;
using SoftCyberiaInventarioBO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json.Serialization;
using System.Web.UI;

namespace SoftCyberiaWA
{
    public partial class Listado_sedes : Page
    {
        private readonly SedeBO sedeBO;

        public Listado_sedes()
        {
            sedeBO = new SedeBO();
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
            // Llama al método para obtener las sedes desde el servicio web
            BindingList<sede> sedes = sedeBO.Sede_listar();

            // Crear una lista para almacenar la información que se mostrará en el Repeater
            List<SedeInfo> listaSedes = new List<SedeInfo>();

            foreach (sede sede in sedes)
            {

                // Agregar cada sede a la lista, formateando el horario como texto
                listaSedes.Add(new SedeInfo
                {
                    Nombre = sede.nombre,
                    Descripcion = sede.descripcion,
                    HorarioApertura = sede.horarioApertura,
                    //HorarioApertura = sede.horarioApertura.ToString("HH:mm"), // Asegúrate de que horarioApertura sea DateTime
                    HorarioCierre = sede.horarioCierre,     // Asegúrate de que horarioCierre sea DateTime

                    Telefono = sede.telefono,
                    LinkUrl = $"../Cliente/listado_productos.aspx?sede={sede.nombre.Replace(" ", "_")}&idSede={sede.idSede}"
                }); // Aquí cerramos el paréntesis
            }

            // Asigna la lista de sedes al Repeater y realiza la vinculación de datos
            repeaterSedes.DataSource = listaSedes;
            repeaterSedes.DataBind();
        }

        // Clase auxiliar para pasar la información al Repeater
        public class SedeInfo
        {
            [JsonProperty("nombre")]
            [JsonPropertyName("nombre")]
            public string Nombre { get; set; }
            [JsonProperty("descripcion")]
            [JsonPropertyName("descripcion")]
            public string Descripcion { get; set; }
            [JsonProperty("horarioApertura")]
            [JsonPropertyName("horarioApertura")]
            public localTime HorarioApertura { get; set; }
            [JsonProperty("horarioCierre")]
            [JsonPropertyName("horarioCierre")]
            public localTime HorarioCierre { get; set; }
            [JsonProperty("telefono")]
            [JsonPropertyName("telefono")]
            public string Telefono { get; set; }
            [JsonProperty("linkUrl")]
            [JsonPropertyName("linkUrl")]
            public string LinkUrl { get; set; }
        }
    }
}