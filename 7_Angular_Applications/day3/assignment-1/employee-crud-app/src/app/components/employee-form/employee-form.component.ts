// src/app/employee-form/employee-form.component.ts
import { Component, OnInit } from '@angular/core';
import { EmployeeService } from '../services/employee.service';
import { Employee } from '../models/employee.model';

@Component({
  selector: 'app-employee-form',
  templateUrl: './employee-form.component.html',
  styleUrls: ['./employee-form.component.css']
})
export class EmployeeFormComponent implements OnInit {
  employee: Employee = {
    firstName: '',
    middleName: '',
    lastName: '',
    age: null,
    salary: null,
    gender: '',
    country: ''
  };
  
  errorMessage: string = '';
  
  constructor(private employeeService: EmployeeService) {}

  ngOnInit(): void {}

  addEmployee() {
    if (this.isFormValid()) {
      this.employeeService.addEmployee(this.employee).subscribe(
        () => {
          console.log('Employee added:', this.employee);
          this.resetForm();
        },
        error => {
          this.errorMessage = 'Failed to add employee. Please try again.';
          console.error(error);
        }
      );
    } else {
      this.errorMessage = 'Please fill in all required fields.';
    }
  }

  private isFormValid(): boolean {
    return this.employee.firstName && this.employee.lastName &&
           this.employee.age !== null && this.employee.salary !== null &&
           this.employee.gender && this.employee.country;
  }

  private resetForm() {
    this.employee = {
      firstName: '',
      middleName: '',
      lastName: '',
      age: null,
      salary: null,
      gender: '',
      country: ''
    };
    this.errorMessage = '';
  }
}
