open System
open OpenQA.Selenium
open canopy
open runner

open types
open configuration
open reporters

reporter <- new LiveHtmlReporter(Firefox) :> IReporter

let liveHtmlReporter = reporter :?> LiveHtmlReporter
liveHtmlReporter.reportTemplateUrl <- @"http://CanopyDemo/content/reporttemplate.html"

start firefox
let firefoxBrowser = browser
start chrome
let chromeBrowser = browser
//start phantomJS
//let phantomJsBrowser = browser
//start ie
//let ieBrowser = browser

context "Demo Tests"

let test browser = 
    switchTo browser

    url "http://CanopyDemo"

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


// () => 
"Firefox" &&& fun _ ->
    test firefoxBrowser

"Chrome" &&& fun _ ->
    test chromeBrowser

"Internet Explorer" &&& todo

"PhantomJs" &&& todo

// run the tests
run()

let reportName = String.Format("{0:yyyy-MM-dd_hh-mm-ss}", DateTime.Now) + "_report"

liveHtmlReporter.saveReportHtml @"C:\Code\CanopyDemo\Reports\" reportName

quit firefoxBrowser
quit chromeBrowser

quit()