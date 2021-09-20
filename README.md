# troupon.deal.management

## Table of Contents
* [About The Project](#About-The-Project)
  * [Built with](#Built-with)
* [Getting Started](#Getting-Started)
  * [Prerequisites](#Prerequisites)
  * [Installation](#Installation)
  * [Contact](#Contact)

## About The Project
This POC was done for ARAI project as an initiative to create a referencial architechture for future projects.

### Built with
Project is mainly built with those frameworks:
* `ASP.NET Core`
* `EntityFramework`
* `HotChocolate`
* `MediatR`

And dev tools:

* `Automapper`
* `Newtonsoft`
* `Serilog`
* `Swagger`
  * `Swashbuckle`
  * `NSwag.ApiDescription.Client`
* `OneOf`

## Getting Started

### Prerequisites
Make sure installing this tools before doing installation:
* git
* dotnet

### Installation

1. Clone the repo
  ```sh
    # clone solution
    > git clone git@github.com:oualidktata/troupon.deal.management.git
  ```
2. Init and checkout submodules
  ```sh
    # clone/checkout the submodules
    > git submodule init & git submodule update
  ```

3. Restore dependencies
  ```sh
    # download NuGet packages
    dotnet restore .\Troupon.DealManagement.sln
  ```

## Contact

Oualid Ktata - [@oualidktata](https://github.com/oualidktata) - oualid.ktata@gmail.com

Project Link: [https://github.com/oualidktata/troupon.deal.management](https://github.com/oualidktata/troupon.deal.management)
