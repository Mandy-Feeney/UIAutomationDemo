# UI Automation Demo
The purpose of this demo project is to compare the implementation of common UI interactions of different Web UI automation tools.

Currently it compares the Playwright API to the Selenium API.

## Technology Used
- .NET 6
- C#
- SpecFlow
- Playwright
- Selenium

## Setup
.NET 6 and C# 10 is needed to be able to run the automation tests. 

### Selenium 
The Chrome Web Browser needs to be installed on the machine the tests are running on and match the same version as the Chrome Driver.

**Note:** The Selenium Chrome Driver version is managed by a nuget package

### Playwright
Playwright only requires a one-time install. Build the solution in Visual Studio and run this powershell script from the bin/debug directory:

``` bash
playwright.ps1 install
```

## Running the Tests
The test scenarios are using the BDD tool SpecFlow and are found under the Features directory.

To control whether the scenarios are ran using Playwright or Selenium, update the tag at the top of the Feature files. 
The @playwright tag will run the scenarios using Playwright and @selenium will run the scenarios using Selenium.

The tests can be ran from Test Explorer in Visual Studio or at a terminal.