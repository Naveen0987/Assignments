import { NgModule } from '@angular/core';
import { EmployeeComponent } from './employee.component';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [EmployeeComponent],
  imports: [
    RouterModule,
    ReactiveFormsModule,
    HttpClientModule
  ]
})
export class EmployeeModule { }