# TradierClient
.NET API Client for Tradier.com

This is a work in progress. I am working on implementing a .NET client for the Tradier.com platform. Currently I have implemented all of the User Data and Market Data methods (with the exception of streaming quotes) in Tradier's API.

There are currently two projects in the solution.

1.) TradierClient -- This is the actual client library

2.) TradierClient.Harness -- This is a simple GUI which can be used to test the calls and also to show how to work with the TradierClient library.

Please note that the Harness project has an App.config.sample file which you will have to rename. You will also need to enter your Tradier platform access token in the appropriate appSettings entry.
