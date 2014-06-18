//#r "canopy.dll"

open canopy
open runner
open System

open configuration
open reporters

reporter <- new LiveHtmlReporter() :> IReporter

start firefox
let mainBrowser = browser
start chrome
let secondBrowser = browser
//start ie

tile browsers

switchTo mainBrowser

"Demo Test" &&& fun _ ->

    url "http://localhost:54008/home/demo"

    "#firstName" << "John"
    "#lastName" << "Doe"

    "#firstName" == "John"
    "#lastName" == "Smith"

    
// run the tests
run()

switchTo secondBrowser

run()

quit mainBrowser
quit secondBrowser

printfn "press [enter] to exit"
System.Console.ReadLine() |> ignore

quit()