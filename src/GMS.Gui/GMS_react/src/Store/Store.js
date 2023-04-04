import { configureStore } from '@reduxjs/toolkit';
import authReducer from './Auth/AuthStore';

export default configureStore({
  reducer: {
    auth: authReducer
  }
});