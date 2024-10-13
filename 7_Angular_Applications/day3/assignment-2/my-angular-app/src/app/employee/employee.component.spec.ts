import { TestBed } from '@angular/core/testing';
import { EmployeeComponent } from './employee.component';
import { EmployeeService } from './employee.service';
import { HttpClientTestingModule } from '@angular/common/http/testing';

describe('EmployeeComponent', () => {
  let component: EmployeeComponent;
  let fixture: ComponentFixture<EmployeeComponent>;
  let employeeService: EmployeeService;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      declarations: [EmployeeComponent],
      providers: [EmployeeService]
    })
      .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EmployeeComponent);
    component = fixture.componentInstance;
    employeeService = TestBed.inject(EmployeeService);
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should fetch employees', () => {
    const employees = [
      { id: 1, firstName: 'John', lastName: 'Doe' },
      { id: 2, firstName: 'Jane', lastName: 'Doe' }
    ];

    spyOn(employeeService, 'getEmployees').and.returnValue(of(employees));

    fixture.detectChanges();

    expect(component.employees).toEqual(employees);
  });

  it('should add employee', () => {
    const employee = { id: 3, firstName: 'Bob', lastName: 'Smith' };

    spyOn(employeeService, 'addEmployee').and.returnValue(of(employee));

    component.onSubmit();

    expect(component.employeeForm.valid).toBeTrue();
  });
});