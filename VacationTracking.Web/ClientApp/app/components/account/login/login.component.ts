import { Router } from '@angular/router';
import { EmployeeModel } from './../../../model/employee.model';
import { AccountHttpService } from './../account-shared/account-http.service';

import { Component, Input, OnInit } from "@angular/core";
import { PagerService } from "../../../shared-component/paginator/paginator.component";
import "rxjs/add/operator/switchMap";

@Component({
    template: require("./login.component.html"),
    styles: [require("./login.component.css")]
})
export class LoginComponent implements OnInit {
    isAddVisible: boolean = false;
    isEditVisible: boolean = false;
    model: EmployeeModel;
    submitted = false;
    isLogined: boolean;
    constructor(private _httpService: AccountHttpService, private router: Router) { }

    ngOnInit() {
        this.model = new EmployeeModel(null, null, null, null, null, null, null, null);
    }
    onSubmit() {
        this.submitted = true;
        this.login(this.model);
    }
    login(data: any) {
        if (this.submitted) {
            this._httpService.login(data)
                .subscribe(res => {
                    if (res.status == 200) {
                        this.isLogined = true;
                        console.log(JSON.parse(res._body));
                        this.model = EmployeeModel.fromJSON(JSON.parse(res._body));
                        console.log(this.model);
                        this.router.navigateByUrl("/employee/list/" + this.model.id);
                    }
                    else {
                        this.ngOnInit();
                    }
                });
        }
    }
}
