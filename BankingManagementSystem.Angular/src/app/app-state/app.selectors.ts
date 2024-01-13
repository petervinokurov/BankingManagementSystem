import { createFeatureSelector, createSelector } from "@ngrx/store";
import { AppState } from "./app.state";

export const selectAppState = createFeatureSelector<AppState>('appState');

export const selectUserLogin = createSelector(
  selectAppState,
  (appState) => appState.isLogin
);

export const selectUserProfile = createSelector(
  selectAppState,
  (appState: AppState) => {
    return appState.userProfile.entities[appState.currentUserId];
  }
);
