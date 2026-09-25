using System;
using System.Collections.Specialized;
using Wisej.Web;

namespace ProgressBars
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// <param name="args">Arguments from the URL.</param>
        static void Main(NameValueCollection args)
        {
            // Application.Desktop = new MyDesktop();

            ProgressBarsWindow window = new ProgressBarsWindow();
            window.Show();
        }
    }
}