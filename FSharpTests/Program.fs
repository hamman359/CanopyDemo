open System
open OpenQA.Selenium
open canopy
open runner

open configuration
open reporters

open types

//let liveHtmlReporter = new LiveHtmlReporter(Firefox)
//liveHtmlReporter.reportTemplateUrl <- System.Environment.CurrentDirectory + "..\\..\\..\\reports\\report_template\\canopy_test_results.htm"
//liveHtmlReporter.saveReportHtml(System.Environment.CurrentDirectory)("Report.html")
reporter <- new LiveHtmlReporter(Firefox) :> IReporter
//reporter <- liveHtmlReporter

start firefox
let mainBrowser = browser
//start chrome
//let secondBrowser = browser
//start ie

//tile browsers

//switchTo mainBrowser

"Demo Test" &&& fun _ ->

    url "http://localhost:56295"

    // Fill out and submit form
    "#FirstName" << "John"
    "#LastName" << "Doe"
    "#Address" << "123 Anywhere Dr."
    "#City" << "Nowhere"
    "#State" << "Ohio" // DDL
    "#Zip" << "12345"
    "#Email" << "John.Doe@Email.com"
    "#Confirm" << "John.Doe@Email.com"
    check "#SignUp[value='true']" //Radio
    click "#Submit"

    // Verify data
    highlight "#FirstName"
    "#FirstName" == "John"
    "#LastName" == "Doe"
    "#Address" == "123 Anywhere Dr."
    "#City" == "Nowhere"
    highlight "#State"
    "#State" == "Ohio"
    "#Zip" == "12345"
    "#Email" == "John.Doe@Email.com"
    highlight "#SignedUp"
    "#SignedUp" == "True"

// run the tests
run()

//switchTo secondBrowser
//
//run()

quit mainBrowser
//quit secondBrowser

//printfn "press [enter] to exit"
//System.Console.ReadLine() |> ignore

quit()