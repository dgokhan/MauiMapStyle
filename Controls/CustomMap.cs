
namespace MauiCustomMap;

using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Maps;

public class CustomMap : Map
{
    public static readonly BindableProperty MapStyleProperty = BindableProperty.Create(
    nameof(MapStyle),
    typeof(MapStyle),
    typeof(CustomMap),
    propertyChanged: OnMapStyleChanged);

    public MapStyle? MapStyle
    {
        get { return (MapStyle?)GetValue(MapStyleProperty); }
        set { SetValue(MapStyleProperty, value); }
    }
    public Microsoft.Maui.Maps.IMap? Map { get; set; }

    static async void OnMapStyleChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (CustomMap)bindable;
        var mapStyle = control.MapStyle;

        if (control.Handler?.PlatformView is null)
        {
            // Workaround for when this executes the Handler and PlatformView is null
            control.HandlerChanged += OnHandlerChanged;
            return;
        }

        if (mapStyle is not null)
        {
#if ANDROID || IOS || MACCATALYST
            await control.AddAnnotation();
#else
			await Task.CompletedTask;
#endif
        }
        else
        {
#if ANDROID

#elif IOS

#endif
        }

        void OnHandlerChanged(object? s, EventArgs e)
        {
            OnMapStyleChanged(control, oldValue, newValue);
            control.HandlerChanged -= OnHandlerChanged;
        }
    }
}
