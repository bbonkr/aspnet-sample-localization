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
        public const string COOKIE_CULTURE = "culture";
        public const string COOKIE_CULTURE_NAME = "name";
        public const string FORM_DATA_LANGUAGE = "lang";

        protected override void InitializeCulture()
        {
            string culture = String.Empty;
            culture = Request[FORM_DATA_LANGUAGE];
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
            var key = Request.Cookies.AllKeys.Where(k => k.ToLower().Equals(COOKIE_CULTURE)).FirstOrDefault();
            HttpCookie cookie = null;

            if (String.IsNullOrEmpty(key))
            {
                cookie = new HttpCookie(COOKIE_CULTURE);
            }
            else
            {
                cookie = Request.Cookies[key];
            }

            if (cookie.Values.Count == 0 || !cookie.Values[COOKIE_CULTURE_NAME].Equals(culture.ToLower()))
            {
                cookie.Values[COOKIE_CULTURE_NAME] = culture.ToLower();
                Response.Cookies.Remove(key);
                Response.Cookies.Add(cookie);
            }
        }

        private string GetCultureCookie()
        {
            var culture = String.Empty;
            var key = Request.Cookies.AllKeys.Where(k => k.ToLower().Equals(COOKIE_CULTURE)).FirstOrDefault();

            if (!String.IsNullOrEmpty(key))
            {
                culture = Request.Cookies[key][COOKIE_CULTURE_NAME];
            }

            return culture;
        }
    }
}