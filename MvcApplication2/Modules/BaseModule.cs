using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication2.Modules
{
    public class BaseModule : IHttpModule
    {
        private string name;

        public BaseModule(string name)
        {
            this.name = name;
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += new EventHandler(this.BeginRequest);
            context.EndRequest += new EventHandler(this.EndRequest);
        }

        public void Dispose() {}

        private void BeginRequest(Object source, EventArgs e)
        {
            long milliseconds = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

            HttpApplication application = (HttpApplication)source;
            HttpContext context = application.Context;
            context.Response.Write("<span>" + this.name + " BeginRequest <span> " + milliseconds + " <br/>");
        }

        private void EndRequest(Object source, EventArgs e)
        {
            long milliseconds = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

            HttpApplication application = (HttpApplication)source;
            HttpContext context = application.Context;
            context.Response.Write("<span>" + this.name + " EndRequest <span> " + milliseconds + " <br/>");
        }
    }

    public class AModule : BaseModule
    {

        public AModule() 
            : base("A")
        {}

    }

    public class BModule : BaseModule
    {

        public BModule()
            : base("B")
        { }

    }

    public class CModule : BaseModule
    {

        public CModule()
            : base("C")
        { }

    }

}