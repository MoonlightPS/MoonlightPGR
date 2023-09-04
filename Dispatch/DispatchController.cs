using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using MoonlightPGR.Dispatch.Interfaces;
using Newtonsoft.Json;

namespace MoonlightPGR.Dispatch;

public class DispatchController
{

    public class LogUpload
    {
        public int code {  get; set; }
        public string msg { get; set; }
    }

    public static void AddHandlers(WebApplication app)
    {
        // Actual Dispatch
        app.MapGet("/prod/client/config/com.kurogame.punishing.grayraven.en.pc/1.28.0/standalone/config.tab", (ctx) =>
        {

            string rsp =
@"Key	Type	Value
ApplicationVersion	string	1.28.0
DocumentVersion	string	1.28.11
Debug	bool	1
External	bool	1
Channel	int	1
PayCallbackUrl	string	empty
PrimaryCdns	string	http://prod-encdn-aliyun.kurogame.net/prod|http://prod-encdn-akamai.kurogame.net/prod
SecondaryCdns	string	http://prod-encdn-aliyun.kurogame.net/prod
CdnInvalidTime	int	600
MtpEnabled	bool	1
MemoryLimit	int	2048
CloseMsgEncrypt	bool	0
ServerListStr	string	MoonlightPGR#http://localhost/api/Login/Login|MoonlightPGR Dev#http://localhost/api/Login/Login
IndexMd5	string	c5d4baac85a6e37b8109ea43dc045d31
AndroidReturnEnabled	bool	0
AndroidPayCallbackList	string	http://198.11.174.55:1300/api/XPay/HeroHgAndroidPayResult#http://47.254.134.173:1300/api/XPay/HeroHgAndroidPayResult#http://8.219.230.8:1300/api/XPay/HeroHgAndroidPayResult
AndroidPayCallbackUrl	string	http://161.117.238.242:1300/api/XPay/HeroHgAndroidPayResult
IosPayCallbackUrl	string	http://161.117.238.242:1300/api/XPay/HeroHgIosPayResult
DEEnable	bool	1
DEFilter	string	empty
IndexSha1	string	fbd2891dc3b542c00413c99a137424f88672a47a
WatermarkEnabled	bool	0
PicComposition	string	empty
IosPayCallbackList	string	http://198.11.174.55:1300/api/XPay/HeroHgIosPayResult#http://47.254.134.173:1300/api/XPay/HeroHgIosPayResult#http://8.219.230.8:1300/api/XPay/HeroHgIosPayResult
LaunchModuleVersion	string	1.28.0
LaunchIndexSha1	string	empty
DeepLinkEnabled	bool	1
AccountCancellationEnable	bool	0
DownloadMethod	int	1
PcPayCallbackList	string	http://198.11.174.55:1300/api/XPay/KuroPayResult#http://47.254.134.173:1300/api/XPay/KuroPayResult#http://8.219.230.8:1300/api/XPay/KuroPayResult"
;

            return ctx.Response.WriteAsync(rsp);
        });

        // Probably like Gate?
        app.MapGet("/api/Login/Login", (ctx) =>
        {
            LoginRsp rsp = new LoginRsp()
            {
                Code = 0,
                Token = "1957b754-9b81-46c6-9e17-a8b3444844c6",
                Port = 2333,
                Ip = "127.0.0.1"
            };
            return ctx.Response.WriteAsync(JsonConvert.SerializeObject(rsp));
        });

        app.MapPost("/maidian_pcstarter", (ctx) =>
        {
            return ctx.Response.WriteAsJsonAsync(new LogUpload()
            {
                code = 0,
                msg = "ok"
            });
        });

    }
}