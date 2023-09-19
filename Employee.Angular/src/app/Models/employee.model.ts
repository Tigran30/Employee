export interface Employee {
    id : number;
     firstName: string;
     lastName: string;
     dateOfBirth: Date;
     gender: string;
     address1: string;
     address2?: string;
     city: string;
     postal: string;
     country: string;
     email: string;
     mobile: string;
     isActive: boolean;
};
export interface BaseResponse<T>
{
    responseCode : number,
    responseMessage : string,
    result : T
}

export interface EmployeeTotalModel {
    totalEmployees: number,
    totalActiveEmployees: number,
    totalMaleEmployees: number,
    totalFemaleEmployees: number
}