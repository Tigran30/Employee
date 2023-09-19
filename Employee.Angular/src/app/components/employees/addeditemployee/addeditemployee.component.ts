import { Component, Inject, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Employee } from 'src/app/Models/employee.model';
import { EmployeesService } from 'src/app/services/employees.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { FormBuilder, FormGroup } from '@angular/forms';
import { DialogRef } from '@angular/cdk/dialog';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { CoreService } from 'src/app/core/core.service';

@Component({
  selector: 'app-add-employee',
  templateUrl: './addeditemployee.component.html',
  styleUrls: ['./addeditemployee.component.css']
})
export class AddEmployeeComponent implements OnInit {
  empGroup : FormGroup;

  constructor (private employeeService : EmployeesService,
     private router : Router, 
     private fb : FormBuilder, 
     private dialog : MatDialogRef<AddEmployeeComponent>,
     @Inject(MAT_DIALOG_DATA) public data :any,
     private coreService : CoreService) {
  this.empGroup = fb.group({
    id :1,
  lastName :"",
  firstName :"",
  dateOfBirth :new Date(),
  city :"",
  country :"",
  mobile :"",
  email :"",
   postal :"",
   isActive :[false],
   gender :"",
   address1 :"",
   address2 :""
  })
    
  }

  onFormSubmit(){
    if(this.empGroup.valid)
    {
      if(this.data)
      {
        const emp = this.empGroup.value as Employee
          this.employeeService.updateEmployee(emp).subscribe({
            next :(response)=>
            {
              if(response.responseCode === 0 && response.result)
              {
                this.coreService.openSnackBar('Employee Updated','done');
                this.dialog.close(true);
              }
            }
          });
      }
      else
      {
        const emp = this.empGroup.value as Employee
          this.employeeService.addEmployee(emp).subscribe({
            next :(response)=>
            {
              if(response.responseCode === 0 && response.result)
              {
                this.coreService.openSnackBar('Employee Added Successfully','done');
                this.dialog.close(true);
              }
            }
          });
      }
    }
  }
 
ngOnInit(): void {
this.empGroup.patchValue(this.data);
  
}
}
