import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-course-list',
  standalone: false,
  templateUrl: './course-list.html',
  styleUrl: './course-list.css'
})
export class CourseListComponent implements OnInit {
  isLoading = true;
  selectedCourseId: number | null = null;
  courses: Array<{ id: number; name: string; code: string; credits: number; gradeStatus: 'passed' | 'failed' | 'pending' }> = [
    { id: 1, name: 'Angular Basics', code: 'ANG101', credits: 3, gradeStatus: 'passed' },
    { id: 2, name: 'Advanced CSS', code: 'CSS201', credits: 4, gradeStatus: 'passed' },
    { id: 3, name: 'TypeScript Deep Dive', code: 'TS301', credits: 4, gradeStatus: 'failed' },
    { id: 4, name: 'NodeJS Intro', code: 'NOD101', credits: 2, gradeStatus: 'pending' },
    { id: 5, name: 'React Fundamentals', code: 'RCT101', credits: 3, gradeStatus: 'pending' }
  ];

  ngOnInit() {
    setTimeout(() => {
      this.isLoading = false;
    }, 1500);
  }

  onEnroll(courseId: number) {
    console.log('Enrolling in course: ' + courseId);
    this.selectedCourseId = courseId;
  }

  trackByCourseId(index: number, course: any) {
    return course.id; // trackBy improves performance by only updating changed elements
  }
}
