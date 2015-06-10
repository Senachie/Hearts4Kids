namespace testN2CMS.Models
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    using N2;
    using N2.Definitions;
    using N2.Details;
    using N2.Engine.Globalization;
    using N2.Integrity;
    using N2.Security;
    using N2.Web;
    using N2.Web.UI;

    using testN2CMS.N2Baseline;
    using Dinamico;

    [PageDefinition(
		Title = "Start Page",
		Description = "The topmost node of a site. This can be placed below a language intersection to also represent a language",
		IconClass = "n2-icon-globe",
		InstallerVisibility = N2.Installation.InstallerHint.PreferredStartPage)]
	[RestrictParents(typeof(IRootPage), typeof(LanguageIntersection))]
	[RecursiveContainer(Defaults.Containers.Settings, 1000)]
	[RecursiveContainer("Site", 1000, RequiredPermission = Permission.Administer)]

	public class StartPage : PageModelBase, IStartPage, IStructuralPage, ILanguage
	{
		#region Tab : Content



		#endregion

		#region ILanguage Members

		public string FlagUrl
		{
			get
			{
				if (string.IsNullOrEmpty(this.LanguageCode))
					return "";

				string[] parts = this.LanguageCode.Split('-');
				return N2.Web.Url.ResolveTokens(string.Format("~/N2/Resources/Img/Flags/{0}.png", parts[parts.Length - 1].ToLower()));
			}
		}

		[EditableLanguagesDropDown("Language", 100, ContainerName = Defaults.Containers.Settings)]
		public virtual string LanguageCode { get; set; }

		[EditableTextBox(Title = "Native Language Name", SortOrder = 101, DefaultValue = "", ContainerName = Defaults.Containers.Settings)]
		public virtual string LanguageNativeName { get; set; }

		public string LanguageTitle
		{
			get
			{
				if (string.IsNullOrEmpty(this.LanguageCode))
					return "";
				else
					return new CultureInfo(this.LanguageCode).DisplayName;
			}
		}

		#endregion
	}
}