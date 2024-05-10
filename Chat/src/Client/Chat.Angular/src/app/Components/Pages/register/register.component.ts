import { Component } from '@angular/core';
import { RegisterDTO } from '../../../Model/register-dto';
import { FormsModule, NgModel } from '@angular/forms';
import { AuthService } from '../../../Services/Auth/auth.service';
import { TokenDTO } from '../../../Model/token-dto';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.scss'
})
export class RegisterComponent {
  registerData: RegisterDTO = {
    firstName: '',
    lastName: '',
    userName: '',
    phoneNumber: '',
    password: ''
  };

  constructor(private authService:AuthService,private router:Router){}

  onSubmit() {
    this.authService.register(this.registerData).subscribe(
      (response: TokenDTO) => {

        console.log('Ro\'yxatdan o\'tish muvaffaqiyatli');
        console.log(response);

        this.authService.storeToken(response)
        this.router.navigate(['/chat'])
      },
      error => {
        console.error('Ro\'yxatdan o\'tishda xatolik:', error);
      }
    );
  }
}
