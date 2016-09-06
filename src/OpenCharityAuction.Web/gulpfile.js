/*
This file in the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require('gulp');

gulp.task('default', function () {
    gulp.start('watch');
});

gulp.task('copyfiles', function () {
    gulp.src('./node_modules/bootstrap/dist/css/bootstrap.css').pipe(gulp.dest('./wwwroot/lib'));
    gulp.src('./Style/**/*').pipe(gulp.dest('./wwwroot/css'));
    gulp.src("./node_modules/jquery/dist/jquery.js").pipe(gulp.dest("./wwwroot/lib"));
    gulp.src("./node_modules/jqueryui/jquery-ui.js").pipe(gulp.dest("./wwwroot/lib"));
    gulp.src("./node_modules/jqueryui/jquery-ui.css").pipe(gulp.dest("./wwwroot/lib"));
    gulp.src("./Scripts/**/*").pipe(gulp.dest("./wwwroot/scripts"));
    gulp.src("./node_modules/jquery-validation/dist/jquery.validate.js").pipe(gulp.dest("./wwwroot/lib"));
    gulp.src("./node_modules/jquery-validation-unobtrusive/jquery.validate.unobtrusive.js").pipe(gulp.dest("./wwwroot/lib"));
    gulp.src("./node_modules/jqueryui/images/*").pipe(gulp.dest("./wwwroot/lib/images"));
    gulp.src("./node_modules/angular/angular.js").pipe(gulp.dest("./wwwroot/lib"));
})

gulp.task('watch'), function () {
    gulp.watch('*', ['default']);
    gulp.watch('*', ['default']);
}