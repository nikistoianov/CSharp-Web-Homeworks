namespace CHUSHKA.App
{
    using System;
    using SoftUni.WebServer.Mvc;
    using SoftUni.WebServer.Mvc.Routers;
    using SoftUni.WebServer.Server;
    using CHUSHKA.Data;

    class Launcher
    {
        static void Main()
        {
            var server = new WebServer(
                12345,
                new ControllerRouter(),
                new ResourceRouter());
            //var dbContext = new ChushkaContext();

            MvcEngine.Run(server);
        }
    }
}
