import { Injectable } from "@angular/core";
import { AppConfig } from "../../../config/config";
import { HttpService } from "../../../shared-component/services/http.service";
import "rxjs/Rx";
@Injectable()
export class AccountHttpService {
    constructor(private _httpService: HttpService) { }
    login(data: any) {
        return this._httpService.post(AppConfig.urls.login, data)
            .map(res => res);
    }
    logout() {
        return this._httpService.get(AppConfig.urls.logout)
            .map(res => res);
    }
    registration(data: any) {
        return this._httpService.post(AppConfig.urls.registration, data)
            .map(res => res);
    }
    getRequests(data: any) {
        return this._httpService.get(AppConfig.urls.allRequests, data)
            .map(res => res);
    }
}