using SoftCyberiaBaseBO.CyberiaWS;
using System.Web;

namespace SoftCyberiaBaseBO
{
    public class BaseBO
    {
        protected ServicioWebClient wsBase;
        protected ReportesClient wsReportes;


        public BaseBO()
        {
            wsBase = new ServicioWebClient();
            wsReportes = new ReportesClient();
        }

        public void AbrirReporte(HttpResponse response, string nombreDeReporte, byte[] reporte)
        {
            response.Clear();
            response.ContentType = "application/pdf";
            response.AddHeader("Content-Disposition", "inline;filename=" + nombreDeReporte + ".pdf");
            response.BinaryWrite(reporte);
            response.End();
        }
    }
}
