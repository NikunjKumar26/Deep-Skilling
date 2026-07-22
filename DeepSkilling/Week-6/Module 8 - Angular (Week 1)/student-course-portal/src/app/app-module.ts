import { NgModule, provideBrowserGlobalErrorListeners } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing-module';
import { App } from './app';
import { HeaderComponent } from './components/header/header';
import { HomeComponent } from './pages/home/home';
import { CourseListComponent } from './pages/course-list/course-list';
import { StudentProfileComponent } from './pages/student-profile/student-profile';
import { CourseCardComponent } from './components/course-card/course-card';
import { HighlightDirective } from './directives/highlight';
import { CreditLabelPipe } from './pipes/credit-label-pipe';
import { EnrollmentFormComponent } from './pages/enrollment-form/enrollment-form';
import { ReactiveEnrollmentFormComponent } from './pages/reactive-enrollment-form/reactive-enrollment-form';

@NgModule({
  declarations: [
    App,
    HeaderComponent,
    HomeComponent,
    CourseListComponent,
    StudentProfileComponent,
    CourseCardComponent,
    HighlightDirective,
    CreditLabelPipe,
    EnrollmentFormComponent,
    ReactiveEnrollmentFormComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [
    provideBrowserGlobalErrorListeners()
  ],
  bootstrap: [App]
})
export class AppModule { }
