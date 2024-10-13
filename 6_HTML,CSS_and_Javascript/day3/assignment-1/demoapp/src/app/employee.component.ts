import { Component, OnInit } from '@angular/core';
import { EmployeeService } from './employee.service';
import { Employee } from './employee.model';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {
  employees: Employee[] = [];
  employee: Employee = new Employee();
  isEdit: boolean = false;

  constructor(private employeeService: EmployeeService) { }

  ngOnInit(): void {
    this.getEmployees();
  }

  getEmployees(): void {
    this.employeeService.getEmployees().subscribe((data) => {
      this.employees = data;
    });
  }

  createEmployee(): void {
    this.employeeService.createEmployee(this.employee).subscribe(() => {
      this.getEmployees();
      this.employee = new Employee();
    });
  }

  updateEmployee(): void {
    this.employeeService.updateEmployee(this.employee.id, this.employee).subscribe(() => {
      this.getEmployees();
      this.employee = new Employee();
      this.isEdit = false;
    });
  }

  deleteEmployee(id: number): void {
    this.employeeService.deleteEmployee(id).subscribe(() => {
      this.getEmployees();
    });
  }

  editEmployee(employee: Employee): void {
    this.employee = employee;
    this.isEdit = true;
  }
}