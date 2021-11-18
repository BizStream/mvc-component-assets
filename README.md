# mvc-component-assets ![License](https://img.shields.io/github/license/BizStream/mvc-component-assets) [![NuGet Version](https://img.shields.io/nuget/v/BizStream.AspNetCore.ViewComponentAssets)](https://nuget.org/packages/bizstream.aspnetcore.viewcomponentassets)

Annotations and TagHelpers for rendering static assets (`.js`, `.css`) associated with ViewComponents.

## Usage

- Install the `AspNetCore` package into the ASP.NET Core Mvc project:

```bash
dotnet add package BizStream.AspNetCore.ViewComponentAssets
```

OR

```csproj
<PackageReference Include="BizStream.AspNetCore.ViewComponentAssets" Version="x.x.x" />
```

- Configure services in the `Startup.cs` of the Mvc project:

```csharp
using BizStream.AspNetCore.ViewComponentAssets;
using Microsoft.Extensions.DependencyInjection;

// ...

public void ConfigureServices( IServiceCollection services )
{
    services.AddMvc()

      // support ViewComponentAssets annotations/tag helpers
      .AddViewComponentAssets();
}

public void Configure( IApplicationBuilder app, IWebHostEnvironment environment )
{
    // ...
}
```

- Annotate a `ViewComponent`:

```csharp
using BizStream.AspNetCore.ViewComponentAssets;
using Microsoft.AspNetCore.Mvc;

[ViewComponentScript("/scripts/my-view-component.js")]
public class MyViewComponent : ViewComponent
{
  // ...
}
```

- Use TagHelpers in Views:

```cshtml

@* ... *@

<body>
  @(await Component.InvokeAsync<MyViewComponent>())

  <view-component-scripts />
</body>
```

- Rendered HTML contains `<script />` elements for `ViewComponentScript`s:

```html
<body>
  <script src="/scripts/my-view-component.js" />
</body>
```
