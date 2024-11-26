using SoftCyberiaBaseBO.CyberiaWS;

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
    }
}
