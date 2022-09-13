# Deploying to Kubernetes

## Steps to follow

- Tag the docker containers for Azure CR
  - `docker tag kubernetes-presentation-dotnet:latest squareikubernetespresentation.azurecr.io/kubernetes-presentation-dotnet:latest`
- Push the docker container to Azure CR
  - `docker push squareikubernetespresentation.azurecr.io/kubernetes-presentation-dotnet:latest`
