using System;
using static todoRazor.BaseClass;

namespace todoRazor;

public class ComponentsClass
{
    public class TodoItem : BaseComponent
    {
        public Todo.Content Content { get; set; }
    }
}
