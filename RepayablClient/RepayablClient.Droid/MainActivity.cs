using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using Microsoft.Identity.Client;

namespace RepayablClient.Droid
{
	[Activity(
			MainLauncher = true,
			ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize,
			WindowSoftInputMode = SoftInput.AdjustPan | SoftInput.StateHidden
		)]
	public class MainActivity : Windows.UI.Xaml.ApplicationActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			App.ParentWindow = this;
		}
		protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
		{
			base.OnActivityResult(requestCode, resultCode, data);
			AuthenticationContinuationHelper.SetAuthenticationContinuationEventArgs(requestCode, resultCode, data);
		}
	}

	[Activity]
	[IntentFilter(new[] { Intent.ActionView },
	   Categories = new[] { Intent.CategoryBrowsable, Intent.CategoryDefault },
	   DataHost = "auth",
	   DataScheme = "msalf8a883fb-a59f-4f46-915a-d841941445c7")]
	public class MsalActivity : BrowserTabActivity
	{
	}
}

