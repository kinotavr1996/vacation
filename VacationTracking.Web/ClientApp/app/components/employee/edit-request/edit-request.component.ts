import { RequestModel } from './../../../model/request.model';
import { EmployeeModel } from './../../../shared-component/controls/model/employee.model';
import { EmployeeHttpService } from './../employee-shared/employee-http.service';

import { PagerService } from "../../../shared-component/paginator/paginator.component";
import { Router, ActivatedRoute, Params } from "@angular/router";
import "rxjs/add/operator/switchMap";
import { Component, Input, Output, EventEmitter, OnInit } from "@angular/core";

@Component({
    template: require("./edit-request.component.html"),
    styles: [require("./edit-request.component.css")]
})
export class RequestEditComponent {
    model: RequestModel;
    id: number;
    private sub: any;
    constructor(private _httpService: EmployeeHttpService,
        private route: ActivatedRoute,
        private router: Router
    ) { }

    ngOnInit() {
        this.sub = this.route.params.subscribe(params => {
            this.id = +params["id"];
        });
        this._httpService.getRequestsById(this.id)
            .subscribe(res => {
                this.model = RequestModel.fromJSON(res);
            });
    }

    onSubmitForm() {
        this._httpService.putRequest(this.id, this.model)
            .subscribe(res => {
                this.model = RequestModel.fromJSON(res);
                this.router.navigateByUrl("/employee/list/" + this.model.employeeId);
            });
    }
}