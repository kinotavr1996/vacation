import { RequestEditComponent } from './edit-request/edit-request.component';
import { RequestListComponent } from './request-list/request-list.component';
import { AddRequestComponent } from './add-request/add-request.component';
import { EmployeeHttpService } from './employee-shared/employee-http.service';
import { StorageService } from './../../shared-component/services/storage.service';
import { HttpService } from "./../../shared-component/services/http.service";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { CommonModule } from "@angular/common";
import { RouterModule } from "@angular/router";
import { PagerService } from "../../shared-component/paginator/paginator.component";
import { EmployeeComponent } from "./employee.component";

@NgModule({
    imports: [
        CommonModule,
        RouterModule,
        FormsModule
    ],
    declarations: [
        AddRequestComponent,
        RequestEditComponent,
        RequestListComponent,
        EmployeeComponent,
        RequestListComponent
    ],
    providers: [
        EmployeeHttpService,
        PagerService,
        HttpService,
        StorageService
    ]
})
export class EmployeeModule { }
