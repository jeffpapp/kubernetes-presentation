const express = require('express');
const app = express();

var path = require('path');
var os = require('os');
var ip = require('ip');

const config = {
  port: parseInt(process.env.EXPRESS_PORT) || 3100,
};

const run = async () => {
  const prettyBytesModule = await import('pretty-bytes');
  const prettyBytes = prettyBytesModule.default;

  os.networkInterfaces();

  app.engine('.html', require('ejs').__express);

  app.set('views', path.join(__dirname, 'views'));

  app.use(express.static(path.join(__dirname, 'public')));

  app.set('view engine', 'html');

  app.get('/', (req, res) => {
    res.render('index', {
      model: {
        hostname: os.hostname(),
        numberOfCores: os.cpus().length,
        cpuArch: os.arch(),
        osPlatform: os.platform(),
        osVersion: os.version(),
        osRelease: os.release(),
        totalMemory: prettyBytes(os.totalmem()),
        nodeVersion: process.versions.node,
        serverIps: ip.address(),
      },
    });
  });

  app.listen(config.port, () => {
    console.log(`Example app listening on port ${config.port}`);
  });
};

run();
