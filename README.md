# Sample project for authorization & authentication between services

This sample contains two services, both ASP.NET WebAPI projects.

Both are set up to use Azure Active Directory (AAD) authentication & authorization, using role-based security.

The `Sample.Manufacturing.Dotnet.Api` is the backend application.
The `Sample.Partner.Dotnet.Api` is a frontend API from which authenticated requests will be made from within the service.

## Set up

The `appsettings.json` files need to be populated with identifiers that can be retrieved from AAD.  
The process on how to get these details can be found in the Microsoft docs on the matter, or consult me so I can explain.

The `ServiceController.cs` file also needs a couple of identifiers, similar to the ones set in the configuration. Again, the process on how to get these details can be found in the Microsoft docs on the matter, or consult me so I can explain.

## Sample usage

Run both applications.

Invoke a GET-request to `https://localhost:7100/api/Service` (from the `Sample.Partner.Dotnet.Api` project) (assuming the hostname & port aren't changed), and see the results appear from the `WeatherController` (in the Sample.`Manufacturing.Dotnet.Api`` project).  
If a 401 or 403 error is returned, or some other error, there is probably a configuration error.
