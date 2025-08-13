import { Injectable } from '@angular/core';
import * as signalR from '@microsoft/signalr';
import { UserManagementHubEvents } from '../user-management/user-management-hub-events';
import { Store } from '@ngrx/store';
import { updateUsersSuccess } from '../user-management/user-management-state/user-management.actions';
import { UpdateUsersResponse } from '../user-management/domain/updateUsersResponse';

@Injectable({ providedIn: 'root' })
export class SignalRService {

  private hubConnection!: signalR.HubConnection;

  constructor(private readonly store:Store) {
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
      this.store.dispatch(updateUsersSuccess({ response: data as UpdateUsersResponse }));
    });
  }
}
