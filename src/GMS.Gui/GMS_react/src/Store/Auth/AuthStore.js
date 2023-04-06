import { createSlice } from "@reduxjs/toolkit";
export const authSlice = createSlice({
  name: 'auth',
  initialState: {
    value:
    {
      userName: '',
      token: '',
      role: 'guest'
    }
  },
  reducers:{
    login: (state, action) =>{
      state.value = action.payload;
    },

    logout: (state) => {
      state.value = {};
    }
  }
});

export const {login, logout} = authSlice.actions;

export default authSlice.reducer;
