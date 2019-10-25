module Router

open Elmish.UrlParser
open Elmish.Navigation
open Fable.React.Props

type SessionRoute =
    | Settings
    | NewArticle
    | EditArticle of string
    | Logout

type Route =
    | Login
    | Register
    | Article of string
    | Articles
    | SessionRoute of SessionRoute
    | Profile of string


let pageParser: Parser<Route -> Route, Route> =
    oneOf
        [ map Article (s "article" </> str)
          map Articles top
          map Profile (s "profile" </> str)
          map Login (s "login")
          map Register (s "register")
          map (Settings |> SessionRoute) (s "settings")
          map (NewArticle |> SessionRoute) (s "editor")
          map (EditArticle >> SessionRoute) (s "editor" </> str)
          map (Logout |> SessionRoute) (s "logout") ]


let toHash route =
    match route with
    | Articles -> ""

    | Article slug -> sprintf "article/%s" slug

    | Profile username -> sprintf "profile/%s" username

    | Login -> "login"

    | Register -> "register"

    | SessionRoute Settings -> "settings"

    | SessionRoute NewArticle -> "editor"

    | SessionRoute Logout -> "logout"

    | SessionRoute(EditArticle slug) -> sprintf "editor/%s" slug
    |> (fun r -> sprintf "#/%s" r)


let href = toHash >> Href


let modifyUrl route =
    route
    |> toHash
    |> Navigation.modifyUrl


let newUrl route =
    route
    |> toHash
    |> Navigation.newUrl
