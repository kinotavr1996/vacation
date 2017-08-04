import { EmployeeComponent } from './../employee.component';
import { EmployeeHttpService } from './../employee-shared/employee-http.service';
import { RequestModel } from './../../../model/request.model';
import { EmployeeModel } from './../../../model/employee.model';
import { Component, Input, OnInit } from "@angular/core";
import { PagerService } from "../../../shared-component/paginator/paginator.component";
import "rxjs/add/operator/switchMap";
import { Router, ActivatedRoute, Params } from "@angular/router";
@Component({
    template: require("./add-request.component.html"),
    styles: [require("./add-request.component.css")]
})
export class AddRequestComponent implements OnInit {
    isAddVisible: boolean = false;
    isEditVisible: boolean = false;
    model: RequestModel;
    employee: EmployeeModel;
    submitted = false;
    isLogined: boolean;
    private id: number;
    private sub: any;
    constructor(private _httpService: EmployeeHttpService, private route: ActivatedRoute) {
        this.getCurrentUser();
    }

    ngOnInit() {
        this.model = new RequestModel(null, null, null, false, null, null);
        this.sub = this.route.params.subscribe(params => {
            this.id = +params["id"];
        });
    }
    onSubmit() {
        this.submitted = true;
        this.model.employeeId = this.id;
        this.model.id = this.id;
        this.createRequest(this.model);
    }
    getCurrentUser() {
        console.log('getCurrentUser');
        this._httpService.getCurrentUser()
            .subscribe(res => {
                this.employee = EmployeeModel.fromJSON(res);
                this.model = new RequestModel(null, this.employee.id, null, false, null, null);
            });
    }
    createRequest(data: any) {
        if (this.submitted) {
            this._httpService.createRequest(data)
                .subscribe(res => { this.ngOnInit(); });
        }
    }
}
