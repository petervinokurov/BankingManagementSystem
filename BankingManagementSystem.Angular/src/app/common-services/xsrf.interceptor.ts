import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { CookieService } from 'ngx-cookie-service';

@Injectable()
export class XsrfInterceptor implements HttpInterceptor {

  constructor(private readonly cookieService: CookieService) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    console.log(request);
    const xsrfToken = this.cookieService.get('XSRF-TOKEN');
    let xsrfRequest = request.clone({ headers: request.headers.set('XSRF-TOKEN', `${xsrfToken}`), withCredentials: true});
    console.log(xsrfRequest);
    return next.handle(xsrfRequest);
  }
}
