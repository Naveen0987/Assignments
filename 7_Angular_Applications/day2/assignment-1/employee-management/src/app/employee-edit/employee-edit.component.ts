import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { EmployeeService } from '../employee.service';
import { Employee } from '../employee.model';

@Component({
  selector: 'app-employee-edit',
  templateUrl: './employee-edit.component.html',
  styleUrls: ['./employee-edit.component.css']
})
export class EmployeeEditComponent implements OnInit {
  employee: Employee | undefined;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private employeeService: EmployeeService
  ) {}

  ngOnInit(): void {
    const empid = parseInt(this.route.snapshot.paramMap.get('id')!, 10);
    this.employee = this.employeeService.getEmployees().find(emp => emp.empid === empid);
    if (!this.employee) {
      this.router.navigate(['/employee-list']);
    }
  }

  updateEmployee(): void {
    if (this.employee) {
      this.employeeService.editEmployee(this.employee);
      this.router.navigate(['/employee-list']);
    }
  }
}
