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
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDataLaunguagesDropDownListSource();
            }

            SetCurrentLanguage();
        }        

        private void BindDataLaunguagesDropDownListSource()
        {
            languagesDropdownList.Items.AddRange(new[]{
                new ListItem { Value = "ko-kr", Text = "한국어" },
                new ListItem{ Value= "en-us", Text="영어 (미국)"}
            });
        }

        private void SetCurrentLanguage()
        {
            var culture = Thread.CurrentThread.CurrentCulture.Name;
            if (!String.IsNullOrEmpty(culture))
            {
                culture = culture.ToLower();
                languagesDropdownList.SelectedValue = culture;
            }            
        }

      
    }
}