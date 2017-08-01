import { HttpService } from './shared-component/services/http.service';
import { AccountComponent } from './components/account/account.component';
import { accountRoutes } from './components/account/account.routing';
import { AccountModule } from './components/account/account.module';
import { AccountHttpService } from './components/account/account-shared/account-http.service';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component'
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';


export const sharedConfig: NgModule = {
    bootstrap: [AppComponent],
    declarations: [
        AppComponent,
        NavMenuComponent,
        HomeComponent
    ],
    providers: [
        HttpService
    ],
    imports: [
        AccountModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            ...accountRoutes
        ])
    ]
};
