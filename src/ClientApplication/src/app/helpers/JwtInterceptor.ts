import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { Observable } from 'rxjs';

import { AuthService } from '@lib/auth';

@Injectable()
export class JwtInterceptor implements HttpInterceptor {
    constructor(private authenticationService: AuthService) {}

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        // add authorization header with jwt token if available
        debugger;
        const currentUser = JSON.parse(localStorage.getItem('currentUser')); // this.authenticationService.getToken(); //.currentUserValue;

        if (currentUser) {
            request = request.clone({
                setHeaders: {
                    Authorization: `Bearer ${currentUser}`
                }
                // headers: request.headers.set('Authorization', `Bearer ${currentUser}`)
            });
        }
        console.log(request.headers);
        return next.handle(request);
    }
}
