using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AspNetWebFormLocalization
{
    public partial class Sample : System.Web.UI.Page
    {
        protected override void InitializeCulture()
        {
            Console.WriteLine("InitializeCulture");

            string culture = String.Empty;
            culture = Request["lang"];
            if (!String.IsNullOrWhiteSpace(culture))
            {
                UpdateCulture(culture);
            }

            base.InitializeCulture();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDataLaunguageDropDownListSource();
            }
        }

        private void BindDataLaunguageDropDownListSource()
        {
            languageDropDownList.Items.AddRange(new[]{
                new ListItem { Value = "ko-kr", Text = "한국어" },
                new ListItem{ Value= "en-us", Text="영어 (미국)"}
            });
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