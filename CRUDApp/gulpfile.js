var gulp = require('gulp');
var exec = require('child_process').exec;

gulp.task("webpack", function (callback) {
    exec('node ./node_modules/webpack/bin/webpack.js', function (err, stdout, stderr) {
        console.log(stdout);
        console.log(stderr);
        callback(err);
    });
});