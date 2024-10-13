export class Employee {
  id: number;
  name: string;
  salary: number;
  role: string;
  department: string;
  age: number;
  dob: Date;

  constructor(
    id: number = 0,
    name: string = '',
    salary: number = 0,
    role: string = '',
    department: string = '',
    age: number = 0,
    dob: Date = new Date()
  ) {
    this.id = id;
    this.name = name;
    this.salary = salary;
    this.role = role;
    this.department = department;
    this.age = age;
    this.dob = dob;
  }
}