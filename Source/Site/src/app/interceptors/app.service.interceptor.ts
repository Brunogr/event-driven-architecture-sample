import { Injectable } from "@angular/core";
import { HttpInterceptor, HttpEvent, HttpRequest, HttpHandler } from "@angular/common/http";
import { Observable } from "rxjs/Observable";

@Injectable()
export class AppServiceInterceptor implements HttpInterceptor {

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const _req = req.clone(
    {
        headers: req.headers
        .set('Content-Type', 'application/json')
        .set('Accept', 'application/json')
    }
    );
    return next.handle(_req);
  }
}
