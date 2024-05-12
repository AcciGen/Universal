import { Component } from '@angular/core';
import { AuthService } from '../../../Services/Auth/auth.service';
import { ProfileInfoDTO } from '../../../Model/profile-info-dto';

@Component({
  selector: 'app-profile',
  standalone: true,
  imports: [],
  templateUrl: './profile.component.html',
  styleUrl: './profile.component.scss'
})
export class ProfileComponent {
  profile: ProfileInfoDTO | undefined;


  constructor(private authService:AuthService) { }

  async ngOnInit() {
    this.getProfile();
  }

  getProfile() {
    this.authService.getProfileInfo().subscribe(
      (profile: ProfileInfoDTO) => {
        this.profile = profile;
        console.log('Profile Info:', this.profile);
      },
      (error) => {
        console.error('Error fetching profile:', error);
      }
    );
  }
}
