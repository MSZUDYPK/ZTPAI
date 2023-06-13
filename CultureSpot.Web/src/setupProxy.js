const { createProxyMiddleware } = require('http-proxy-middleware');

module.exports = function (app) {
    app.use(
        '/api',
        createProxyMiddleware({
            target: 'https://localhost:7031',
            changeOrigin: true,
            secure: false
        })
    );

    app.use(
        '/images',
        createProxyMiddleware({
            target: 'http://localhost:8080',
            changeOrigin: true
        })
    );
};