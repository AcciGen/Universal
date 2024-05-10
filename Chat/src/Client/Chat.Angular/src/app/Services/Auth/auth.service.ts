import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { TokenDTO } from '../../Model/token-dto';
import { RegisterDTO } from '../../Model/register-dto';
import { LoginDTO } from '../../Model/login-dto';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiUrl = 'https://localhost:7045/api/Auth'; // Server URL

  constructor(private http: HttpClient) {}

  register(userData: RegisterDTO) {
    return this.http.post<TokenDTO>(`${this.apiUrl}/Register`, userData);
  }

  refreshToken(refreshTokenData: any) {
    return this.http.post<TokenDTO>(`${this.apiUrl}/RefreshToken`, refreshTokenData);
  }

  login(loginData: LoginDTO) {
    return this.http.post<TokenDTO>(`${this.apiUrl}/Login`, loginData);
  }

  getAccessToken(){
    return window.localStorage.getItem('accessToken');
  }

  getRefreshToken(){
    return window.localStorage.getItem('refreshToken');
  }

  storeToken(token:TokenDTO){
    localStorage.setItem('accessToken', token.accessToken);
    localStorage.setItem('refreshToken', token.refreshToken);
    localStorage.setItem('expireDate', token.expireDate.toString());
  }
}
