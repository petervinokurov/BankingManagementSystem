import {Injectable} from '@angular/core';
import {HttpRequest, HttpHandler, HttpInterceptor, HttpResponse, HttpStatusCode, HttpErrorResponse} from '@angular/common/http';
import { catchError, map, Observable, tap, throwError } from 'rxjs';
import { HttpEvent } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';
import { BmsResponse } from './models/BmsResponse';
import { Router } from '@angular/router';
import { AppRoutes } from '../app-routes';
import { AppEvents } from '../app-events';

@Injectable()
export class HttpErrorInterceptor implements HttpInterceptor {

  constructor(private readonly toastService:ToastrService,
    private readonly router:Router,
    private readonly events:AppEvents) { }

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
            this.events.LogoutEmitter.emit();
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
