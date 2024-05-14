import { Component, OnInit } from '@angular/core';
import { ChatDTO } from '../../../Model/chat-dto';
import { AuthService } from '../../../Services/Auth/auth.service';
import { error } from 'console';
import { ActivatedRoute, RouterLink } from '@angular/router';

@Component({
  selector: 'app-chat-list',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './chat-list.component.html',
  styleUrl: './chat-list.component.scss'
})
export class ChatListComponent implements OnInit {
    chats:ChatDTO[] = [];

    constructor(private apiService:AuthService){}

    ngOnInit(): void {
      this.apiService.getChats().subscribe(
        (response) =>{
          this.chats = response

          console.log(this.chats)
        },
        error =>{
          console.log(error.message)
        }
      )
    }
}
