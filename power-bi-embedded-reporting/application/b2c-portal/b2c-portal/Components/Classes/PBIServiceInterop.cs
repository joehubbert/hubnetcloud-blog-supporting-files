using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace b2c_portal.Components.Classes
{
    public static class PBIServiceInterop
    {
        internal static ValueTask<object> CreateReport(
            IJSRuntime jsRuntime,
            ElementReference reportContainer,
            string accessToken,
            string embedUrl,
            string embedReportId)
        {
            return jsRuntime.InvokeAsync<object>(
                "ShowMyPowerBI.showReport",
                reportContainer, accessToken, embedUrl,
                embedReportId);
        }
    }
}