# TradierClient
.NET API Client for Tradier.com

This is a work in progress. I am working on implementing a .NET client for the Tradier.com platform. Currently I have implemented all of the Account Data, User Data and Market Data methods (with the exception of streaming quotes) in Tradier's API.

There are currently two projects in the solution.

1.) TradierClient -- This is the actual client library

2.) TradierClient.Harness -- This is a simple GUI which can be used to test the calls and also to show how to work with the TradierClient library.

Please note that the Harness project has an App.config.sample file which you will have to rename. You will also need to enter your Tradier platform access token in the appropriate appSettings entry.
------------------------------------------------------------------------------------------
It will be noted by users of this library that the responses for the MarketData calls are each wrapped by a specific class, whereas the AccountData and UserData calls return a general type of response class. This is because I'm currently undecided about what to do with the response and just return the raw XML/JSON. I have it in mind to wrap the XML/JSON in an object model so that the consumer won't have to, but to also pass through the raw response as currently happens for completeness sake.

I suppose once I start using this library for my own application and start working with it practically, I'll make a decision on how this implementation goes.
