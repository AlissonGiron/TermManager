class Course extends Api {
    constructor() {
        super("Course");
    }
}

let apiCourse = new Course();

apiCourse.get();