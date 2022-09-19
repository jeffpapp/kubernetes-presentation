# Docker containers

## Steps to follow

- Build and Run the .Net App
  - In the `DotNetApp\src` folder run:
    - `dotnet run`
  - Navigate to http://localhost:3000/
- Build and Run the .Net Docker image
  - In the `DotNetApp` folder run:
    - `docker build -t kubernetes-presentation-dotnet .`
    - `docker run -it --rm -p 3200:80 kubernetes-presentation-dotnet`
    - `docker run -d --rm -p 3200:80 --name kubernetes-presentation-dotnet kubernetes-presentation-dotnet`
    - `docker tag kubernetes-presentation-dotnet squareikubernetespresentation.azurecr.io/kubernetes-presentation-dotnet:1.0.0`
    - `docker push squareikubernetespresentation.azurecr.io/kubernetes-presentation-dotnet:1.0.0`
  - Navigate to http://localhost:3200/
  - Run `docker stop kubernetes-presentation-dotnet` to stop the container
