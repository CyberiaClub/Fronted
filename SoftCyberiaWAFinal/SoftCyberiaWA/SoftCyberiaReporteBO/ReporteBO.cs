using SoftCyberiaBaseBO;

namespace SoftCyberiaReporteBO
{
    public class ReporteBO : BaseBO
    {
        public byte[] Boleta(int idComprobante)
        {
            return wsReportes.boleta(idComprobante);
        }
        public byte[] Factura(int idComprobante)
        {
            return wsReportes.factura(idComprobante);
        }
        public byte[] ReporteClientes(int idSede)
        {
            return wsReportes.reporteClientes(idSede);
        }
        public byte[] ReporteStock(int idSede)
        {
            return wsReportes.reporteStock(idSede);
        }
    }
}
