# Zeux Tech Test

## Important
Please download or fork this repository and submit your test separately. Do not generate pull requests or attempt to commit directly to this repo.

## Features
This is a sample solution that implements the following features

Mobile first single Page Application with
- A navigation bar
- "All", "Savings", "P2P", "Funds" tabs
- Different lists of investment products are loaded in each tab.

![alt text](http://bit.ly/2EzzpXo)

The data to populate the list of investment products is retrieved from a RESTful api. This api is **secured** so that only authenticated users can retrieve it. 

## Application
- Startup project: Zeux.Test.Server

- Client: Angular 7.1.0
- Server: .NET Core 2.1 API
- Unit tests: Xunit
- Responsive design
- Authorization: JWT (JSON Web Tokens)

To run the application simple build and run Zeux.Test.sln in Visual Studio.
