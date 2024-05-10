import { Routes } from '@angular/router';
import { LoginComponent } from './Components/Pages/login/login.component';
import { RegisterComponent } from './Components/Pages/register/register.component';
import { ChatComponent } from './Components/Pages/chat/chat.component';

export const routes: Routes = [
    { path: 'login', component: LoginComponent },
    { path: 'register', component: RegisterComponent },
    { path: 'chat', component: ChatComponent },
    { path: '', redirectTo: '/login', pathMatch: 'full' } // Bosh sahifa
  ];