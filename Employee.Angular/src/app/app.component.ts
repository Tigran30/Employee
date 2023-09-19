import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { AddEmployeeComponent } from './components/employees/addeditemployee/addeditemployee.component';
import { EmployeesService } from './services/employees.service';
import {AfterViewInit, ViewChild} from '@angular/core';
import {MatPaginator, MatPaginatorModule} from '@angular/material/paginator';
import {MatSort, MatSortModule} from '@angular/material/sort';
import {MatTableDataSource, MatTableModule} from '@angular/material/table';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';
import { CoreService } from './core/core.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title : string = '';
  totalEmployees: number;
  totalActiveEmployees: number;
  totalMaleEmployees: number;
  totalFemaleEmployees: number;
  displayedColumns: string[] = [
      'id', 
      'firstName',
      'lastName',
      'dateOfBirth',
      'gender',
      'address1',
      'address2',
      'city',
      'postal',
      'country',
      'mobile',
      'email',
      'isActive',
      'action'];
  dataSource!: MatTableDataSource<any>;

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
  constructor(
    private dialog : MatDialog,
     private employeeService : EmployeesService,
     private coreService : CoreService) {
      this.totalEmployees = 0;
      this.totalActiveEmployees =0;
      this.totalMaleEmployees =0;
      this.totalFemaleEmployees=0;
     }
  ngOnInit(): void {
    this.getEmployeeList();
    this.employeeService.getEmployeesTotalListByCategory().subscribe({
      next :(response) =>{
        this.totalEmployees = response.result.totalEmployees;
        this.totalActiveEmployees = response.result.totalActiveEmployees;
        this.totalMaleEmployees = response.result.totalMaleEmployees;
        this.totalFemaleEmployees = response.result.totalFemaleEmployees;

      }
    })
  }
  onFormClick(message : string){
    this.coreService.openSnackBar(message);
  }
  openAddEditEmpForm()
  {
    const dialogRef = this.dialog.open(AddEmployeeComponent);
    dialogRef.afterClosed().subscribe({
      next :(val)=>{
        if(val) {
            this.getEmployeeList();
        }
      }
    })

  }

  getEmployeeList()
  {
    this.employeeService.getAllEmployeesByFilter().subscribe({
      next :(response)=>{
       this.dataSource = new MatTableDataSource(response.result);
       this.dataSource.sort = this.sort;
       this.dataSource.paginator = this.paginator;
      },
      error :(err)=>{
        console.log(err);
      }
    })
  }
  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  openEditEmpForm(data : any)
  {
    const dialogRef = this.dialog.open(AddEmployeeComponent,{
      data,
    });
    dialogRef.afterClosed().subscribe({
      next :(val)=>{
        if(val) {
            this.getEmployeeList();
        }
      }
    })
      
    }

  
}


