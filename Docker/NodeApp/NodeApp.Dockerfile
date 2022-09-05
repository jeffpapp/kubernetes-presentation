ARG NODE_VERSION=16
FROM node:${NODE_VERSION}

# Create app directory
WORKDIR /src

# Install app dependencies
# A wildcard is used to ensure both package.json AND package-lock.json are copied
# where available (npm@5+)
COPY src/package*.json ./

RUN npm install
# If you are building your code for production
# RUN npm ci --only=production

# Bundle app source
COPY src/. .

ENV EXPRESS_PORT 80

EXPOSE 80
CMD [ "node", "index.js" ]