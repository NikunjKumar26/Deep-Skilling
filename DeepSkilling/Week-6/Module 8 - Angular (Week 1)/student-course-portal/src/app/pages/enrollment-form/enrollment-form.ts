import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-enrollment-form',
  standalone: false,
  templateUrl: './enrollment-form.html',
  styleUrl: './enrollment-form.css'
})
export class EnrollmentFormComponent {
  studentName = '';
  studentEmail = '';
  courseId: number | null = null;
  preferredSemester = 'Odd';
  agreeToTerms = false;
  
  submitted = false;

  onSubmit(form: NgForm) {
    console.log(form.value);
    console.log('Is valid:', form.valid);
    if (form.valid) {
      this.submitted = true;
    }
  }
}
