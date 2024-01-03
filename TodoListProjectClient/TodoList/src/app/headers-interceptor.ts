import { Injectable } from '@angular/core';
import {
  HttpInterceptor,
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpHeaders,
  HttpClient,
} from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class HeadersInterceptor implements HttpInterceptor {
  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    console.log('Interceptor called');
    // Set custom headers including 'userName'
    const headers = new HttpHeaders()
      .set('Content-Type', 'application/json')
      .set('userName', 'admin');
    const authReq = req.clone({
      headers: headers,
    });
    return next.handle(authReq);
  }
}
