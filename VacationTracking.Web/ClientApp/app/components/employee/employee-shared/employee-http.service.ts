import { Injectable } from "@angular/core";
import { AppConfig } from "../../../config/config";
import { HttpService } from "../../../shared-component/services/http.service";
import "rxjs/Rx";
@Injectable()
export class EmployeeHttpService {
    constructor(private _httpService: HttpService) { }
    getCurrentUser() {
        return this._httpService.get(AppConfig.urls.currentuser)
            .map(res => res);
    }
    getRequests(id: any) {
        return this._httpService.get(AppConfig.urls.request + "/" + id)
            .map(res => res);
    }
    getRequestsById(id: any) {
        return this._httpService.get(AppConfig.urls.request, id)
            .map(res => res);
    }
    createRequest(data: any) {
        return this._httpService.post(AppConfig.urls.createRequest, data)
            .map(res => res);
    }
    getSortingRequest(id: number, sortBy: string, orderBy: string, pageNumber: number) {
        return this._httpService.get(AppConfig.urls.request + "/" + id +
            "?sortOrder=" + sortBy + "&direction=" + orderBy + "&page=" + pageNumber)
            .map(res => res.json());
    }
    deleteRequest(id: number) {
        return this._httpService.delete(AppConfig.urls.request + "/" + id)
            .map(res => res);
    }
    approve(id: number) {
        return this._httpService.get(AppConfig.urls.approve + "/" + id)
            .map(res => res);
    }
    putRequest(id: number, data: any) {
        return this._httpService.put(AppConfig.urls.editRequest + "/" + id, data)
            .map(res => res.json());
    }
}