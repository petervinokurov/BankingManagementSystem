import { Injectable } from '@angular/core';
import * as signalR from '@microsoft/signalr';
import { UserManagementHubEvents } from '../user-management/user-management-hub-events';

@Injectable({ providedIn: 'root' })
export class SignalRService {

  private hubConnection!: signalR.HubConnection;

  constructor() {
  }

  public async init(): Promise<void> {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl('/hub/userupdates', { withCredentials: true })
      .withAutomaticReconnect()
      .build();

    try {
      await this.hubConnection.start();
      this.registerListeners();
    } catch (err) {
      console.error('❌ SignalR connection failed:', err);
    }
  }

  public getHubConnection(): signalR.HubConnection {
    return this.hubConnection;
  }

  private registerListeners(): void {
    this.hubConnection?.on(UserManagementHubEvents.userUpdated, (data) => {
      // Dispatch NgRx action with received data
      console.log(data);
      //this.store.dispatch(updateItem({ item: data }));
    });
  }
}




