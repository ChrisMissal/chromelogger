![logo](/src/ChromeLogger/icon128.png)

# ChromeLogger

The .NET Version of chromelogger. Add output to the Chrome console from your .NET 
application's server-side code.

## For ASP.NET Classic (System.Web)
Install with NuGet: https://nuget.org/packages/ChromeLogger.AspNet/

### Setup

At the end of your request, you'll need to set the custom ChromeLogger header, here's an example:

```csharp
public class WebApiApplication : HttpApplication
{
    protected void Application_EndRequest(Object sender, EventArgs e)
    {
        Context.Response.Headers.Add(Logger.GetHeader());
    }
}
```

## For ASP.NET Core (2.2.2 and newer)
Install with NuGet: https://nuget.org/packages/ChromeLogger.AspNetCore/

### Setup

In your `Startup` class add a `using ChromeLogger;` line. Then in the `ConfigureServices` method, add a call to `services.AddChromeLogger();`. Finally in the very first line of the `Configure` method, add a call to `app.UseChromeLogger();`. It is probably a good idea to only make this call in a non-production environment.

# Changelog
### Version 1.0.1

Ignore Log calls with null parameter.

### Version 1.0.0

Refactoring project to new project format. Add ASP.NET Core support (2.2.2 and higher)

### Version 0.1.2

The most notable change is the requirement to manually add the header at the end of the request

### Version 0.1.1

Improved the API a bit by adding a dependency on System.Web so calls such as 
`Logger.Log()` will add the header directly to the response.

### Version 0.1.0

A very crude implementation. Largely untested, please file any bugs or issues
on the GitHub issues page. I'm open to any and all suggestions to make this
work better, please share your thoughts as issues.

## License

[The MIT License - Copyright (c) 2013 Chris Missal](/license.txt)
