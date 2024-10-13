import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { EmployeeService, Employee } from '../employee.service';

@Component({
  selector: 'app-add-employee',
  templateUrl: './add-employee.component.html',
  styleUrls: ['./add-employee.component.css']
})
export class AddEmployeeComponent {
  newEmployee: Employee = { id: '', name: '', dob: '', age: 0, gender: '' };

  constructor(private employeeService: EmployeeService, private router: Router) { }

  onSubmit(): void {
    this.employeeService.addEmployee(this.newEmployee);
    this.router.navigate(['/employees']);
  }
}
