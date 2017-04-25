using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;

namespace AspNetWebFormLocalization
{
    public class AppWebForm : Page
    {
        protected override void InitializeCulture()
        {
            string culture = String.Empty;
            culture = Request["lang"];
            if (String.IsNullOrWhiteSpace(culture))
            {
                culture = GetCurrentCulture();
            }

            UpdateCulture(culture);

            base.InitializeCulture();
        }

        private string GetCurrentCulture()
        {
            return Thread.CurrentThread.CurrentCulture.Name;
        }

        private void UpdateCulture(string culture)
        {
            Page.Culture = culture;
            Page.UICulture = culture;

            var curtureInfo = CultureInfo.CreateSpecificCulture(culture);

            Thread.CurrentThread.CurrentCulture = curtureInfo;
            Thread.CurrentThread.CurrentUICulture = curtureInfo;

        }
    }
}