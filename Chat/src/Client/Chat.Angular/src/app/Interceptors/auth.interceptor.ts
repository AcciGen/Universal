import { HttpErrorResponse, HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { catchError, switchMap, throwError } from 'rxjs';
import { AuthService } from '../Services/Auth/auth.service';
import { Router } from '@angular/router';
import { TokenDTO } from '../Model/token-dto';
import { RefreshTokenDTO } from '../Model/refresh-token-dto';

export const authInterceptor: HttpInterceptorFn = (req, next) => {
  const authService = inject(AuthService);
  const myToken = authService.getAccessToken();
  console.log(myToken)
  const router = inject(Router)

  if(myToken){
    req = req.clone({
      setHeaders:({Authorization:`Bearer ${myToken}`})
    })
  }
  return next(req).pipe(
    catchError((err:any)=>{
      if(err instanceof HttpErrorResponse){
        if(err.status === 401){
          let token:RefreshTokenDTO = {
            accessToken:authService.getAccessToken()!,
            refreshToken:authService.getRefreshToken()!
          };
          
          token.accessToken = authService.getAccessToken()!;
          token.refreshToken = authService.getRefreshToken()!;

          return authService.refreshToken(token)
            .pipe(
              switchMap((data:TokenDTO) => {
                authService.storeToken(data);
                req = req.clone({
                  setHeaders:({Authorization:`Bearer ${data.accessToken}`})
                })
                return next(req)
              }),
              catchError((err) =>{
                return throwError(()=>{
                  alert("Token expired")
                  router.navigate(['/login'])
                })
              })
            )
        }
      }
      return throwError(() => new Error("Nimadur xato ketdida"));
    })
  );
};
