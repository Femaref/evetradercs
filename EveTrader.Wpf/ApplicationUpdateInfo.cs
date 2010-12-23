using EveTrader.Updater;
using System.ComponentModel.Composition;
using System.Reflection;
using System.IO;

namespace EveTrader.Wpf
{
	[Export(typeof(IApplicationUpdateInfo))]
	public class ApplicationUpdateInfo : IApplicationUpdateInfo
	{
		EveTrader.Wpf.Properties.Settings settings = new EveTrader.Wpf.Properties.Settings();
		
		public System.String BaseUri
		{
						get
			{
				return settings.BaseUri;
			}
					}		
		
		public System.String BinaryUri
		{
						get
			{
				return settings.BinaryUri;
			}
					}		
		
		public System.String StaticUri
		{
						get
			{
				return settings.StaticUri;
			}
					}		
		public string ApplicationPath
		{
			get
			{
				 return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
			}
		}
	}
}