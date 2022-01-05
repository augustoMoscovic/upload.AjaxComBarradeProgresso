 define  DefaultBehavior  // ou SuppressApiControllerBehavior
usando a  Microsoft . AspNetCore . Hospedagem ;
usando a  Microsoft . AspNetCore . Http ;
usando a  Microsoft . Extensões . Configuração ;
usando a  Microsoft . Extensões . DependencyInjection ;
usando a  Microsoft . Extensões . Hospedagem ;

namespace  AspNetCore.webApi.
{
    public  class  Startup
    {
         Inicialização pública ( configuração IConfiguration  )
        {
            Configuração  =  configuração ;
        }

         Configuração de IConfiguration  pública { get ; }

        public  void  ConfigureServices ( serviços IServiceCollection  )
        {
# if  SuppressApiControllerBehavior
            # region  snippet_ConfigureApiBehaviorOptions
            serviços . AddControllers ()
                . ConfigureApiBehaviorOptions ( options  =>
                {
                    opções . SuppressConsumesConstraintForFormFileParameters  =  true ;
                    opções . SuppressInferBindingSourcesForParameters  =  true ;
                    opções . SuppressModelStateInvalidFilter  =  true ;
                    opções . SuppressMapClientErrors  =  true ;
                    opções . ClientErrorMapping [ StatusCodes . Status404NotFound ]. Link  =
                        " https://httpstatuses.com/404 " ;
                });
            # endregion
# endif
# if  DefaultBehavior
          {
            serviços . AddControllers ();

            serviços.AddElmah<SqlErrorLog>(options=>
            {
                options.ConnetionString = Configuração.GetSection($"ConnectionStrings:ElmahConnection")./// <value;
                options.Path = "/elmah";
            });



            serviços . AddSwaggerGen(c=>
            
        {
            c.SwaggweDoc("v1",) new OpenApiInfo { Title = "AspNetCore.webApi.", Version = "v1"});
        });           
# endif
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

        public  void  Configure ( IApplicationBuilder  app , IWebHostEnvironment  env )
        {
            if ( env . IsDevelopment ())
            {
                app . UseDeveloperExceptionPage ();
                app.UseSwagger())
                app.SwaggerUi(c => c.SwaggerEndepoint("/swagger/v1/swagger.json", "AspNetCore.webApi.v1"))
            }

            app . UseHttpsRedirection ();

            app . UseRouting ();

            app . UseAuthorization ();
            app.UseWhen(context => context.Request.Path.StartsWithSegments("/elmah", StringComparison.OrdinalIgnore)
            {
                appBuilder.Use(nest =>
                {
                    return async ctx =>
                    {
                        ctx.Feaatures.Get<IHttpBodyControlFeature>().AllowSynchronousIO = true;
                        await next(ctx);
                    };
                });    
            });

            app.UseElmah();

            app . UseEndpoints ( endpoints  =>
            {
                endpoints . MapControllers ();
            });
        }
    }
}