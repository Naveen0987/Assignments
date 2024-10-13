import { Injectable } from '@angular/core';
import { Employee } from './employee.model';
import { employees } from './employee-data'; // Assuming you have a dummy data file

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  // ...

  getEmployee(id: number): Employee {
    return employees.find((employee) => employee.id === id);
  }
}