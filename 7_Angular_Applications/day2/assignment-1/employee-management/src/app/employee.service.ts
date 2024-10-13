import { Injectable } from '@angular/core';
import { Employee } from './employee.model';
import { ValidatorFn, AbstractControl } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  private employees: Employee[] = [
    { empid: 1, name: 'John Doe', department: 'IT', branch: 'New York', age: 30, dob: '1993-05-15', country: 'USA', contact: '1234567890', email: 'john@example.com', address: '123 Street' },
    { empid: 2, name: 'Jane Smith', department: 'HR', branch: 'London', age: 28, dob: '1995-07-20', country: 'UK', contact: '0987654321', email: 'jane@example.com', address: '456 Avenue' },
    { empid: 3, name: 'Michael Brown', department: 'Finance', branch: 'Sydney', age: 35, dob: '1988-01-30', country: 'Australia', contact: '1122334455', email: 'michael@example.com', address: '789 Boulevard' },
    { empid: 4, name: 'Emily Davis', department: 'Marketing', branch: 'Toronto', age: 32, dob: '1991-12-10', country: 'Canada', contact: '6677889900', email: 'emily@example.com', address: '101 Road' },
    { empid: 5, name: 'Chris Wilson', department: 'Sales', branch: 'San Francisco', age: 40, dob: '1983-03-25', country: 'USA', contact: '5566778899', email: 'chris@example.com', address: '202 Circle' }
  ];

  getEmployees() {
    return this.employees;
  }

  addEmployee(employee: Employee) {
    this.employees.push(employee);
  }

  editEmployee(employee: Employee) {
    const index = this.employees.findIndex(emp => emp.empid === employee.empid);
    if (index !== -1) {
      this.employees[index] = employee;
    }
  }

  deleteEmployee(empid: number) {
    this.employees = this.employees.filter(emp => emp.empid !== empid);
  }

  // Validators
  validateEmpId(): ValidatorFn {
    return (control: AbstractControl) => {
      const empId = control.value;
      const existingEmpId = this.employees.find(emp => emp.empid === empId);
      return existingEmpId ? { empIdExists: true } : null;
    };
  }

  validateName(): ValidatorFn {
    return (control: AbstractControl) => {
      const name = control.value;
      const pattern = /^[a-zA-Z ]+$/;
      return pattern.test(name) ? null : { invalidName: true };
    };
  }

  validateAge(): ValidatorFn {
    return (control: AbstractControl) => {
      const age = control.value;
      const minAge = 18;
      const maxAge = 60;
      return age >= minAge && age <= maxAge ? null : { invalidAge: true };
    };
  }

  validateContact(): ValidatorFn {
    return (control: AbstractControl) => {
      const contact = control.value;
      const pattern = /^\d{10}$/;
      return pattern.test(contact) ? null : { invalidContact: true };
    };
  }

  validateEmail(): ValidatorFn {
    return (control: AbstractControl) => {
      const email = control.value;
      const pattern = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
      return pattern.test(email) ? null : { invalidEmail: true };
    };
  }
}