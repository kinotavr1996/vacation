import { LoginComponent } from './login/login.component';
import { AccountComponent } from './account.component';
import { ModuleWithProviders } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";


export const accountRoutes: Routes = [{
    path: "account",
    component: AccountComponent,
    children: [
        { path: "", redirectTo: "login", pathMatch: "full" },
        { path: "login", component: LoginComponent }
    ]
}];

export const appRoutingProviders: any[] = [];
export const booksRouting: ModuleWithProviders = RouterModule.forChild(accountRoutes);
