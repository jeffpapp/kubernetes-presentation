# Docker containers

## Steps to follow

- Build and Run the .Net App
  - In the `DotNetApp\src` folder run:
    - `dotnet run`
  - Navigate to http://localhost:3000/
- Build and Run the Node App
  - In the `NodeApp\src` folder run:
    - `npm install`
    - `node index.js`
  - Navigate to http://localhost:3100/
- Build and Run the .Net Docker image
  - In the `DotNetApp` folder run:
    - `docker build -f .\DotNetApp.Dockerfile -t kubernetes-presentation-dotnet:latest .`
    - `docker run -d --rm -p 3200:80 --name kubernetes-presentation-dotnet kubernetes-presentation-dotnet:latest`
  - Navigate to http://localhost:3200/
  - Run `docker stop kubernetes-presentation-dotnet` to stop the container
- Build and Run the Node Docker image
  - In the `NodeApp` folder run:
    - `docker build -f .\NodeApp.Dockerfile -t kubernetes-presentation-node:latest .`
    - `docker build -f .\NodeApp.Dockerfile -t kubernetes-presentation-node:16 --build-arg "NODE_VERSION=16" .`
    - `docker build -f .\NodeApp.Dockerfile -t kubernetes-presentation-node:14 --build-arg "NODE_VERSION=14" .`
    - `docker run -d --rm -p 3300:80 --name kubernetes-presentation-node kubernetes-presentation-dotnet:latest`
    - `docker run -d --rm -p 3314:80 --name kubernetes-presentation-node-14 kubernetes-presentation-dotnet:14`
    - `docker run -d --rm -p 3316:80 --name kubernetes-presentation-node-16 kubernetes-presentation-dotnet:16`
  - Navigate to http://localhost:3300/
  - Navigate to http://localhost:3314/
  - Navigate to http://localhost:3316/
  - Run `docker stop kubernetes-presentation-node` to stop the container
  - Run `docker stop kubernetes-presentation-node-14` to stop the container
  - Run `docker stop kubernetes-presentation-node-16` to stop the container
