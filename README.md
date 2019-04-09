**What is Constellation.Api?**
----------------

The Constellation.Api is a REST API, containing core features for Android Application called [Constellation Mind](https://play.google.com/store/apps/details?id=com.mygdx.newbraveconstellation&hl=en).

**What is Constellation Mind?**
----------------

A sky map tool designed for enthusiasts of the astronomy. You can learn the shapes of the celestial sphere which is divided into three regions: north, equator and south. That can help you to concentrate on part of the night sky that is visible from your location. This constellation app contains two modes: one for learning and second for training of your current skills.

**What is prerequisites?**
----------------

You will need the following tools:

* [Visual Studio Code](https://code.visualstudio.com) or [Visual Studio](https://visualstudio.microsoft.com/vs/),
* [.Net Core](https://dotnet.microsoft.com/download) **(Please check if you have installed the same runtime version (SDK) described in** `/src/ConstellationMind.Api/*.csproj`**).**

**How to start the application?**
----------------

Follow these steps to get your development environment set up:

1. Clone the repository.
2. At the root directory, restore required packages by running:
```csharp
dotnet restore
```
3. Next, build the solution by running:
```csharp
dotnet build
```
4. Finally, service can be started locally within `/src/ConstellationMind.Api` directory (by default it will be available under `http://localhost:5000`) using the following command:
```csharp
dotnet run
```
