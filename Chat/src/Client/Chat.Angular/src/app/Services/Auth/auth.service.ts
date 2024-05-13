import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { TokenDTO } from '../../Model/token-dto';
import { RegisterDTO } from '../../Model/register-dto';
import { LoginDTO } from '../../Model/login-dto';
import { ProfileInfoDTO } from '../../Model/profile-info-dto';
import { Observable, tap } from 'rxjs';
import { Message } from '../../Model/message';

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

  logOut(){
    window.localStorage.clear();
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

  isLoggedIn():boolean{
    return !! localStorage.getItem('accessToken');
  }

  getProfileInfo():Observable<ProfileInfoDTO>{
    const storedProfile = localStorage.getItem('profile');
    if (storedProfile) {
      return new Observable(observer => {
        observer.next(JSON.parse(storedProfile));
        observer.complete();
      });
    } else {
      return this.fetchProfileFromServer();
    }
  }

  private fetchProfileFromServer(): Observable<ProfileInfoDTO> {
    return this.http.get<ProfileInfoDTO>(`${this.apiUrl}/Profile`).pipe(
      tap(profile => {
        this.storeProfile(profile);
      })
    );
  }

  storeProfile(profile: ProfileInfoDTO): void {
    localStorage.setItem('profile', JSON.stringify(profile));
  }

  test(){
    return this.http.get('https://localhost:7139/api/Test');
  }

  getAllMessages(){
    return this.http.get<Message[]>('https://localhost:7139/api/Messages');
  }
}
