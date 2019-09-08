**What is Constellation Mind?**
----------------

A sky map tool designed for enthusiasts of the astronomy. You can learn the shapes of the celestial sphere which is divided into three regions: north, equator and south. That can help you to concentrate on part of the night sky that is visible from your location. This constellation app contains two modes: one for learning and second for training of your current skills.

**What is ConstellationMind.Api?**
----------------

The ConstellationMind.Api is a REST API, containing core features for Android Application called [Constellation Mind](https://play.google.com/store/apps/details?id=com.mygdx.newbraveconstellation&hl=en).

**Build Status**
----------------

| Branch  | Build & Tests |
|---|:-----:|
|**master**|[![Build & Tests][linux-build-badge-master]][linux-build-master]|
|**develop**|[![Build & Tests][linux-build-badge-develop]][linux-build-develop]|

[linux-build-badge-master]: https://dev.azure.com/Constellation-Mind/Constellation%20Mind/_apis/build/status/Constellation%20Mind?branchName=master
[linux-build-master]: https://dev.azure.com/Constellation-Mind/Constellation%20Mind/_build/latest?definitionId=2&branchName=master
[linux-build-badge-develop]: https://dev.azure.com/Constellation-Mind/Constellation%20Mind/_apis/build/status/Constellation%20Mind?branchName=develop
[linux-build-develop]: https://dev.azure.com/Constellation-Mind/Constellation%20Mind/_build/latest?definitionId=2&branchName=develop

**What is prerequisites?**
----------------

You will need the following tools:

* [Visual Studio Code](https://code.visualstudio.com) or [Visual Studio](https://visualstudio.microsoft.com/vs/),
* [.Net Core](https://dotnet.microsoft.com/download) **(Please check if you have installed the same runtime version (SDK) described in** `/src/ConstellationMind.Api/*.csproj`**),**
* [MongoDB](https://www.mongodb.com/download-center/community) (*3.6.3 version or higher*).

**How to start the application?**
----------------

Follow these steps to get your development environment set up:

1. Clone the repository.
2. At the root directory, restore required packages by running:
```csharp
~$ dotnet restore
```
3. Next, build the solution by running:
```csharp
~$ dotnet build
```
4. Start the MongoDb service (by default it will be available under `mongodb://127.0.0.1:27017`)<br/>
4.1. Linux setup:<br/>
&nbsp;&nbsp;&nbsp;&nbsp;*Start the MongoDb service using the following command:*<br/>
&nbsp;&nbsp;&nbsp;&nbsp;`~$ sudo service mongodb start`<br/>
4.2. Windows setup:<br/>
&nbsp;&nbsp;&nbsp;&nbsp;Create the following folder `C:\data\db`<br/>
&nbsp;&nbsp;&nbsp;&nbsp;To start MongoDB, run `mongod.exe` using the following command:<br/>
&nbsp;&nbsp;&nbsp;&nbsp;`~$ "<your_installation_path>\MongoDB\Server\4.0\bin\mongod.exe" --dbpath="c:\data\db"`.<br/>
5. Finally, service can be started locally within `/src/ConstellationMind.Api` directory (by default it will be available under `http://localhost:5000`) using the following command:
```csharp
~$ dotnet run
```
You can also run the application using [Docker](https://www.docker.com):
1. Start the MongoDb service:
```docker
~$ docker run --name mongo -d -p 27017:27017 mongo:3.6
```
2. Run the application:
```docker
~$ docker run -d -p 5000:5000 --name constellation-mind constellation-mind-api --network const-mind
```
*_to run the container in the background use `-d` switch._

3. Or using Docker compose:</br>
3.1. Create a new `docker-compose.yml` file or use an existing which can find [here](scripts/docker-compose.yml).
```yml
version: "3.7"

services:
  api:
    build: dockerfile_location
    container_name: name
    depends_on:
      - mongo
    ports:
      - '5000:5000'
    networks:
      - network_name
  
  mongo:
    image: mongo:3.6
    container_name: name
    ports:
      - 27017:27017
    networks:
      - network_name 
    volumes:
      - mongo:volume_location

networks:
  network_name:
    name: name

volumes:
  mongo:
    driver: local
```
&nbsp;&nbsp;&nbsp;&nbsp;3.2. In order to start it, execute the following command:

```docker
~$ docker-compose up
```
