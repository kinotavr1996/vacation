import { RegistrationComponent } from './registration/registration.component';
import { StorageService } from './../../shared-component/services/storage.service';
import { AccountComponent } from './account.component';
import { AccountHttpService } from './account-shared/account-http.service';
import { LoginComponent } from './login/login.component';
import { HttpService } from "./../../shared-component/services/http.service";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { CommonModule } from "@angular/common";
import { RouterModule } from "@angular/router";
import { PagerService } from "../../shared-component/paginator/paginator.component";

@NgModule({
    imports: [
        CommonModule,
        RouterModule,
        FormsModule
    ],
    declarations: [
        LoginComponent,
        RegistrationComponent,
        AccountComponent
    ],
    providers: [
        AccountHttpService,
        PagerService,
        HttpService,
        StorageService
    ]
})
export class AccountModule { }
