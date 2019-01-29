namespace HelloFabulous

open Xamarin.Forms
open Fabulous.Core
open Fabulous.DynamicViews

module App = 
    type Model = 
        { 
            Count : int
        }

    type Msg = 
        | Increment 
        | Decrement 

    let initModel = { Count = 0; }

    let init () = initModel, Cmd.none

    let update msg model =
        match msg with
        | Increment -> { model with Count = model.Count + 1 }, Cmd.none
        | Decrement -> { model with Count = model.Count - 1 }, Cmd.none
        
    let view (model: Model) dispatch =
        View.ContentPage(
            content = View.StackLayout(
                padding = 20.0, 
                verticalOptions = LayoutOptions.Center,
                children = [ 
                    View.Label(
                        text = sprintf "%d" model.Count, 
                        horizontalOptions = LayoutOptions.Center, 
                        horizontalTextAlignment=TextAlignment.Center,
                        fontSize= 50.,
                        textColor = Color.DarkSlateBlue
                    )
                    View.Button(
                        text = "Increment", 
                        command = (fun () -> dispatch Increment), 
                        horizontalOptions = LayoutOptions.Fill,
                        backgroundColor = Color.DarkSlateBlue,
                        textColor = Color.White
                    )
                    View.Button(
                        text = "Decrement", 
                        command = (fun () -> dispatch Decrement), 
                        horizontalOptions = LayoutOptions.Fill,
                        backgroundColor = Color.Red,
                        textColor = Color.White
                    )
                ]
            )
        )
                           
    let program = Program.mkProgram init update view

type App () as app = 
    inherit Application ()

    let runner = 
        App.program
#if DEBUG
        |> Program.withConsoleTrace
#endif
        |> Program.runWithDynamicView app

#if DEBUG
    do runner.EnableLiveUpdate()
#endif    


