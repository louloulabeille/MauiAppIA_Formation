using Android.App;
using Android.Content.Res;
using Android.Runtime;
using Microsoft.Maui.Handlers;

namespace MauiAppIA_Formation
{
    [Application]
    public class MainApplication(IntPtr handle, JniHandleOwnership ownership) : MauiApplication(handle, ownership)
    {
        /*public MainApplication
            : base(handle, ownership)
        {
        }*/

        protected override MauiApp CreateMauiApp() 
        {
            EntryHandler.Mapper.AppendToMapping("NoUnderline", (handler, view) =>
            //EntryHandler.Mapper.AppendToMapping(nameof(Entry), (handler, view) =>
            {
                if (view is Entry)
                {
                    // Remove underline
                    handler.PlatformView.BackgroundTintList = ColorStateList.ValueOf(Android.Graphics.Color.Transparent);

                    // Change placeholder text color
                    //handler.PlatformView.SetHintTextColor(ColorStateList.ValueOf(Android.Graphics.Color.Red));
                }
            });

            return MauiProgram.CreateMauiApp();

        } //=> MauiProgram.CreateMauiApp();
    }
}
