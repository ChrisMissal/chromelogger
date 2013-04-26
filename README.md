![logo](/src/ChromeLogger/icon128.png)

# chromelogger

The .NET Version of chromelogger. Add output to the Chrome console from your .NET 
application's server-side code.

Install with NuGet: http://nuget.org/packages/ChromeLogger/

## Version 0.1.1

Improved the API a bit by adding a dependency on System.Web so calls such as 
`Logger.Log()` will add the header directly to the response.

## Version 0.1.0

A very crude implementation. Largely untested, please file any bugs or issues
on the GitHub issues page. I'm open to any and all suggestions to make this
work better, please share your thoughts as issues.

# License

[The MIT License - Copyright (c) 2013 Chris Missal](/license.txt)
