#if WINDOWS_UWP || __ANDROID__ || __IOS__ || __WASM__ || __WINDOWS10_0_18362_0__
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#if WINUI
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
#else
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
#endif

namespace Nventive.View.Controls
{
	public partial class PeekingFlipViewItem : SelectorItem
	{
		public PeekingFlipViewItem()
		{
			DefaultStyleKey = typeof(PeekingFlipViewItem);
		}
	}
}
#endif
