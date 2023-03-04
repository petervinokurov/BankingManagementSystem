import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { takeUntil } from "rxjs/operators";
import { environment } from "src/environments/environment";

@Injectable()
export class HttpApiService {
    constructor(private readonly http: HttpClient) { }

    public get<T>(
        url: string,
        data?: any,
        cancellationSubject?: Observable<void>
    ): Observable<T> {
        let request = this.http.get<T>(
            this.combineCompleteUrl(url, data)
        );

        if (cancellationSubject) {
            //request = this.applyCancellationSubject(
            //    request,
            //    cancellationSubject
            //);
        }

        return request;
    }

    public post<T>(
        url: string,
        data?: object,
        cancellationSubject?: Observable<void>
    ): Observable<T> {
        let request = this.http.post<T>(this.combineCompleteUrl(url), data);
        if (cancellationSubject) {

            //request = this.applyCancellationSubject(
            //    request,
            //    cancellationSubject
            //);
        }

        return request;
    }

    public put<T>(
        url: string,
        data: object,
        cancellationSubject?: Observable<void>
    ): Observable<T> {
        let request = this.http.put<T>(this.combineCompleteUrl(url), data);

        if (cancellationSubject) {
            request = this.applyCancellationSubject(
                request,
                cancellationSubject
            );
        }

        return request;
    }

    public delete<T>(
        url: string,
        data: any,
        cancellationSubject?: Observable<void>
    ): Observable<T> {
        let request = this.http.delete<T>(
            this.combineCompleteUrl(url, data)
        );

        if (cancellationSubject) {
            request = this.applyCancellationSubject(
                request,
                cancellationSubject
            );
        }

        return request;
    }

    private combineCompleteUrl(
      url: string,
      data: any = null
    ): string {
      let requestData = "";

      if (data) {
        if (typeof data === "object") {
          requestData = `?request=${encodeURIComponent(
            JSON.stringify(data)
          )}`;
        } else {
          requestData = `/${data as string}`;
        }
      }

      return `${environment.apiUrl}/${url}${requestData}`;
    }

    private applyCancellationSubject<T>(
      request: Observable<T>,
      cancellationSubject: Observable<void>
    ): Observable<T> {
      return request.pipe(takeUntil(cancellationSubject));
    }
}
