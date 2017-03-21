module.exports = () => {
    return {
        entry: {
            main: './Scripts/main.ts'
        },
        output: {
            path: './wwwroot',
            filename: 'bundle.js'
        },
        resolve: {
            extensions: ['.js', '.ts', '.html']
        },
        module: {
            rules: [
                {
                    test: /\.ts$/,
                    loaders: ['awesome-typescript-loader'],
                    exclude: [/\.(spec|e2e)\.ts$/]
                },
                {
                    test: /\.html$/,
                    loader: 'raw-loader'
                }
            ]
        },
        devtool: 'inline-source-map'
    };
};