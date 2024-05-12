import { Routes } from '@angular/router';
import { LoginComponent } from './Components/Pages/login/login.component';
import { RegisterComponent } from './Components/Pages/register/register.component';
import { ChatComponent } from './Components/Pages/chat/chat.component';
import { authGuard } from './Guards/Auth/auth.guard';
import { ProfileComponent } from './Components/Pages/profile/profile.component';

export const routes: Routes = [
    { path: 'login', component: LoginComponent },
    { path: 'register', component: RegisterComponent },
    { path: 'profile/:userId', component: ProfileComponent },
    { path: 'chat', canActivate:[authGuard] ,
      children:[
        {path:'',component:ChatComponent}
      ]
    },
    { path: '', redirectTo: '/chat', pathMatch: 'full' }
  ];