import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { EmployeeService } from '../employee.service';
import { Employee } from '../employee.model';

@Component({
  selector: 'app-employee-create',
  templateUrl: './employee-create.component.html',
  styleUrls: ['./employee-create.component.css']
})
export class EmployeeCreateComponent {
  employee: Employee = {
    empid: 0,
    name: '',
    department: '',
    branch: '',
    age: 0,
    dob: '',
    country: '',
    contact: '',
    email: '',
    address: ''
  };

  constructor(private employeeService: EmployeeService, private router: Router) {}

  addEmployee() {
    this.employeeService.addEmployee(this.employee);
    this.router.navigate(['/employee-list']);
  }
}
