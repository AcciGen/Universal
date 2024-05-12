import { Component } from '@angular/core';
import { LoginDTO } from '../../../Model/login-dto';
import { AuthService } from '../../../Services/Auth/auth.service';
import { TokenDTO } from '../../../Model/token-dto';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { ProfileInfoDTO } from '../../../Model/profile-info-dto';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent {
  loginData: LoginDTO = 
  {
    phoneNumber: '',
    password: ''
  };

  constructor(private authService: AuthService,private router:Router) {}

  onSubmit(){
    this.authService.login(this.loginData).subscribe(
      (response: TokenDTO) => {
        console.log('Login successful');
        console.log(response);
        
        this.authService.storeToken(response)
        this.router.navigate(['/chat'])
      },
      error => {
        console.error('Error logging in:', error);
      }
    );
  }
}
