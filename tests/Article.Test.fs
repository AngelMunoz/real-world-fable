module Tests.ArticleTests

open Fable.RemoteData

open Types
open Pages.Article
open Perla.Fable.Mocha

let _init =
  Tests.testList "Article Page" [
    Tests.test "initialized the model unauthenticated"
    <| fun _ ->
      init None "the-slug"
      |> fst
      |> Expect.equal {
        Article = Loading
        Comments = Loading
        NewComment = ""
        Errors = []
        Authentication = Unauthenticated
      }
    Tests.test "initializes the model authenticated"
    <| fun _ ->
      let session = { Token = ""; Username = "" }

      init (Some session) "the slug"
      |> fst
      |> Expect.equal {
        Article = Loading
        Comments = Loading
        NewComment = ""
        Errors = []
        Authentication = Authenticated { Session = session; User = Loading }
      }

  ]

Tests.runTest _init
