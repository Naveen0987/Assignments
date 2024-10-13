import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { EmployeeService } from '../employee.service';

@Component({
  selector: 'app-employee-delete',
  templateUrl: './employee-delete.component.html',
  styleUrls: ['./employee-delete.component.css']
})
export class EmployeeDeleteComponent implements OnInit {
  empid: number | undefined;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private employeeService: EmployeeService
  ) {}

  ngOnInit(): void {
    this.empid = parseInt(this.route.snapshot.paramMap.get('id')!, 10);
  }

  deleteEmployee(): void {
    if (this.empid !== undefined) {
      this.employeeService.deleteEmployee(this.empid);
      this.router.navigate(['/employee-list']);
    }
  }

  goToEmployeeList(): void {
    this.router.navigate(['/employee-list']);
  }
}
