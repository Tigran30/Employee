import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.development';
import { Employee } from '../Models/employee.model';
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

  getEmployeebyId(id : number) : Observable<BaseResponse<Employee>>
  {
    const params = new HttpParams().set('employeeId', id.toString());
    return this.http.get<BaseResponse<Employee>>(this.baseApiUrl + "/GetEmployeeById",  {
      params: {
        id: id
      }});
  }
  
}
