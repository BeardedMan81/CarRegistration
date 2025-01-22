const { env } = require('process');

const target = env.ASPNETCORE_HTTPS_PORT ? `https://localhost:${env.ASPNETCORE_HTTPS_PORT}` :
  env.ASPNETCORE_URLS ? env.ASPNETCORE_URLS.split(';')[0] : 'https://localhost:7291';

const PROXY_CONFIG = [
  {
    // Proxy API requests
    context: [
      "/api",
    ],
    target,
    secure: false
  },
  {
    // Proxy SignalR hub requests (WebSocket)
    context: ["/api","/carHub"],
    target,
    secure: false,
    ws: true // Enables WebSocket support
    
  }
]

module.exports = PROXY_CONFIG;
