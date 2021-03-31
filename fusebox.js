const { fusebox, pluginSass } = require('fuse-box');
const path = require('path');
const [node, script, ...args] = process.argv;

const isProd = process.env.NODE_ENV === 'production' || args.includes("prod");
const isTest = args.includes("test");
const watch = args.includes("watch");

console.log(path.resolve(__dirname, './node_modules/'))

const fuse = fusebox({
    target: 'browser',
    sourceMap: true,
    entry: isTest ? './tests/Tests.fs.js' : './src/App.fs.js',
    hmr: !isProd && watch,
    devServer: !isProd && watch,
    webIndex: {
        template: isTest ? './tests/index.html' : './src/index.html',
    },
    stylesheet: {
        macros: {
            '~': path.resolve(__dirname, './node_modules/') + '/',
        },
    }
})

async function main() {
    if (isProd) {
        // update your target version depending on your browser support
        // possible values are https://www.typescriptlang.org/tsconfig#target
        await fuse.runProd({ buildTarget: 'ES5' });
    } else {
        await fuse.runDev({ buildTarget: 'ES2017' });
    }
}

main()
    .then(console.log)
    .catch(console.error)