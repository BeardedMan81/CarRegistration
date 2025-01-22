import { Component, OnInit, OnDestroy } from '@angular/core';
import * as signalR from '@microsoft/signalr';

@Component({
  selector: 'app-regestration-status',
  templateUrl: './registration-status.component.html',
  styleUrls: ['./registration-status.component.css']
})
export class RegistrationStatusComponent implements OnInit, OnDestroy {
  cars: any[] = [];
  now: Date = new Date();
  private hubConnection!: signalR.HubConnection;
  

  constructor() { }

  ngOnInit(): void {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl('https://localhost:7291/carHub')
      .build();

    this.hubConnection.on('ReceiveCarStatus', (data) => {
      this.cars = data;
    });

    this.hubConnection.start();
  }

  ngOnDestroy(): void {
    this.hubConnection.stop();
  }

}
