using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Exceptionless;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExceptionlessXamarinTest.Logging
{
    public class MobileLogger
    {
        public static void InitializeLogger()
        {
            ExceptionlessClient.Default.Startup("QT9KvQ8a2b3x3zhnIkkIpm4YTZuN8R2Pfury1MIs");
            Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.Debug()
                    .WriteTo.Exceptionless(b => b.AddTags("EOS"))
                    .CreateLogger();
        }

        public static void XamarinExceptionlessTest()
        {
            try
            {
                throw new Exception();
            }
            catch (Exception exception)
            {
                //Either of these calls will throw the same error, regardless if we use ExceptionLess directly or Serilog.Sinks.Exceptionless
                exception.ToExceptionless().Submit();
                Log.Error(exception, "Error occurred on Xamarin Exceptionless Test");
            }
        }
    }
}