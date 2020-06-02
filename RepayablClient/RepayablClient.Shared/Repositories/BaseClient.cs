namespace RepayablClient.Shared.Repositories
{
    public class BaseClient
    {
#if !NETFX_CORE
        public string BaseUrl { get; set; } = "http://repayabl.avnishkumar.co.in/";
#else
        public string BaseUrl { get; set; } = "http://localhost:44314/";
#endif
    }
}
