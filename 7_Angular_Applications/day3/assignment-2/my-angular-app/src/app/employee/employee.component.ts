import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Employee } from './employee.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {
  employeeForm: FormGroup;
  employees: Employee[] = [];
  nextId: number = 1;

  constructor(private router: Router) { }

  ngOnInit(): void {
    this.employeeForm = new FormGroup({
      name: new FormControl('', Validators.required),
      department: new FormControl('', Validators.required),
      branch: new FormControl('', Validators.required),
      age: new FormControl('', Validators.required),
      dob: new FormControl('', Validators.required),
      country: new FormControl('', Validators.required),
      contact: new FormControl('', Validators.required),
      email: new FormControl('', [Validators.required, Validators.email]),
      address: new FormControl('', Validators.required)
    });
  }

  onSubmit() {
    if (this.employeeForm.valid) {
      const newEmployee: Employee = {
        id: this.nextId++,
        name: this.employeeForm.get('name')?.value,
        department: this.employeeForm.get('department')?.value,
        branch: this.employeeForm.get('branch')?.value,
        age: this.employeeForm.get('age')?.value,
        dob: this.employeeForm.get('dob')?.value,
        country: this.employeeForm.get('country')?.value,
        contact: this.employeeForm.get('contact')?.value,
        email: this.employeeForm.get('email')?.value,
        address: this.employeeForm.get('address')?.value
      };
      this.employees.push(newEmployee);
      this.employeeForm.reset();
      this.router.navigate(['/employee', newEmployee.id]);
    }
  }
}