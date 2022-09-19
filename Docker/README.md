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
    - `docker build -t kubernetes-presentation-dotnet:latest .`
    - `docker run -it --rm kubernetes-presentation-dotnet:latest`
    - `docker run -it --rm -p 3200:80 kubernetes-presentation-dotnet:latest`
    - `docker run -d --rm -p 3200:80 --name kubernetes-presentation-dotnet kubernetes-presentation-dotnet:latest`
    - `docker tag kubernetes-presentation-dotnet:latest squareikubernetespresentation.azurecr.io/kubernetes-presentation-dotnet:1.0.0`
    - `docker push squareikubernetespresentation.azurecr.io/kubernetes-presentation-dotnet:1.0.0`
  - Navigate to http://localhost:3200/
  - Run `docker stop kubernetes-presentation-dotnet` to stop the container
