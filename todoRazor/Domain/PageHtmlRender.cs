using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Html;
using static global::todoRazor.ComponentsClass;
using static global::todoRazor.BaseClass;

namespace todoRazor;

public class PageHtmlRender
{
    private readonly string basePath = AppDomain.CurrentDomain.BaseDirectory;
    private readonly JsonSerializerSettings jsonSerializerSettings;

    public PageHtmlRender()
    {
        jsonSerializerSettings = new JsonSerializerSettings
        {
            Converters = new List<JsonConverter> { new ComponentConverter() }
        };
    }

public HtmlContentResult RenderPageContent(IHtmlContent pageContent)
{
    var layoutTemplate = ReadFile(@"Templates\_Template.cshtml");
    var finalHtml = layoutTemplate
        .Replace("{{body}}", pageContent.GetString());
    return new HtmlContentResult(new HtmlContentBuilder().AppendHtml(finalHtml));
}

    private string ReadFile(string relativePath)
    {
        return File.ReadAllText(Path.Combine(basePath, relativePath));
    }

}
