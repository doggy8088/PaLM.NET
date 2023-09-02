# Publishing Notes

## Build

```sh
dotnet build -c Release
```

## Publish

```ps1
dotnet nuget push bin\Release\PaLM.NET.0.1.0-alpha.nupkg --api-key "TheApiKey" --source https://api.nuget.org/v3/index.json
```
