import { Observable } from "rxjs/Observable";
import { AppConfig } from "./../../config/config";
import { KeyValueModel } from "./../../model/key-value.model";
import { StorageService } from "./storage.service";
import { Injectable } from "@angular/core";
import "rxjs/add/operator/map";
import "rxjs/add/operator/catch";
import { Router } from "@angular/router";
import { Headers, Http, Response } from "@angular/http";

@Injectable()
export class HttpService {
    private lang: string;

    constructor(
        private _http: Http,
        private _storage: StorageService,
        private _router: Router
    ) { }

    private prepareHeaders(headersRaw: KeyValueModel[]) {
        const headers = new Headers();

        headers.append("Access-Control-Allow-Origin", "*");
        if (headersRaw == null) {
            headers.append("Content-Type", "application/json");
        } else {
            headersRaw.forEach((item) => {
                headers.append(item.key, item.value);
            });
        }

        const token = this._storage.getItem(this._storage.keys.accessToken);
        headers.append("Authorization", "bearer " + token);
        return headers;
    }

    /* =============== METHODS ===============
    dataRaw     - regular JS object
    headersRaw  - object literal containing headers
    */
    get(url: string, { headersRaw = null, showLoader = true }: HttpGetParams = {}) {
        const headers = this.prepareHeaders(headersRaw);
        return this._http
            .get(AppConfig.apiUrl + url, { headers: headers })
            .map(response => {
                return response;
            })
            .catch(error => {
                this.intercept(error);
                return Observable.throw(error);
            });
    }

    post(url: string, dataRaw: any, { headersRaw = null, showLoader = true, stringifyData = true }: HttpPostParams = {}) {
        const headers = this.prepareHeaders(headersRaw);
        let data = null;
        if (stringifyData) {
            data = JSON.stringify(dataRaw);
        }

        return this._http
            .post(AppConfig.apiUrl + url, data || dataRaw, { headers: headers })
            .map(response => {
                return response;
            })
            .catch(error => {
                this.intercept(error);
                return Observable.throw(error);
            });
    }

    put(url: string, dataRaw: any, { headersRaw = null, showLoader = true }: HttpPutParams = {}) {
        const headers = this.prepareHeaders(headersRaw);
        const data = JSON.stringify(dataRaw);

        return this._http
            .put(AppConfig.apiUrl + url, data, { headers })
            .map(response => {
                return response;
            })
            .catch(error => {
                this.intercept(error);
                return Observable.throw(error);
            });
    }

    delete(url: string, { showLoader = true }: HttpDeleteParams = {}) {
        const headers = this.prepareHeaders(null);

        return this._http
            .delete(AppConfig.apiUrl + url, { headers })
            .map(response => {
                return response;
            })
            .catch(error => {
                this.intercept(error);
                return Observable.throw(error);
            });
    }

    private intercept(error: any) {
        if (error.status === 400) {
            return;
        }
        if (error.status === 404) {
            console.log(error);
            this._router.navigate(["/spa"]);
        }
        if (error.status === 401) {
            this._storage.removeItem(this._storage.keys.user);
            this._storage.removeItem(this._storage.keys.accessToken);
            this._storage.removeItem(this._storage.keys.expiresIn);
            this._router.navigate(["/spa"]);
            return;
        }
    }

    private formErrorMessage(error: any): string {
        let errorMessage = "Oops, something wrong!";
        let serverErrors = [];

        if (error && error._body) {
            serverErrors = JSON.parse(error._body);
        }

        const errorMessages = [];
        if (!!serverErrors) {
            for (const i in serverErrors) {
                if (serverErrors.hasOwnProperty(i)) {
                    const element = serverErrors[i];
                    errorMessages.push(serverErrors[i][0]);
                }
            }
        }

        errorMessage = errorMessages.join(", ");
        return errorMessage;
    }
}

interface HttpParams {
    headersRaw?: KeyValueModel[];
    showLoader?: boolean;
};

interface HttpGetParams extends HttpParams { };

interface HttpPutParams extends HttpParams { };

interface HttpDeleteParams extends HttpParams { };

interface HttpPostParams extends HttpParams {
    stringifyData?: boolean;
};
