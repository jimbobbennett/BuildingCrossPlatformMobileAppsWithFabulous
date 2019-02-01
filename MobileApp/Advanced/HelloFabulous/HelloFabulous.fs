namespace HelloFabulous

open Fabulous.Core
open Fabulous.DynamicViews
open Xamarin.Forms
open Xamarin.Essentials
open System.IO
open Plugin.Media
open Plugin.Media.Abstractions

module App =

    type Model = 
        { 
            PhotoStream : Stream
            ImageSource : ImageSource            
            IsBusy : bool
            SaveStorage : Stream -> Async<unit>
        }

    type Msg = 
        | PhotoTaken of Stream 
        | ChangeBusy of bool
        
    let init (saveStorage : Stream -> Async<unit>) = 
        { 
            PhotoStream = null
            ImageSource = ImageSource.FromStream(fun () -> null)
            IsBusy = false
            SaveStorage = saveStorage
        }, Cmd.none

    let update msg model =
        match msg with
        | PhotoTaken s -> { model with PhotoStream = s; ImageSource = ImageSource.FromStream(fun () -> s) }, Cmd.none
        | ChangeBusy b -> { model with IsBusy = b }, Cmd.none

    let takePhoto dispatch (model : Model) =
        async {
            if (Connectivity.NetworkAccess <> NetworkAccess.Internet) then
                do! Application.Current.MainPage.DisplayAlert("Error", "No network", "OK") |> Async.AwaitTask
            else
                dispatch ((ChangeBusy)true)

                let options = new StoreCameraMediaOptions()
                options.PhotoSize <- PhotoSize.Medium
                let! photo = CrossMedia.Current.TakePhotoAsync (options) |> Async.AwaitTask
            
                dispatch ((PhotoTaken)(photo.GetStreamWithImageRotatedForExternalStorage()))

                do! model.SaveStorage (photo.GetStreamWithImageRotatedForExternalStorage())

                dispatch ((ChangeBusy)false)
            ()
        }

    let view (model: Model) dispatch =
        View.ContentPage(
            content = View.Grid(
                rowdefs = [box "*"; box "auto"],
                rowSpacing = 10.,
                children = [ 
                    yield View.Image(
                        source = model.ImageSource,
                        aspect = Aspect.AspectFill,
                        margin = 20.
                    ).GridRow(0)
                    yield View.Button(
                        text = "Take photo",
                        backgroundColor = Color.SlateBlue,
                        textColor = Color.White,
                        command = (fun _ -> takePhoto dispatch model |> Async.StartImmediate),
                        margin = 20.
                    ).GridRow(1)
                    if (model.IsBusy) then
                        yield View.Grid(
                            backgroundColor = Color.Black,
                            opacity = 0.5
                        ).GridRowSpan(2)
                        yield View.ActivityIndicator(
                            horizontalOptions = LayoutOptions.Center,
                            verticalOptions = LayoutOptions.Center,
                            color = Color.White
                        ).GridRowSpan(2)
                ]
            )
        )
                           
    let program (s : Stream -> Async<unit>) =
        let i = fun () -> init s
        Program.mkProgram i update view

type App (saveStorage : string -> Stream -> Async<unit>) as app = 
    inherit Application ()

    let runner = 
        App.program (saveStorage Keys.connectionString)
#if DEBUG
        |> Program.withConsoleTrace
#endif
        |> Program.runWithDynamicView app

#if DEBUG
    do runner.EnableLiveUpdate()
#endif    


