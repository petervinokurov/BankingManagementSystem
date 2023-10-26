import {Injectable} from '@angular/core';
import {HttpRequest, HttpHandler, HttpInterceptor, HttpResponse, HttpStatusCode, HttpErrorResponse} from '@angular/common/http';
import { catchError, map, Observable } from 'rxjs';
import { HttpEvent } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { AppRoutes } from '../app-routes';
import { IdentityService } from '../login/identity.service';

@Injectable()
export class HttpErrorInterceptor implements HttpInterceptor {

  constructor(private readonly toastService:ToastrService,
    private readonly router:Router) { }

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {

    return next.handle(request).pipe(
      map((event) => {
        if (event instanceof HttpResponse) {
          let applicationError = event.body?.applicationError;
          if (applicationError){
            this.toastService.warning(applicationError);
            event = event.clone({body: null});
          }
        }
        return event;
      }),
      catchError((err) => {
        if (err instanceof HttpErrorResponse){
          if (err.status == HttpStatusCode.Unauthorized){
            this.router.navigate([AppRoutes.Root]);
          } else {
            this.toastService.error(err.error.applicationError);
          }
        }
        return new Observable<HttpEvent<unknown>>();
      })
    )
  }
}
