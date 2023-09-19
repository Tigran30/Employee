import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.development';
import { Employee,EmployeeTotalModel } from '../Models/employee.model';
import { BaseResponse } from "../Models/employee.model"
import { Observable, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EmployeesService {
   baseApiUrl : string = environment.baseApiUrl;
  constructor(private http : HttpClient) { }

  getAllEmployeesByFilter() : Observable<BaseResponse<Employee[]>>{

     return this.http.post<BaseResponse<Employee[]>>(this.baseApiUrl + "/GetEmployeeListByFilter",{});
  }

  addEmployee(addEmpolyeeRequest : Employee) : Observable<BaseResponse<boolean>>
  {
    return this.http.post<BaseResponse<boolean>>(this.baseApiUrl+ "/AddEmployee", addEmpolyeeRequest);
  }

  updateEmployee(updateEmployeeRequest : Employee) : Observable<BaseResponse<boolean>>
  {
    return this.http.post<BaseResponse<boolean>>(this.baseApiUrl+ "/UpdateEmployee", updateEmployeeRequest);
  }

  getEmployeesTotalListByCategory() : Observable<BaseResponse<EmployeeTotalModel>>{

    return this.http.get<BaseResponse<EmployeeTotalModel>>(this.baseApiUrl + "/GetEmployeesTotalListByCategory");
 }

}
