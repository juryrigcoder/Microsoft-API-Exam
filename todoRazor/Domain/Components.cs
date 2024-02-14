using Microsoft.AspNetCore.Html;

namespace todoRazor;

public static class Components
{
    public static IHtmlContent Document(IHtmlContentContainer children, IHtmlContentContainer? css, IHtmlContentContainer? header, IHtmlContentContainer? footer)
    {
        var builder = new HtmlContentBuilder();
        builder.AppendHtml("<!doctype html>");
        builder.AppendHtml("<html>");
        builder.AppendHtml("<head>");
        builder.AppendHtml("<meta charset=\"UTF-8\">");
        builder.AppendHtml("<meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">");
        builder.AppendHtml("<script src=\"https://unpkg.com/htmx.org@1.9.6\" integrity=\"sha384-FhXw7b6AlE/jyjlZH5iHa/tTe9EpJ1Y55RjcgPbjeWMskSxZt1v9qkxLJWNJaGni\" crossorigin=\"anonymous\"></script>");
        builder.AppendHtml("<script src=\"https://unpkg.com/htmx.org/dist/ext/json-enc.js\"></script>");
        builder.AppendHtml("<link rel=\"stylesheet\" type=\"text/css\" href=\"/css/fonts.css\">");
        builder.AppendHtml("<link rel=\"stylesheet\" type=\"text/css\" href=\"/css/global.css\">");
        builder.AppendHtml("<link rel=\"stylesheet\" type=\"text/css\" href=\"/css/variables.css\">");
        builder.AppendHtml("<link rel=\"stylesheet\" type=\"text/css\" href=\"/css/container.css\">");
        builder.AppendHtml("<link rel=\"stylesheet\" type=\"text/css\" href=\"/css/hamburger.css\">");
        builder.AppendHtml(css);
        builder.AppendHtml("</head>");
        builder.AppendHtml("<div class=\"layout\">");
        builder.AppendHtml(header);
        builder.AppendHtml(children);
        builder.AppendHtml(footer);
        builder.AppendHtml("</html>");
        return builder;
    }

    public static IHtmlContent TodoList(IEnumerable<TodoItem> todoItems)
    {
        var builder = new HtmlContentBuilder();
        builder.AppendHtml("<div>");
        foreach (var todoItem in todoItems)
        {
            builder.AppendHtml(TodoItem(todoItem));
        }
        builder.AppendHtml(TodoForm());
        builder.AppendHtml("</div>");
        return builder;
    }

    public static IHtmlContent TodoItem(TodoItem todoItem)
    {
        var completed = string.Empty;
        if (todoItem.Completed)
        {
            completed = "checked";
        }
        var builder = new HtmlContentBuilder();
        builder.AppendHtml("<div>");
        builder.AppendHtml("<p>");
        builder.AppendFormat(todoItem.Title);
        builder.AppendHtml("</p>");
        builder.AppendHtml($"<input type=\"checkbox\" {completed} hx-post=\"/todos/{todoItem.Id}/toggle\" hx-target=\"closest div\" hx-swap=\"outerHTML\"/>");
        builder.AppendHtml($"<button hx-delete=\"/todos/{todoItem.Id}\" hx-target=\"closest div\" hx-swap=\"outerHTML\">X</button>");
        builder.AppendHtml("</div>");
        return builder;
    }

    public static IHtmlContent TodoForm()
    {
        var builder = new HtmlContentBuilder();
        builder.AppendHtml("<form hx-post=\"/todos\" hx-swap=\"beforebegin\" hx-ext=\"json-enc\">");
        builder.AppendHtml("<input type=\"text\" name=\"name\">");
        builder.AppendHtml("<button type=\"submit\">Add</button>");
        builder.AppendHtml("</form>");
        return builder;
    }

}
