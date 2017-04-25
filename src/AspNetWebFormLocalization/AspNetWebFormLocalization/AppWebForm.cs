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
        private const string PROFILE_CULTURE = "culture";

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
            var culture = GetCultureCookie();

            if (String.IsNullOrWhiteSpace(culture))
            {
                culture = Thread.CurrentThread.CurrentCulture.Name;
            }

            return culture;
        }

        private void UpdateCulture(string culture)
        {
            Page.Culture = culture;
            Page.UICulture = culture;

            var curtureInfo = CultureInfo.CreateSpecificCulture(culture);

            Thread.CurrentThread.CurrentCulture = curtureInfo;
            Thread.CurrentThread.CurrentUICulture = curtureInfo;

            SetCultureCookie(culture);
        }

        private void SetCultureCookie(string culture)
        {
            var key = Request.Cookies.AllKeys.Where(k => k.ToLower().Equals(PROFILE_CULTURE)).FirstOrDefault();
            HttpCookie cookie = null;

            if (String.IsNullOrEmpty(key))
            {
                cookie = new HttpCookie(PROFILE_CULTURE);
            }
            else
            {
                cookie = Request.Cookies[key];
            }

            if (cookie.Values.Count == 0 || !cookie.Values["name"].Equals(culture.ToLower()))
            {
                cookie.Values["name"] = culture.ToLower();
                Response.Cookies.Remove(key);
                Response.Cookies.Add(cookie);
            }
        }

        private string GetCultureCookie()
        {
            var culture = String.Empty;
            var key = Request.Cookies.AllKeys.Where(k => k.ToLower().Equals(PROFILE_CULTURE)).FirstOrDefault();

            if (!String.IsNullOrEmpty(key))
            {
                culture = Request.Cookies[key]["name"];
            }

            return culture;
        }
    }
}