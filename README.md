# TradierClient
.NET API Client for Tradier.com

This is a work in progress. I am working on implementing a .NET client for the Tradier.com platform. Currently I have implemented all of the Account Data, User Data and Market Data methods (with the exception of streaming quotes) in Tradier's API.

There are currently two projects in the solution.

1.) TradierClient -- This is the actual client library

2.) TradierClient.Harness -- This is a simple GUI which can be used to test the calls and also to show how to work with the TradierClient library.

Please note that the Harness project has an App.config.sample file which you will have to rename. You will also need to enter your Tradier platform access token in the appropriate appSettings entry.

------------------------------------------------------------------------------------------
It will be noted by users of this library that the responses for the MarketData calls are each wrapped by a specific class, whereas the AccountData and UserData calls return a general type of response class. This is because I'm currently undecided about what to do with the response and so I just return the raw XML/JSON. I have started, as my own use cases warrant, to wrap the JSON in an object model so that the consumer won't have to, but will continue pass through the raw response as currently happens for completeness sake.

Parsing into an object model for the response is only supported for JSON because that's what I'm using. And yeah I guess I need to make the constructors aware of the response format, because I just noticed I'm assuming JSON is the response content type for the two response types I've converted.

But hey, if you like XML, you're welcome to chip in with parsing in that format.
