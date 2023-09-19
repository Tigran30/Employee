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

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title : string = '';
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
     private employeeService : EmployeesService) {}
  ngOnInit(): void {
    this.getEmployeeList()
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


