usando a  Microsoft . AspNetCore . Hospedagem ;
usando a  Microsoft . Extensões . Hospedagem ;

namespace  AspNetCore.WebApi.Live
{
     Programa de aulas  públicas
    {
        public  static  void  Main ( string [] args )
        {
            CreateHostBuilder (args). Build(). Run ();
        }

        public  static  IHostBuilder  CreateHostBuilder ( string [] args ) =>
            Host.CreateDefaultBuilder ( args )
                .ConfigureWebHostDefaults ( webBuilder  =>
                {
                    webBuilder . UseStartup < Startup > ();
                });
    }
}