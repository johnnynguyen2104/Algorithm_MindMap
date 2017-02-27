var gulp = require('gulp');
var sass = require('gulp-sass');

gulp.task('watcher', function () {
    gulp.watch('app/styles/*.scss', ['sass']);

});

gulp.task('sass', function () {
    return gulp.src('app/styles/*.scss')
      .pipe(sass()) // Using gulp-sass
      .pipe(gulp.dest('app/css'))
});