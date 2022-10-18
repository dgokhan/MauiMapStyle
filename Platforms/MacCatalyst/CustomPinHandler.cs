namespace MauiCustomMap;

using MapKit;
using Microsoft.Maui.Maps.Handlers;

public class CustomPinHandler : MapPinHandler
{
	protected override IMKAnnotation CreatePlatformElement() => new CustomAnnotation();
}