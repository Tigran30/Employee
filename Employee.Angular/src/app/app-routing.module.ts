import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddEmployeeComponent } from './components/employees/addeditemployee/addeditemployee.component';

const routes: Routes = [
  {
    path :'employees/add',
    component : AddEmployeeComponent
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
