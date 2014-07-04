namespace WebBrickClientFs.Android

open System

open Android.App
open Android.Content
open Android.OS
open Android.Runtime
open Android.Views
open Android.Widget
open Xamarin.Forms
open Xamarin.Forms.Platform.Android
open WebBrickClientFs

[<Activity (Label = "WebBrickClientFs", MainLauncher = true)>]
type MainActivity () =
    inherit AndroidActivity()

    override this.OnCreate (bundle) =

        base.OnCreate (bundle)

        Xamarin.Forms.Forms.Init( this, bundle )
        this.SetPage( App.GetMainPage())
