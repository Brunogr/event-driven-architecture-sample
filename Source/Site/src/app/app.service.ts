import { Observable } from 'rxjs/Observable';
import { HttpModule, Headers, Response, RequestOptions } from '@angular/http';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import 'rxjs/add/operator/retry';
import 'rxjs/add/operator/toPromise';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import { HttpHeaders, HttpParams } from '@angular/common/http';
import { environment } from '../environments/environment';

@Injectable()
export class AppService<TModel> {

    constructor(private http: HttpClient) { }

    private version = environment.versionBase;
    protected domain = environment.baseUrl;
    private url: string = this.domain + '/api/';

    get headers(): HttpHeaders {
        const headers = new HttpHeaders();
        headers.append('Content-Type', 'application/json');
        headers.append('Accept', 'application/json');
        headers.append('Access-Control-Allow-Credentials', '*');
        headers.append('Access-Control-Allow-Origin', '*');
        headers.append('Access-Control-Allow-Methods', 'GET, POST, PATCH, PUT, DELETE, OPTIONS');
        headers.append('Access-Control-Allow-Headers', 'Origin, X-Requested-With, X-XSRF-TOKEN, Content-Type, Accept, X-Auth-Token');
        return headers;
    }

    private methodUrl(method: string) {
        var url = this.domain.concat("api/")
        return url.concat(method);
    }


    protected async getAsync<TModel>(methodName: string): Promise<TModel> {
        const result = await this.http.get<TModel>(this.methodUrl(methodName), { headers: this.headers }).toPromise();
        return result;
    }

    protected async getByFilterAsync<TModel>(methodName: string, model: HttpParams): Promise<TModel> {
        // tslint:disable-next-line:max-line-length
        const result = await this.http.get<TModel>(this.methodUrl(methodName), { params: model, headers: this.headers }).toPromise();

        return result;
    }

    protected async getAllAsync<TModel>(methodName: string): Promise<TModel[]> {
        const result = await this.http.get<TModel[]>(this.methodUrl(methodName), { headers: this.headers }).toPromise();

        return result;
    }

    protected async postAsync<TModel>(methodName: string, model: any): Promise<TModel> {
        const result = await this.http.post<TModel>(this.methodUrl(methodName), JSON.stringify(model), { headers: this.headers }).toPromise();

        return result;
    }

    protected async putAsync<TModel>(methodName: string, model: any = null): Promise<TModel> {

        const result = await this.http.put<TModel>(this.methodUrl(methodName), JSON.stringify(model), { headers: this.headers }).toPromise();

        return result;
    }

    protected async deleteAsync(methodName: string): Promise<void> {
        const result = await this.http.delete<TModel>(this.methodUrl(methodName), { headers: this.headers }).toPromise();
    }

}



