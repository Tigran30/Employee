import { Component, Inject, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Employee } from 'src/app/Models/employee.model';
import { EmployeesService } from 'src/app/services/employees.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { FormBuilder, FormGroup, Validators, AbstractControl   } from '@angular/forms';
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
  dateOfBirth :['', [Validators.required, this.dateOfBirthValidator]],
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

  dateOfBirthValidator(control: AbstractControl) {
    const selectedDate = new Date(control.value);
    const currentDate = new Date();

    if (selectedDate > currentDate) {
      return { invalidDate: true };
    }

    return null;
  }

onFormCancel(){
  this.coreService.openSnackBar('Canceled');
  this.dialog.close(false);
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
                this.coreService.openSnackBar('Employee Updated');
                this.dialog.close(true);
              }
              else{
                this.coreService.openSnackBar(response.responseMessage.toString());
                this.dialog.close(false);
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
                this.coreService.openSnackBar('Employee Added Successfully');
                this.dialog.close(true);
              }
              else{
                this.coreService.openSnackBar(response.responseMessage.toString());
                this.dialog.close(false);
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
