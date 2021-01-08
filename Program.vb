Imports Microsoft.AspNetCore
Imports Microsoft.AspNetCore.Hosting
Imports Microsoft.Extensions.DependencyInjection
Imports Microsoft.AspNetCore.Builder
Imports Microsoft.Extensions.Configuration
Imports Microsoft.Extensions.Logging
Imports Ocelot.DependencyInjection
Imports Ocelot.Middleware

Public Class Program
    Public Shared Sub Main(ByVal args As String())
        'Note that configuration.json must be present in the debug folder and its contents must at least be an empty JSON array if no settings are needed
        'Empty JSON array -> { }

        Dim httpORhttps As String = "http"
        Dim port As Integer = 9001

        WebHost.CreateDefaultBuilder(args).UseUrls(httpORhttps & "://*:" & port.ToString).ConfigureAppConfiguration(Function(hostingContext, config)
                                                                                                                        config.SetBasePath(hostingContext.HostingEnvironment.ContentRootPath).AddJsonFile("configuration.json").AddEnvironmentVariables()
                                                                                                                    End Function).ConfigureServices(Function(s)
                                                                                                                                                        s.AddOcelot()
                                                                                                                                                        s.AddMvc(Function([option]) CSharpImpl.__Assign([option].EnableEndpointRouting, False))
                                                                                                                                                    End Function).Configure(Function(a)
                                                                                                                                                                                a.UseMvc()
                                                                                                                                                                                a.UseOcelot().Wait()
                                                                                                                                                                            End Function).Build().Run()
    End Sub

    Private Class CSharpImpl
        Shared Function __Assign(Of T)(ByRef target As T, value As T) As T
            target = value
            Return value
        End Function
    End Class
End Class
