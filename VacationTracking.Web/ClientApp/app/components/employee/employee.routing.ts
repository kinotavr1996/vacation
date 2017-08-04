import { RequestEditComponent } from './edit-request/edit-request.component';
import { RequestListComponent } from './request-list/request-list.component';
import { AddRequestComponent } from './add-request/add-request.component';
import { EmployeeComponent } from './employee.component';
import { ModuleWithProviders } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";

export const requestsRoutes: Routes = [{
    path: "employee",
    component: EmployeeComponent,
    children: [
        { path: "add/:id", component: AddRequestComponent },
        { path: "", redirectTo: "request-list", pathMatch: "full" },
        { path: "list/:id", component: RequestListComponent },
        { path: "request/edit/:id", component: RequestEditComponent }
    ]
}];

export const appRoutingProviders: any[] = [];
export const employeeRouting: ModuleWithProviders = RouterModule.forChild(requestsRoutes);
