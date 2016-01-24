namespace Sample.Web.UI.Compatibility {
    using System.Web.UI;

    internal interface IWebControlAccessor {
        HtmlTextWriterTag TagKey {
            get;
        }
    }
}
