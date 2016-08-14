/*
This file in the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require('gulp');

gulp.task('default', function () {
    gulp.src('./node_modules/bootstrap/dist/css/bootstrap.css').pipe(gulp.dest('./wwwroot/lib'));
    gulp.src('./Style/main.css').pipe(gulp.dest('./wwwroot/css'));
});