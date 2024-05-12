import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HubConnection, HubConnectionBuilder, LogLevel } from '@microsoft/signalr';
import { AuthService } from '../../../Services/Auth/auth.service';

@Component({
  selector: 'app-chat',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './chat.component.html',
  styleUrl: './chat.component.scss'
})
export class ChatComponent implements OnInit {
  
  private connection: HubConnection;
  public messages: string[] = [];
  public user: string = "";
  public message: string = "";


  constructor(private authService:AuthService) {
    this.connection = new HubConnectionBuilder()
      .withUrl('https://localhost:7139/chathub',
      {
        accessTokenFactory:() => this.authService.getAccessToken()!
      })
      .configureLogging(LogLevel.Information)
      .build();
  }

  async ngOnInit() {
    this.connection.on('ReceiveMessage', (user, message) => {
      this.messages.push(`${user}: ${message}`);
    });

    try {
      await this.connection.start();
      console.log('Connected to SignalR hub');
    } catch (error) {
      console.error('Failed to connect to SignalR hub', error);
    }
  }

  async sendMessage() {
    if (!this.user || !this.message) return;
    await this.connection.invoke('SendMessage', this.user, this.message);
    this.message = '';
  }
}
