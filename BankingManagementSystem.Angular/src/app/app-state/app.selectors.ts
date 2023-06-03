import { createFeatureSelector, createSelector } from "@ngrx/store";
import { AppState } from "./app.state";

export const selectIsLogin = createFeatureSelector<AppState>('appState');

export const selectUserLogin = createSelector(
  selectIsLogin,
  (appState) => appState.isLogin
);

export const selectUserName = createSelector(
  selectIsLogin,
  (appState) => appState.userName
);

export const selectUserEmail = createSelector(
  selectIsLogin,
  (appState) => appState.userEmail
);
