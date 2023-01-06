import {Injectable} from '@angular/core';
import {HttpRequest, HttpHandler, HttpInterceptor} from '@angular/common/http';
import { catchError, Observable, tap } from 'rxjs';
import { HttpEvent } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';

@Injectable()
export class HttpErrorInterceptor implements HttpInterceptor {

  constructor(private readonly toastService:ToastrService) { }

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    return next.handle(request).pipe(

      tap((event: any) => {
        let applicationError = event?.body?.result?.applicationError;
        if (applicationError){
          this.toastService.warning(applicationError);
        }}),
      catchError((err) => {
        this.toastService.error(err.error.applicationError);
        return new Observable<HttpEvent<unknown>>();
      })
    )
  }
}
