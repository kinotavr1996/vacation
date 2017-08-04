import { Router } from '@angular/router';
import { AccountHttpService } from './../account-shared/account-http.service';
import { EmployeeModel } from './../../../model/employee.model';
import { Component, Input, OnInit } from "@angular/core";
import { PagerService } from "../../../shared-component/paginator/paginator.component";
import "rxjs/add/operator/switchMap";

@Component({
    template: require("./logout.component.html"),
    styles: [require("./logout.component.css")]
})
export class LogoutComponent implements OnInit {
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
    }
    logout() {
        if (confirm("Are you shure ?")) {
            this._httpService.logout()
                .subscribe(res => this.router.navigateByUrl("/home"));
        }
    }
}
