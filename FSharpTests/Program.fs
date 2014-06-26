open System
open OpenQA.Selenium
open canopy
open runner

open configuration
open types
open reporters

reporter <- new LiveHtmlReporter(Firefox) :> IReporter

//liveHtmlReporter.browser
//let allHtml = liveHtmlReporter.js "return $().html();"
//let allHtml2 = liveHtmlReporter.reportHtml()
//liveHtmlReporter.saveReportHtml @"c:\" "report"



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

let liveHtmlReporter = reporter :?> LiveHtmlReporter
liveHtmlReporter.reportTemplateUrl <- @"http://localhost:56295/content/reporttemplate.html"
//liveHtmlReporter.reportHtml()
liveHtmlReporter.saveReportHtml @"C:\Code\CanopyDemo\" "report"

quit mainBrowser
//quit secondBrowser

//printfn "press [enter] to exit"
//System.Console.ReadLine() |> ignore


quit()