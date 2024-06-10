namespace DiscograficaWebApi.BLL.Utils;

public class FormatearFechaUtils
{
    public static string FormatearFecha(DateTime fecha)
    {
        return fecha.ToString("MM-yyyy");
    }
}
