import { Injectable } from '@angular/core';
import { Employee } from './employee.model';
import { Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  private employees: Employee[] = [
    { id: 1, name: 'John Doe', salary: 50000, role: 'Software Engineer', department: 'IT', age: 30, dob: new Date('1990-01-01') },
    { id: 2, name: 'Jane Doe', salary: 60000, role: 'Marketing Manager', department: 'Marketing', age: 35, dob: new Date('1985-01-01') },
  ];

  getEmployees(): Observable<Employee[]> {
    return of(this.employees);
  }

  getEmployee(id: number): Observable<Employee | undefined> {
    return of(this.employees.find((employee) => employee.id === id));
  }

  createEmployee(employee: Employee): Observable<Employee> {
    this.employees.push(employee);
    return of(employee);
  }

  updateEmployee(id: number, employee: Employee): Observable<Employee> {
    const index = this.employees.findIndex((employee) => employee.id === id);
    if (index !== -1) {
      this.employees[index] = employee;
    }
    return of(employee);
  }

  deleteEmployee(id: number): Observable<void> {
    const index = this.employees.findIndex((employee) => employee.id === id);
    if (index !== -1) {
      this.employees.splice(index, 1);
    }
    return of();
  }
}