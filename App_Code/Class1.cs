using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



public class ReCaptcha
{
    public bool Success { get; set; }
    public List<string> ErrorCodes { get; set; }

    public static bool Validate(string encodedResponse)
    {
        if (string.IsNullOrEmpty(encodedResponse)) return false;

        var client = new System.Net.WebClient();
        var secret = "buraya Secret Key değerinizi yapıştırın";

        if (string.IsNullOrEmpty(secret)) return false;

        var googleReply = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secret, encodedResponse));

        var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

        var reCaptcha = serializer.Deserialize<ReCaptcha>(googleReply);

        return reCaptcha.Success;
    }
}