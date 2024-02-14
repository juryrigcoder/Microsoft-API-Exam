using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Html;
using static todoRazor.ComponentsClass;

namespace todoRazor;

public static class Components
{
    public static IHtmlContent TodoList(IEnumerable<Todo.TodoItem> todoItems)
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

    public static IHtmlContent TodoItem(Todo.TodoItem todoItem)
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

    public static string GetString(this IHtmlContent content)
    {
        if (content == null)
            return null;

        using var writer = new StringWriter();
        content.WriteTo(writer, HtmlEncoder.Default);
        return writer.ToString();
    }
}
