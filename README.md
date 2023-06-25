# Fable.ReactToastify

Fable bindings for [react-toastify](https://github.com/fkhadra/react-toastify) ([NPM package](https://www.npmjs.com/package/react-toastify)) version 9.3.1+.

## Nuget package
[![Nuget](https://img.shields.io/nuget/v/Fable.ReactToastify.svg?colorB=green)](https://www.nuget.org/packages/Fable.ReactToastify)

## Installation with [Femto](https://github.com/Zaid-Ajaj/Femto)

```
femto install Fable.ReactToastify
```

## Standard installation

Nuget package

```
paket add Fable.ReactToastify -p YourProject.fsproj
```

NPM package

```
npm install react-toastify@9.3.1
```

## Usage

For advanced usage instructions and the complete API see [the official docs](https://fkhadra.github.io/react-toastify/introduction).

```fsharp
open Fable.Core.JsInterop
open Fable.React
open Fable.ReactToastify

// Import the default toast style sheet (or your own) in the application entry point.
// See https://fkhadra.github.io/react-toastify/how-to-style for styling info.
importSideEffects "react-toastify/dist/ReactToastify.css"

// Place the container close to your root.
let view model dispatch =
    div [] [
        // navbar
        // main content
        // footer

        Toastify.container [ ContainerOption.position Position.BottomRight ]
    ]

// ... elsewhere in a click handler or update function ...

// Toast-invoking functions return ToastId.
// If you do not intend to dismiss toasts programmatically, you can throw away these values.

// Invoke a succcess toast.
Toastify.success "Done." |> ignore

// Invoke an error that does not close automatically
let toastId = Toastify.error (div [] [ str "I am a more complex React element" ], [ ToastOption.autoClose false ])
// and remove it manually at a later point (unless the user has already dismissed it).
Toastify.dismiss toastId

// Invoke a toast with type decided at run time.
let toastMessage (typ: ToastType) (content: ReactElement) =
	Toastify.toast (content, [ ToastOption.``type`` typ ]) |> ignore
```