#if WINDOWS_UWP
#pragma warning disable CS0618 // Type or member is obsolete
namespace Nventive.View.Converters.PrettyDateConverter.Resources
{
	using System;
	using System.Collections.Generic;
	using Windows.ApplicationModel.Resources;
	using Windows.ApplicationModel.Resources.Core;

	internal class PrettyDateFormatterStrings 
	{
		private const string ResourcePrefix = "Nventive.View/PrettyDateFormatterStrings/";

		private static ResourceMap _resourceMap;

		internal PrettyDateFormatterStrings()
		{
		}

		internal static ResourceMap _resourceManager
		{
			get
			{
				if (object.ReferenceEquals(_resourceMap, null))
				{
					_resourceMap = Windows.ApplicationModel.Resources.Core.ResourceManager.Current.MainResourceMap;
				}
				return _resourceMap;
			}
		}

		/// <summary>
		///   Looks up a localized string similar to {0} ago.
		/// </summary>
		internal static string CompleteDateFormat
		{
			get
			{
				return _resourceManager.GetValue(ResourcePrefix + "CompleteDateFormat").ValueAsString;
			}
		}

		/// <summary>
		///   Looks up a localized string similar to {0} day.
		/// </summary>
		internal static string DayFormatString
		{
			get
			{
				return _resourceManager.GetValue(ResourcePrefix + "DayFormatString").ValueAsString;
			}
		}

		/// <summary>
		///   Looks up a localized string similar to {0} days.
		/// </summary>
		internal static string DaysFormatString
		{
			get
			{
				return _resourceManager.GetValue(ResourcePrefix + "DaysFormatString").ValueAsString;
			}
		}

		/// <summary>
		///   Looks up a localized string similar to {0} hour.
		/// </summary>
		internal static string HourFormatString
		{
			get
			{
				return _resourceManager.GetValue(ResourcePrefix + "HourFormatString").ValueAsString;
			}
		}

		/// <summary>
		///   Looks up a localized string similar to {0} hours.
		/// </summary>
		internal static string HoursFormatString
		{
			get
			{
				return _resourceManager.GetValue(ResourcePrefix + "HoursFormatString").ValueAsString;
			}
		}

		/// <summary>
		///   Looks up a localized string similar to {0} minute.
		/// </summary>
		internal static string MinuteFormatString
		{
			get
			{
				return _resourceManager.GetValue(ResourcePrefix + "MinuteFormatString").ValueAsString;
			}
		}

		/// <summary>
		///   Looks up a localized string similar to {0} minutes.
		/// </summary>
		internal static string MinutesFormatString
		{
			get
			{
				return _resourceManager.GetValue(ResourcePrefix + "MinutesFormatString").ValueAsString;
			}
		}

		/// <summary>
		///   Looks up a localized string similar to now.
		/// </summary>
		internal static string Now
		{
			get
			{
				return _resourceManager.GetValue(ResourcePrefix + "Now").ValueAsString;
			}
		}

		/// <summary>
		///   Looks up a localized string similar to {0} second.
		/// </summary>
		internal static string SecondFormatString
		{
			get
			{
				return _resourceManager.GetValue(ResourcePrefix + "SecondFormatString").ValueAsString;
			}
		}

		/// <summary>
		///   Looks up a localized string similar to {0} seconds.
		/// </summary>
		internal static string SecondsFormatString
		{
			get
			{
				return _resourceManager.GetValue(ResourcePrefix + "SecondsFormatString").ValueAsString;
			}
		}

		/// <summary>
		///   Looks up a localized string similar to {0} week.
		/// </summary>
		internal static string WeekFormatString
		{
			get
			{
				return _resourceManager.GetValue(ResourcePrefix + "WeekFormatString").ValueAsString;
			}
		}

		/// <summary>
		///   Looks up a localized string similar to {0} weeks.
		/// </summary>
		internal static string WeeksFormatString
		{
			get
			{
				return _resourceManager.GetValue(ResourcePrefix + "WeeksFormatString").ValueAsString;
			}
		}

		/// <summary>
		///   Looks up a localized string similar to {0} year.
		/// </summary>
		internal static string YearFormatString
		{
			get
			{
				return _resourceManager.GetValue(ResourcePrefix + "YearFormatString").ValueAsString;
			}
		}

		/// <summary>
		///   Looks up a localized string similar to {0} years.
		/// </summary>
		internal static string YearsFormatString
		{
			get
			{
				return _resourceManager.GetValue(ResourcePrefix + "YearsFormatString").ValueAsString;
			}
		}

		/// <summary>
		///   Looks up a localized string similar to yesterday.
		/// </summary>
		internal static string YesterdayString
		{
			get
			{
				return _resourceManager.GetValue(ResourcePrefix + "YesterdayString").ValueAsString;
			}
		}
	}
}
#endif
