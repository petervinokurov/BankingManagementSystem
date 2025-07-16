// signalr.service.ts
import { Injectable } from '@angular/core';
import * as signalR from '@microsoft/signalr';
import { Store } from '@ngrx/store';
import { UserManagementHubEvents } from '../user-management/user-management-hub-events';
//import { updateItem } from './store/actions'; // your actual action

@Injectable({
  providedIn: 'root'
})

export class SignalRService {
  private hubConnection: signalR.HubConnection | undefined;

  constructor(private store: Store) {}

  public startConnection(): void {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl('https://localhost:5001/hub/userupdates') // replace with your SignalR hub URL
      .withAutomaticReconnect()
      .build();

    this.hubConnection
      .start()
      .then(() => console.log('SignalR connection started'))
      .catch(err => console.error('SignalR error:', err));

    this.registerListeners();
  }

  private registerListeners(): void {
    this.hubConnection?.on(UserManagementHubEvents.userUpdated, (data) => {
      // Dispatch NgRx action with received data
      console.log(data);
      //this.store.dispatch(updateItem({ item: data }));
    });
  }
}
