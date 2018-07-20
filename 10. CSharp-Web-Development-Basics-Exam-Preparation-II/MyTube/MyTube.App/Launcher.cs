
namespace MyTube.App
{
    using Data;
    using SimpleMvc.Framework;
    using SimpleMvc.Framework.Routers;
    using WebServer;

    public class Launcher
    {
        static void Main()
        {
            var server = new WebServer(
                12345,
                new ControllerRouter(),
                new ResourceRouter());
            var dbContext = new MyTubeContext();

            MvcEngine.Run(server, dbContext);
        }
    }
}
