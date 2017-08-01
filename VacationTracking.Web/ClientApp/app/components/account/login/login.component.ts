import { AccountHttpService } from './../account-shared/account-http.service';
import { EmployeeModel } from './../../../model/employee.model';
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
    constructor(private _httpService: AccountHttpService) { }

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
                .subscribe(res => { this.ngOnInit(); });
        }
    }
    logout() {
        if (confirm("Are you shure ?")) {
            this._httpService.logout()
                .subscribe(res => { this.ngOnInit(); });
        }
    }



}
