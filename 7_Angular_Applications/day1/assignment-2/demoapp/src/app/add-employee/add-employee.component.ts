import { Component, OnInit } from '@angular/core';
import { EmployeeService } from '../employee.service';
import { Employee } from '../employee.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-employee',
  templateUrl: './add-employee.component.html',
  styleUrls: ['./add-employee.component.css']
})
export class AddEmployeeComponent implements OnInit {
  employee: Employee = {
    id: 0,
    name: '',
    dob: new Date(),
    age: 0,
    gender: '',
    department: '',
    role: '',
    salary: 0
  };

  constructor(private employeeService: EmployeeService, private router: Router) { }

  ngOnInit(): void {
  }

  createEmployee() {
    this.employeeService.createEmployee(this.employee);
    this.router.navigate(['/employee-data']);
  }
}