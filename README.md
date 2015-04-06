# AlienUtility #

This provides various utilities that might be necessary for other developers.


## Package Status ##

* **Aliencube.AppUtilities** [![](https://img.shields.io/nuget/v/Aliencube.AppUtilities.svg)](https://www.nuget.org/packages/Aliencube.AppUtilities/) [![](https://img.shields.io/nuget/dt/Aliencube.AppUtilities.svg)](https://www.nuget.org/packages/Aliencube.AppUtilities/)


## `AppUtility` Class ##

This class provides useful methods that can be used for both web apps and Windows apps.


### `MapPath()` Method ###

Traditionally, the `MapPath()` method has only been used for web apps. Now, it can be used for Windows apps like console apps, WinForm apps, WPF apps and Universal apps, as long as .NET Framework is used! Its usage can't simpler:

```csharp
var appUtil = new AppUtility();
var fullpath = appUtil.MapPath("~/Test");
```

It also provides more powerful method, `TryMapPath()`, which checks if the path exists or not.

```csharp
var appUtil = new AppUtility();

string fullpath;
var result = appUtil.TryMapPath("~/Test", out fullpath);
```

The benefits of using this method are:

* You can use this for your Windows apps such as console apps, WinForm apps, WPF apps and Universal apps.
* You don't have to rely on the `Server.MapPath()` method for your web apps any more.
* You can avoid one of top OWASP security vulnerabilities, [Path Traversal](https://www.owasp.org/index.php/Path_Traversal).

The only thing you need to remember for this method is:

* For apps other than web apps, this method assumes the app directory as the root directory.
* In order to provide the path for outside the app directory, it should be the absolute path like `C:\Temp`.


## Contribution ##

Your contributions are always welcome! All your work should be done in your forked repository. Once you finish your work, please send us a pull request onto our `dev` branch for review.


## License ##

**CloudConver.NET** is released under [MIT License](http://opensource.org/licenses/MIT)

> The MIT License (MIT)
>
> Copyright (c) 2015 [aliencube.org](http://aliencube.org)
> 
> Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
> 
> The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
> 
> THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
