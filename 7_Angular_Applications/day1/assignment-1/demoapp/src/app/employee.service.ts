import { Injectable } from '@angular/core';

export interface Employee {
  id: string;
  name: string;
  dob: string;
  age: number;
  gender: string;
}

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  private employees: Employee[] = [
    { id: '1', name: 'Naveen', dob: '1998-01-01', age: 23, gender: 'Male' },
    { id: '2', name: 'Surya', dob: '2000-01-01', age: 21, gender: 'Male' },
    // Add default employees if needed
  ];

  constructor() { }

  addEmployee(employee: Employee) {
    this.employees.push(employee);
  }

  getEmployees(): Employee[] {
    return this.employees;
  }
}
