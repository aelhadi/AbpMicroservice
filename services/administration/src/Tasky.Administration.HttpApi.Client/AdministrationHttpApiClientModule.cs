using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;

namespace Tasky.Administration;

[DependsOn(
    typeof(AdministrationApplicationContractsModule),
    typeof(AbpHttpClientModule))]
[DependsOn(typeof(AbpPermissionManagementHttpApiClientModule))]
    [DependsOn(typeof(AbpSettingManagementHttpApiClientModule))]
    public class AdministrationHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(AdministrationApplicationContractsModule).Assembly,
            AdministrationRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<AdministrationHttpApiClientModule>();
        });

    }
}