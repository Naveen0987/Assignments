import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Employee } from '../employee.model';

@Component({
  selector: 'app-employee-details',
  templateUrl: './employee-details.component.html',
  styleUrls: ['./employee-details.component.css']
})
export class EmployeeDetailsComponent implements OnInit {
  employee: Employee;

  constructor(private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = +this.route.snapshot.paramMap.get('id');
    this.employee = this.getEmployeeById(id);
  }

  getEmployeeById(id: number): Employee {
    // Assuming EmployeeComponent's employees array is accessible
    const employees = (window as any).employees;
    return employees.find((employee) => employee.id === id);
  }
}