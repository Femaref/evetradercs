
using EveTrader.Core.Model;
using System.ComponentModel.Composition;
namespace EveTrader.Wpf
{
	[Export(typeof(ISettingsProvider))]
	public class AssemblySettingsProvider : ISettingsProvider
	{
		EveTrader.Wpf.Properties.Settings settings = new EveTrader.Wpf.Properties.Settings();
		
		public System.Boolean AutoUpdate
		{
			get
			{
				 return settings.AutoUpdate;
			}
			set
			{
				settings.AutoUpdate = value;
				settings.Save();
			}
		}		
		
		public System.Boolean HideExpired
		{
			get
			{
				 return settings.HideExpired;
			}
			set
			{
				settings.HideExpired = value;
				settings.Save();
			}
		}		
		
		public System.DateTime JournalStartDate
		{
			get
			{
				 return settings.JournalStartDate;
			}
			set
			{
				settings.JournalStartDate = value;
				settings.Save();
			}
		}		
		
		public System.DateTime JournalEndDate
		{
			get
			{
				 return settings.JournalEndDate;
			}
			set
			{
				settings.JournalEndDate = value;
				settings.Save();
			}
		}		
		
		public System.Boolean JournalApplyStartFilter
		{
			get
			{
				 return settings.JournalApplyStartFilter;
			}
			set
			{
				settings.JournalApplyStartFilter = value;
				settings.Save();
			}
		}		
		
		public System.Boolean JournalApplyEndFilter
		{
			get
			{
				 return settings.JournalApplyEndFilter;
			}
			set
			{
				settings.JournalApplyEndFilter = value;
				settings.Save();
			}
		}		
		
		public System.DateTime TransactionsStartDate
		{
			get
			{
				 return settings.TransactionsStartDate;
			}
			set
			{
				settings.TransactionsStartDate = value;
				settings.Save();
			}
		}		
		
		public System.DateTime TransactionsEndDate
		{
			get
			{
				 return settings.TransactionsEndDate;
			}
			set
			{
				settings.TransactionsEndDate = value;
				settings.Save();
			}
		}		
		
		public System.Boolean TransactionsApplyStartFilter
		{
			get
			{
				 return settings.TransactionsApplyStartFilter;
			}
			set
			{
				settings.TransactionsApplyStartFilter = value;
				settings.Save();
			}
		}		
		
		public System.Boolean TransactionsApplyEndFilter
		{
			get
			{
				 return settings.TransactionsApplyEndFilter;
			}
			set
			{
				settings.TransactionsApplyEndFilter = value;
				settings.Save();
			}
		}		
		
		public System.DateTime ReportStartDate
		{
			get
			{
				 return settings.ReportStartDate;
			}
			set
			{
				settings.ReportStartDate = value;
				settings.Save();
			}
		}		
		
		public System.DateTime ReportEndDate
		{
			get
			{
				 return settings.ReportEndDate;
			}
			set
			{
				settings.ReportEndDate = value;
				settings.Save();
			}
		}		
		
		public System.Boolean ReportApplyStartFilter
		{
			get
			{
				 return settings.ReportApplyStartFilter;
			}
			set
			{
				settings.ReportApplyStartFilter = value;
				settings.Save();
			}
		}		
		
		public System.Boolean ReportApplyEndFilter
		{
			get
			{
				 return settings.ReportApplyEndFilter;
			}
			set
			{
				settings.ReportApplyEndFilter = value;
				settings.Save();
			}
		}		
		
		public System.String PriceSource
		{
			get
			{
				 return settings.PriceSource;
			}
			set
			{
				settings.PriceSource = value;
				settings.Save();
			}
		}		
		
		public System.String PriceMethod
		{
			get
			{
				 return settings.PriceMethod;
			}
			set
			{
				settings.PriceMethod = value;
				settings.Save();
			}
		}		
		
		public System.Boolean AutomaticPriceUpdate
		{
			get
			{
				 return settings.AutomaticPriceUpdate;
			}
			set
			{
				settings.AutomaticPriceUpdate = value;
				settings.Save();
			}
		}		
	}
}