import { Component, Input, Output, EventEmitter, OnChanges, SimpleChanges } from '@angular/core';

@Component({
  selector: 'app-course-card',
  standalone: false,
  templateUrl: './course-card.html',
  styleUrl: './course-card.css'
})
export class CourseCardComponent implements OnChanges {
  @Input() course!: { id: number; name: string; code: string; credits: number; gradeStatus: 'passed' | 'failed' | 'pending' };
  @Output() enrollRequested = new EventEmitter<number>();
  
  isExpanded = false;
  isEnrolled = false;

  ngOnChanges(changes: SimpleChanges) {
    console.log('Course changed:', changes['course'].previousValue, '->', changes['course'].currentValue);
  }

  get cardClasses() {
    return {
      'card--enrolled': this.isEnrolled,
      'card--full': this.course?.credits >= 4,
      'expanded': this.isExpanded
    };
  }

  onEnroll() {
    this.isEnrolled = true;
    this.enrollRequested.emit(this.course.id);
  }

  toggleExpanded() {
    this.isExpanded = !this.isExpanded;
  }
}
