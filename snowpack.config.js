/** @type {import("snowpack").SnowpackUserConfig } */
module.exports = {
    mount: {
        public: { url: '/', static: true },
        src: { url: '/dist' },
    },
    plugins: [
        '@snowpack/plugin-babel',
        '@snowpack/plugin-dotenv',
        "@snowpack/plugin-react-refresh"
    ],
    routes: [
        /* Enable an SPA Fallback in development: */
        // {"match": "routes", "src": ".*", "dest": "/index.html"},
    ],
    optimize: {
        /* Example: Bundle your final build: */
        // "bundle": true,
    },
    packageOptions: {
        /* ... */
        polyfillNode: true,
        knownEntrypoints: ['react-dom']
    },
    devOptions: {
        /* ... */
    },
    buildOptions: {
        /* ... */
    },
};