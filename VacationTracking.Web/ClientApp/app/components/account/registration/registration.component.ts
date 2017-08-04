import { Router } from '@angular/router';
import { AccountHttpService } from './../account-shared/account-http.service';
import { EmployeeModel } from './../../../model/employee.model';
import { Component, Input, OnInit } from "@angular/core";
import { PagerService } from "../../../shared-component/paginator/paginator.component";
import "rxjs/add/operator/switchMap";

@Component({
    template: require("./registration.component.html"),
    styles: [require("./registration.component.css")]
})
export class RegistrationComponent implements OnInit {
    isAddVisible: boolean = false;
    isEditVisible: boolean = false;
    model: EmployeeModel;
    submitted = false;
    constructor(private _httpService: AccountHttpService, private router: Router) { }

    ngOnInit() {
        this.model = new EmployeeModel(null, null, null, null, null, null, null, null);
    }
    onSubmit() {
        this.submitted = true;
        this.register(this.model);
    }
    register(data: any) {
        if (this.submitted) {
            console.log(data);
            this._httpService.registration(data)
                .subscribe(res => { this.router.navigateByUrl("/account/login") });
        }
    }
}
