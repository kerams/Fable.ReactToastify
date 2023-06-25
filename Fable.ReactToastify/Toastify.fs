module Fable.ReactToastify

open Fable.Core
open Fable.Core.JsInterop
open Fable.React
open System.ComponentModel

let inline private toast (): obj = import "toast" "react-toastify"

[<StringEnum; RequireQualifiedAccess>]
type Position =
    | [<CompiledName "top-left">] TopLeft
    | [<CompiledName "top-right">] TopRight
    | [<CompiledName "top-center">] TopCenter
    | [<CompiledName "bottom-left">] BottomLeft
    | [<CompiledName "bottom-right">] BottomRight
    | [<CompiledName "bottom-center">] BottomCenter

[<StringEnum; RequireQualifiedAccess>]
type DraggableDirection =
    | [<CompiledName "x">] X
    | [<CompiledName "y">] Y

[<StringEnum; RequireQualifiedAccess>]
type Theme =
    | [<CompiledName "light">] Light
    | [<CompiledName "dark">] Dark
    | [<CompiledName "colored">] Colored

[<StringEnum; RequireQualifiedAccess>]
type ToastType =
    | [<CompiledName "success">] Success
    | [<CompiledName "info">] Info
    | [<CompiledName "warning">] Warning
    | [<CompiledName "error">] Error

[<EditorBrowsable(EditorBrowsableState.Never)>]
type IContainerOption = interface end

[<EditorBrowsable(EditorBrowsableState.Never)>]
type IToastOption = interface end

[<EditorBrowsable(EditorBrowsableState.Never)>]
type ICssTransition = interface end

type ToastId = interface end

type ContainerId = interface end

[<Erase>]
type Transition =
    static member inline bounce: ICssTransition = import "Bounce" "react-toastify"
    static member inline slide: ICssTransition = import "Slide" "react-toastify"
    static member inline zoom: ICssTransition = import "Zoom" "react-toastify"
    static member inline flip: ICssTransition = import "Flip" "react-toastify"

[<Erase>]
type ContainerOption =
    /// One of top-right, top-center, top-left, bottom-right, bottom-center, bottom-left
    ///
    /// Default top-right
    static member inline position (pos: Position): IContainerOption = !!("position", pos)

    /// Delay in ms to close the toast. If set to false, the notification needs to be closed manually
    ///
    /// Default 5000
    static member inline autoClose (milliseconds: float): IContainerOption = !!("autoClose", milliseconds)

    /// Delay in ms to close the toast. If set to false, the notification needs to be closed manually
    ///
    /// Default 5000
    static member inline autoClose (enabled: bool): IContainerOption = !!("autoClose", enabled)

    /// A React Component to replace the default close button or false to hide the button
    static member inline closeButton (element: ReactElement): IContainerOption = !!("closeButton", element)

    /// A React Component to replace the default close button or false to hide the button
    static member inline closeButton (enabled: bool): IContainerOption = !!("closeButton", enabled)

    /// A reference to a valid react-transition-group/Transition component
    ///
    /// Default Bounce
    static member inline transition (element: ICssTransition): IContainerOption = !!("transition", element)

    /// Display or not the progress bar below the toast(remaining time)
    ///
    /// Default false
    static member inline hideProgressBar (value: bool): IContainerOption = !!("hideProgressBar", value)

    /// Display newest toast on top
    ///
    /// Default false
    static member inline newestOnTop (value: bool): IContainerOption = !!("newestOnTop", value)

    /// Dismiss toast on click
    ///
    /// Default true
    static member inline closeOnClick (value: bool): IContainerOption = !!("closeOnClick", value)

    /// Support right to left content
    ///
    /// Default false
    static member inline rtl (value: bool): IContainerOption = !!("rtl", value)

    /// Pause the timer when the window loses focus
    ///
    /// Default true
    static member inline pauseOnFocusLoss (value: bool): IContainerOption = !!("pauseOnFocusLoss", value)

    /// Allow toast to be draggable
    ///
    /// Default true
    static member inline draggable (value: bool): IContainerOption = !!("draggable", value)

    /// Keep the timer running or not on hover
    static member inline pauseOnHover (value: bool): IContainerOption = !!("pauseOnHover", value)

    /// One of light, dark, colored
    ///
    /// Default light
    static member inline theme (theme: Theme): IContainerOption = !!("theme", theme)

    /// Add optional classes to the container
    static member inline className (name: string): IContainerOption = !!("class", name)

    /// Add optional inline style to the container
    static member inline style (value: obj): IContainerOption = !!("style", value)

    /// Add optional classes to the toast
    static member inline toastClassName (name: string): IContainerOption = !!("toastClassName", name)

    /// Add optional classes to the toast body
    static member inline bodyClassName (name: string): IContainerOption = !!("bodyClassName", name)

    /// Add optional classes to the progress bar
    static member inline progressClassName (name: string): IContainerOption = !!("progressClassName", name)

    /// Add optional inline style to the progress bar
    static member inline progressStyle (value: obj): IContainerOption = !!("progressStyle", value)

    /// The percentage of the toast's width it takes for a drag to dismiss a toast(value between 0 and 100)
    ///
    /// Default 80
    static member inline draggablePercent (percent: int): IContainerOption = !!("draggablePercent", percent)

    /// Specify the drag direction.
    ///
    /// Default x
    static member inline draggableDirection (direction: DraggableDirection): IContainerOption = !!("draggableDirection", direction)

    /// Enable multi toast container support
    ///
    /// Default false
    static member inline enableMultiContainer (value: bool): IContainerOption = !!("enableMultiContainer", value)

    /// Used to identify the ToastContainer when working with multiple container. Also used to set the id attribute
    static member inline containerId (id: string): IContainerOption = !!("containerId", id)

    /// Used to identify the ToastContainer when working with multiple container. Also used to set the id attribute
    static member inline containerId (id: int): IContainerOption = !!("containerId", id)

    /// Used to limit the number of toast displayed on screen at the same time
    static member inline limit (value: int): IContainerOption = !!("limit", value)

    /// Define the ARIA role for the toasts
    ///
    /// Default alert
    static member inline role (role: string): IContainerOption = !!("role", role)

[<Erase>]
type ToastOption =
    /// Provide a custom id
    static member inline toastId (id: string): IToastOption = !!("toastId", id)

    /// Provide a custom id
    static member inline toastId (id: int): IToastOption = !!("toastId", id)

    /// One of info, success, warning, error
    static member inline ``type`` (toastType: ToastType): IToastOption = !!("type", toastType)

    /// One of top-right, top-center, top-left, bottom-right, bottom-center, bottom-left
    static member inline position (pos: Position): IToastOption = !!("position", pos)

    /// Delay in ms to close the toast. If set to false, the notification needs to be closed manually
    ///
    /// Default 5000
    static member inline autoClose (milliseconds: float): IToastOption = !!("autoClose", milliseconds)

    /// Delay in ms to close the toast. If set to false, the notification needs to be closed manually
    ///
    /// Default 5000
    static member inline autoClose (enabled: bool): IToastOption = !!("autoClose", enabled)

    /// A React Component to replace the default close button or false to hide the button
    static member inline closeButton (element: ReactElement): IToastOption = !!("closeButton", element)

    /// A React Component to replace the default close button or false to hide the button
    static member inline closeButton (enabled: bool): IToastOption = !!("closeButton", enabled)

    /// A reference to a valid react-transition-group/Transition component
    ///
    /// Default Bounce
    static member inline transition (element: ICssTransition): IToastOption = !!("transition", element)

    /// Display or not the progress bar below the toast(remaining time)
    ///
    /// Default false
    static member inline hideProgressBar (value: bool): IToastOption = !!("hideProgressBar", value)

    /// Dismiss toast on click
    ///
    /// Default true
    static member inline closeOnClick (value: bool): IToastOption = !!("closeOnClick", value)

    /// Pause the timer when the window loses focus
    ///
    /// Default true
    static member inline pauseOnFocusLoss (value: bool): IToastOption = !!("pauseOnFocusLoss", value)

    /// Allow toast to be draggable
    ///
    /// Default true
    static member inline draggable (value: bool): IToastOption = !!("draggable", value)

    /// Keep the timer running or not on hover
    static member inline pauseOnHover (value: bool): IToastOption = !!("pauseOnHover", value)

    /// Add optional classes to the toast
    static member inline className (name: string): IToastOption = !!("class", name)

    /// Add optional inline style to the toast
    static member inline style (value: obj): IToastOption = !!("style", value)

    /// Add optional classes to the TransitionGroup container
    static member inline bodyClassName (name: string): IToastOption = !!("bodyClassName", name)

    /// Add optional classes to the progress bar
    static member inline progressClassName (name: string): IToastOption = !!("progressClassName", name)

    /// Add optional inline style to the progress bar
    static member inline progressStyle (value: obj): IToastOption = !!("progressStyle", value)

    /// The percentage of the toast's width it takes for a drag to dismiss a toast(value between 0 and 100)
    ///
    /// Default 80
    static member inline draggablePercent (percent: int): IToastOption = !!("draggablePercent", percent)

    /// Specify the drag direction.
    ///
    /// Default x
    static member inline draggableDirection (direction: DraggableDirection): IToastOption = !!("draggableDirection", direction)

    /// Used to match a specific Toast container
    static member inline containerId (id: ContainerId): IToastOption = !!("containerId", id)

    /// Define the ARIA role for the toasts
    ///
    /// Default alert
    static member inline role (role: string): IToastOption = !!("role", role)

    /// Called when the notification appears
    static member inline onOpen (f: obj -> unit): IToastOption = !!("onOpen", f)

    /// Called when the notification disappears
    static member inline onClose (f: obj -> unit): IToastOption = !!("onClose", f)

    /// Called when click inside Toast notification
    static member inline onClick (f: obj -> unit): IToastOption = !!("onClick", f)

    /// Only available when using toast.update
    static member inline render (element: ReactElement): IToastOption = !!("render", element)

    /// Only available when using `toast.loading'
    static member inline isLoading (value: bool): IToastOption = !!("isLoading", value)

    /// Any additional data you want to pass toast("hello", { data: {key: value} })
    static member inline data (data: obj): IToastOption = !!("data", data)

    /// Let you delay the toast appearance. Pass a value in ms
    static member inline delay (milliseconds: float): IToastOption = !!("delay", milliseconds)

[<Erase>]
type Toastify =
    /// Container element to host the toasts
    static member inline container (options: IContainerOption list) = ReactBindings.React.createElement (import "ToastContainer" "react-toastify", createObj !!options, [])

    static member inline toast (text: string, options: IToastOption list): ToastId = emitJsExpr (toast, text, createObj !!options) "$0($1, $2)"

    static member inline toast (element: ReactElement, options: IToastOption list): ToastId = emitJsExpr (toast, element, createObj !!options) "$0($1, $2)"

    static member inline success (text: string): ToastId = toast?success(text)

    static member inline success (text: string, options: IToastOption list): ToastId = toast?success(text, createObj !!options)

    static member inline success (element: ReactElement): ToastId = toast?success(element)

    static member inline success (element: ReactElement, options: IToastOption list): ToastId = toast?success(element, createObj !!options)

    static member inline info (text: string): ToastId = toast?info(text)

    static member inline info (text: string, options: IToastOption list): ToastId = toast?info(text, createObj !!options)

    static member inline info (element: ReactElement): ToastId = toast?info(element)

    static member inline info (element: ReactElement, options: IToastOption list): ToastId = toast?info(element, createObj !!options)

    static member inline warn (text: string): ToastId = toast?warn(text)

    static member inline warn (text: string, options: IToastOption list): ToastId = toast?warn(text, createObj !!options)

    static member inline warn (element: ReactElement): ToastId = toast?warn(element)

    static member inline warn (element: ReactElement, options: IToastOption list): ToastId = toast?warn(element, createObj !!options)

    static member inline error (text: string): ToastId = toast?error(text)

    static member inline error (text: string, options: IToastOption list): ToastId = toast?error(text, createObj !!options)

    static member inline error (element: ReactElement): ToastId = toast?error(element)

    static member inline error (element: ReactElement, options: IToastOption list): ToastId = toast?error(element, createObj !!options)

    /// Remove all toasts
    static member inline dismiss (): unit = toast?dismiss();

    /// Remove given toast
    static member inline dismiss (toastId: ToastId): unit = toast?dismiss(toastId)

    /// Check if a toast is displayed or not
    static member inline isActive (toastId: ToastId): bool = toast?isActive(toastId)

    /// Update a toast
    static member inline update (toastId: ToastId, options: IToastOption list): unit = toast?update(toastId, createObj !!options)

    /// Clear waiting queue when working with limit
    static member inline clearWaitingQueue (): unit = toast?clearWaitingQueue()

    /// Clear waiting queue for a specific container when working with multiple container
    static member inline clearWaitingQueue (containerId: ContainerId): unit = toast?clearWaitingQueue {| containerId = containerId |}

    /// Completes the controlled progress bar
    static member inline ``done`` (toastId: ToastId): unit = toast?``done``(toastId)
